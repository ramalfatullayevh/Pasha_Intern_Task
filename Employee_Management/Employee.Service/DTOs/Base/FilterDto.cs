namespace Employee.Service.DTOs.Base
{
    public class FilterDto
    {
        public string? Name { get; set; }
        public int PageNumber { get; set; } = 1; //default value
        public int PageSize { get; set; } = 10; //default value
    }
}
