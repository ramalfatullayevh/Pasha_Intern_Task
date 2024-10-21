using Employee.Core.Entities;
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
        [HttpGet]
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

        // Get Company By ID
        [HttpGet("{id}")]
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
        [HttpPost]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] Company company)
        {
            try
            {
                await _companyService.CreateCompanyAsync(company);
                return CreatedAtAction(nameof(GetCompanyByIdAsync), new { id = company.Id }, company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Update Company
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanyAsync(int id, [FromBody] Company company)
        {
            try
            {
                var result = await _companyService.UpdateCompanyAsync(id, company);
                if (!result) return NotFound("Company not found.");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Delete Company
        [HttpDelete("{id}")]
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
