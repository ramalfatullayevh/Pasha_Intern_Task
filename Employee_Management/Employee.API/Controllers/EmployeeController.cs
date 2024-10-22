using AutoMapper;
using Employee.Core.Entities;
using Employee.Service.DTOs;
using Employee.Service.Services.Abstractions;
using Employee.Service.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;


        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;   
        }

        // Get All Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
                return Ok(employeesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Get A Employee by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                if (employee == null) return NotFound();
                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Add Employee
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var employee = _mapper.Map<Employe>(employeeDto);
                await _employeeService.AddEmployeeAsync(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Update Employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
                if (existingEmployee == null) return NotFound();
                employeeDto.Id = existingEmployee.Id;
                _mapper.Map(employeeDto, existingEmployee);
                var result = await _employeeService.UpdateEmployeeAsync(id, existingEmployee);
                if (!result) return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Delete Employee
        [HttpDelete("{id}")]
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

        //Get All Filtered Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesWithFilter([FromQuery] EmployeeFilterDto filterDto)
        {
            try
            {
                var employees = await _employeeService.GetFilteredEmployeesAsync(filterDto);
                var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
                return Ok(employeesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }


}
