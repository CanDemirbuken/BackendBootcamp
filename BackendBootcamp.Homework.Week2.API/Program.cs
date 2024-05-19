using Autofac;
using Autofac.Extensions.DependencyInjection;
using BackendBootcamp.Homework.Week2.API.Filters;
using BackendBootcamp.Homework.Week2.API.Middlewares;
using BackendBootcamp.Homework.Week2.API.Modules;
using BackendBootcamp.Homework.Week2.Repository;
using BackendBootcamp.Homework.Week2.Service.Mapping;
using BackendBootcamp.Homework.Week2.Service.Services;
using BackendBootcamp.Homework.Week2.Service.Validation.BookDTOsValidator;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<BookCreateRequestDTOValidator>());
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))!.GetName().Name);
    });
});

builder.Services.AddSingleton<RedisService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var redisUrl = configuration.GetValue<string>("Redis:Url");
    return new RedisService(redisUrl!);
});

builder.Services.AddScoped(typeof(NotFoundFilter<,>));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepositoryServiceModule()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
