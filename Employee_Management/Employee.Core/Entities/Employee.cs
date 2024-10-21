﻿using Employee.Core.Base;

namespace Employee.Core.Entities
{
    public class Employee:BaseEntity
    {
        public int DepartmentId { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; } 
    }
}
