using Employee.Service.DTOs.Base;

namespace Employee.Service.DTOs
{
    public class EmployeeDto:BaseDto
    {
        public int DepartmentId { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }


    }
}
