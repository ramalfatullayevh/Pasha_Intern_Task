﻿namespace Employee.Service.DTOs
{
    public class EmployeeFilterDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? DepartmentId { get; set; }
        public int PageNumber { get; set; } = 1; //default value
        public int PageSize { get; set; } = 10; //default value
    }
}
