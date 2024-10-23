using Employee.Service.DTOs.Base;

namespace Employee.Service.DTOs
{
    public class EmployeeFilterDto:FilterDto
    {
        public string? Surname { get; set; }
        public int? DepartmentId { get; set; }
    }
}
