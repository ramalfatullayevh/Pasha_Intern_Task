using AutoMapper;
using Employee.Core.Entities;
using Employee.Data.UnitOfWorks;
using Employee.Service.DTOs;
using Employee.Service.Services.Abstractions;

namespace Employee.Service.Services.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        

        public async Task CreateCompanyAsync(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            await _unitOfWork.GetRepository<Company>().AddAsync(company);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _unitOfWork.GetRepository<Company>().DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ICollection<CompanyDto>> GetAllCompaniesAsync()
        {
            var companies = await _unitOfWork.GetRepository<Company>().GetAllAsync();
            return _mapper.Map<ICollection<CompanyDto>>(companies);
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Company>().GetByIdAsync(id);
            
        }

        public async Task<ICollection<Employe>> GetEmployeesByCompanyIdAsync(int companyId)
        {
            var departments = await _unitOfWork.GetRepository<Department>().GetAllAsync();
            var departmentIds = departments.Where(d => d.CompanyId == companyId).Select(d => d.Id).ToList();
            var allEmployees = await _unitOfWork.GetRepository<Employe>().GetAllAsync();
            var employees = allEmployees.Where(e => departmentIds.Contains(e.DepartmentId)).ToList();
            return employees;
        }

        public async Task<bool> UpdateCompanyAsync(int id, CompanyDto companyDto)
        {
            var existingCompany = await GetCompanyByIdAsync(id);
            if (existingCompany == null) return false;
            _mapper.Map(companyDto, existingCompany);
            await _unitOfWork.GetRepository<Company>().UpdateAsync(existingCompany);
            await _unitOfWork.SaveAsync(); 
            return true;
        }
    }
}
