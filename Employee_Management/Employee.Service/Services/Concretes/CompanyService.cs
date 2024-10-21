using Employee.Core.Entities;
using Employee.Data.UnitOfWorks;
using Employee.Service.Services.Abstractions;

namespace Employee.Service.Services.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        

        public async Task CreateCompanyAsync(Company company)
        {
            await _unitOfWork.GetRepository<Company>().AddAsync(company);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _unitOfWork.GetRepository<Company>().DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ICollection<Company>> GetAllCompaniesAsync()
        {
            return await _unitOfWork.GetRepository<Company>().GetAllAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Company>().GetByIdAsync(id);
        }

        public async Task<bool> UpdateCompanyAsync(int id, Company company)
        {
            var existingCompany = await GetCompanyByIdAsync(id);
            if (existingCompany == null) return false;
            existingCompany.Name = company.Name; 
            existingCompany.CreatedDate = company.CreatedDate;  
            await _unitOfWork.GetRepository<Company>().UpdateAsync(existingCompany);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
