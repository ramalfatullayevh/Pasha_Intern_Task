using Employee.Core.Entities;
using Employee.Service.DTOs;

namespace Employee.Service.Services.Abstractions
{
    public interface ICompanyService
    {
        Task<ICollection<CompanyDto>> GetAllCompaniesAsync();

        Task<Company> GetCompanyByIdAsync(int id);

        Task CreateCompanyAsync(CompanyDto companyDto);

        Task DeleteCompanyAsync(int id);

        Task<bool> UpdateCompanyAsync(int id, CompanyDto companyDto); 
        Task<ICollection<Employe>> GetEmployeesByCompanyIdAsync(int companyId);

        Task<ICollection<Company>> GetFilteredCompaniesAsync(CompanyFilterDto filterDto);
    }
}
