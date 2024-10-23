using Employee.Service.DTOs.Base;

namespace Employee.Service.DTOs
{
    public class DepartmentFilterDto:FilterDto
    {
        public int? CompanyId { get; set; }
    }
}
