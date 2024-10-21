using Employee.Core.Entities;

namespace Employee.Service.Services.Abstractions
{
    public interface ICompanyService
    {
        Task<ICollection<Company>> GetAllCompaniesAsync();

        Task<Company> GetCompanyByIdAsync(int id);

        Task CreateCompanyAsync(Company company);

        Task DeleteCompanyAsync(int id);

        Task<bool> UpdateCompanyAsync(int id, Company company);
    }
}
