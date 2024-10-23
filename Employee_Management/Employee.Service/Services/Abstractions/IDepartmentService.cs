using Employee.Core.Entities;
using Employee.Service.DTOs;

namespace Employee.Service.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ICollection<DepartmentDto>> GetAllDepartmentsAsync();

        Task<Department> GetDepartmentByIdAsync(int id);

        Task CreateDepartmentAsync(DepartmentDto departmentDto);

        Task DeleteDepartmentAsync(int id);

        Task<bool> UpdateDepartmentAsync(int id, DepartmentDto departmentDto);
        Task<ICollection<Department>> GetDepartmentsByCompanyIdAsync(int companyId);
        Task<ICollection<Employe>> GetEmployeesByDepartmentIdAsync(int departmentId);  


    }
}
