using Autofac;
using BackendBootcamp.Homework.Week2.Core.Repositories;
using BackendBootcamp.Homework.Week2.Service.Services;
using BackendBootcamp.Homework.Week2.Core.UnitOfWorks;
using BackendBootcamp.Homework.Week2.Repository.Repositories;
using System.Reflection;
using BackendBootcamp.Homework.Week2.Repository.UnitOfWork;
using BackendBootcamp.Homework.Week2.Repository;
using BackendBootcamp.Homework.Week2.Service.Mapping;
using BackendBootcamp.Homework.Week2.Core.Services;
using Module = Autofac.Module;

namespace BackendBootcamp.Homework.Week2.API.Modules
{
    public class RepositoryServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<,>)).As(typeof(IService<,>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();


            var repositoryAssembly = Assembly.GetAssembly(typeof(AppDbContext))!;
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile))!;

            builder.RegisterAssemblyTypes(repositoryAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(repositoryAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
