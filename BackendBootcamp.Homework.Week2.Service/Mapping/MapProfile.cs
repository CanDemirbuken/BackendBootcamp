using AutoMapper;
using BackendBootcamp.Homework.Week2.Core.DTOs.BookDTOs;
using BackendBootcamp.Homework.Week2.Core.DTOs.CustomerDTOs;
using BackendBootcamp.Homework.Week2.Core.DTOs.EmployeeDTOs;
using BackendBootcamp.Homework.Week2.Core.Entities;

namespace BackendBootcamp.Homework.Week2.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookCreateRequestDTO>().ReverseMap();
            CreateMap<Book, BookUpdateRequestDTO>().ReverseMap();

            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomerCreateRequestDTO>().ReverseMap();
            CreateMap<Customer, CustomerUpdateRequestDTO>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeCreateRequestDTO>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateRequestDTO>().ReverseMap();
        }
    }
}
