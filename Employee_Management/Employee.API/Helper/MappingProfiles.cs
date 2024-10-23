using AutoMapper;
using Employee.Core.Entities;
using Employee.Service.DTOs;

namespace Employee.Service.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Company, CompanyDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            CreateMap<Department, DepartmentDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
            CreateMap<Employe, EmployeeDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 

        }
    }
}
