using Employee.Core.Entities;
using Employee.Data.UnitOfWorks;
using Employee.Service.Services.Abstractions;

namespace Employee.Service.Services.Concretes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task AddEmployeeAsync(Employe employee)
        {
            await _unitOfWork.GetRepository<Employe>().AddAsync(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _unitOfWork.GetRepository<Employe>().DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ICollection<Employe>> GetAllEmployeesAsync()
        {
            return await _unitOfWork.GetRepository<Employe>().GetAllAsync();
        }

        public async Task<Employe> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Employe>().GetByIdAsync(id);
        }

        public async Task<bool> UpdateEmployeeAsync(int id, Employe employee)
        {
            var existingEmployee = await GetEmployeeByIdAsync(id);
            if (existingEmployee == null) return false;
            existingEmployee.Name = employee.Name;
            existingEmployee.Surname = employee.Surname;
            existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.BirthDate = employee.BirthDate;
            existingEmployee.CreatedDate = employee.CreatedDate;
            await _unitOfWork.GetRepository<Employe>().UpdateAsync(existingEmployee);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
