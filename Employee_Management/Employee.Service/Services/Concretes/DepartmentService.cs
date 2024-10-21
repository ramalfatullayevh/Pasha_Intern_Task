using Employee.Core.Entities;
using Employee.Data.UnitOfWorks;
using Employee.Service.Services.Abstractions;

namespace Employee.Service.Services.Concretes
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task CreateDepartmentAsync(Department department)
        {
            await _unitOfWork.GetRepository<Department>().AddAsync(department);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _unitOfWork.GetRepository<Department>().DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ICollection<Department>> GetAllDepartmentsAsync()
        {
            return await _unitOfWork.GetRepository<Department>().GetAllAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Department>().GetByIdAsync(id);
        }

        public async Task<ICollection<Department>> GetDepartmentsByCompanyIdAsync(int companyId)
        {
            var allDepartments = await _unitOfWork.GetRepository<Department>().GetAllAsync();
            return allDepartments.Where(d => d.CompanyId == companyId).ToList();
        }

        public async Task<ICollection<Employe>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            var allEmployees = await _unitOfWork.GetRepository<Employe>().GetAllAsync();
            return allEmployees.Where(e => e.DepartmentId == departmentId).ToList();
        }

        public async Task<bool> UpdateDepartmentAsync(int id, Department department)
        {
            var existingDepartment = await GetDepartmentByIdAsync(id);
            if (existingDepartment == null) return false;
            existingDepartment.Name = department.Name;
            existingDepartment.CreatedDate = department.CreatedDate;
            existingDepartment.CompanyId = department.CompanyId;
            await _unitOfWork.GetRepository<Department>().UpdateAsync(existingDepartment);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
