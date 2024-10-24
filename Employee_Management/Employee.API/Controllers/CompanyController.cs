using Employee.Service.DTOs;
using Employee.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService) => _companyService = companyService; 

        // Get All Companies
        [HttpGet("GetAllCompanies")]
        public async Task<IActionResult> GetAllCompaniesAsync()
        {
            try
            {
                var companies = await _companyService.GetAllCompaniesAsync();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //Get All Filtered Compainies
        [HttpGet("GetCompaniesByFilter")]
        public async Task<IActionResult> GetAllCompaniesWithFilter([FromQuery] CompanyFilterDto filterDto)
        {
            try
            {
                var companies = await _companyService.GetFilteredCompaniesAsync(filterDto);
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //GetEmployeeByCompanyId
        [HttpGet("/GetEmployeesByCompanyId")]
        public async Task<IActionResult> GetEmployeesByCompanyId(int companyId)
        {
            try
            {
                var employees = await _companyService.GetEmployeesByCompanyIdAsync(companyId);
                if (employees == null || employees.Count == 0) return NotFound();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Get Company By ID
        [HttpGet("{id}/GetCompanyById")]
        public async Task<IActionResult> GetCompanyByIdAsync(int id)
        {
            try
            {
                var company = await _companyService.GetCompanyByIdAsync(id);
                if (company == null) return NotFound("Company not found.");
                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Create Company
        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyDto companyDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                await _companyService.CreateCompanyAsync(companyDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Update Company
        [HttpPut("{id}/UpdateCompany")]
        public async Task<IActionResult> UpdateCompanyAsync(int id, [FromBody] CompanyDto companyDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _companyService.UpdateCompanyAsync(id, companyDto);
                if (!result) return NotFound("Company not found.");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Delete Company
        [HttpDelete("{id}/DeleteCompany")]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            try
            {
                await _companyService.DeleteCompanyAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }



    }
}
