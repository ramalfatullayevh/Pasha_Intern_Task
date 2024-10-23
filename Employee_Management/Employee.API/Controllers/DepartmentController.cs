using AutoMapper;
using Employee.Core.Entities;
using Employee.Service.DTOs;
using Employee.Service.Services.Abstractions;
using Employee.Service.Services.Concretes;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;


        public DepartmentController(IDepartmentService departmentService ) => _departmentService = departmentService;


        // Get All Departments
        [HttpGet]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            try
            {
                var departments = await _departmentService.GetAllDepartmentsAsync();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Get A Department by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentByIdAsync(int id)
        {
            try
            {
                var department = await _departmentService.GetDepartmentByIdAsync(id);
                if (department == null) return NotFound();
                return Ok(department);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Create Department
        [HttpPost]
        public async Task<IActionResult> CreateDepartmentAsync([FromBody] DepartmentDto departmentDto)
        {
            try
            {
                await _departmentService.CreateDepartmentAsync(departmentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Update Department
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartmentAsync(int id, [FromBody] DepartmentDto departmentDto)
        {
            try
            {
                var result = await _departmentService.UpdateDepartmentAsync(id, departmentDto);
                if (!result) return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Delete Department
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentAsync(int id)
        {
            try
            {
                await _departmentService.DeleteDepartmentAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Get All Departments by Company ID
        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetDepartmentsByCompanyIdAsync(int companyId)
        {
            try
            {
                var departments = await _departmentService.GetDepartmentsByCompanyIdAsync(companyId);
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
