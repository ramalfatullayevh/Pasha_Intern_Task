using Employee.Service.DTOs;
using Employee.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        
        public EmployeeController(IEmployeeService employeeService) =>  _employeeService = employeeService;
           

        // Get All Employees
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //Get All Filtered Employees
        [HttpGet("GetEmployeesByFilter")]
        public async Task<IActionResult> GetAllEmployeesWithFilter([FromQuery] EmployeeFilterDto filterDto)
        {
            try
            {
                var employees = await _employeeService.GetFilteredEmployeesAsync(filterDto);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Get A Employee by ID
        [HttpGet("{id}/GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                if (employee == null) return NotFound();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Add Employee
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                await _employeeService.AddEmployeeAsync(employeeDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Update Employee
        [HttpPut("{id}/UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var result = await _employeeService.UpdateEmployeeAsync(id, employeeDto);
                if (!result) return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Delete Employee
        [HttpDelete("{id}/DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

       
    }


}
