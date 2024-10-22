using AutoMapper;
using Employee.Core.Entities;
using Employee.Service.DTOs;

namespace Employee.Service.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Company, CompanyDto>();
        }
    }
}
