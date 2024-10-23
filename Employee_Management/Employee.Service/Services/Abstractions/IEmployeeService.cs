using Employee.Core.Entities;
using Employee.Service.DTOs;

namespace Employee.Service.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<ICollection<EmployeeDto>> GetAllEmployeesAsync();

        Task<Employe> GetEmployeeByIdAsync(int id);

        Task AddEmployeeAsync(EmployeeDto employeeDto);

        Task DeleteEmployeeAsync(int id);

        Task<bool> UpdateEmployeeAsync(int id, EmployeeDto employeeDto);
        Task<ICollection<Employe>> GetFilteredEmployeesAsync(EmployeeFilterDto filterDto);

    }
}
