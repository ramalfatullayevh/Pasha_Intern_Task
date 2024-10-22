using Employee.Core.Entities;
using Employee.Service.DTOs;

namespace Employee.Service.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<ICollection<Employe>> GetAllEmployeesAsync();

        Task<Employe> GetEmployeeByIdAsync(int id);

        Task AddEmployeeAsync(Employe employee);

        Task DeleteEmployeeAsync(int id);

        Task<bool> UpdateEmployeeAsync(int id, Employe employee);
        Task<ICollection<Employe>> GetFilteredEmployeesAsync(EmployeeFilterDto filterDto);

    }
}
