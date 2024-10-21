using Employee.Core.Entities;

namespace Employee.Service.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ICollection<Department>> GetAllDepartmentsAsync();

        Task<Department> GetDepartmentByIdAsync(int id);

        Task CreateDepartmentAsync(Department department);

        Task DeleteDepartmentAsync(int id);

        Task<bool> UpdateDepartmentAsync(int id, Department department);
        Task<ICollection<Department>> GetDepartmentsByCompanyIdAsync(int companyId);
        Task<ICollection<Employe>> GetEmployeesByDepartmentIdAsync(int departmentId);  


    }
}
