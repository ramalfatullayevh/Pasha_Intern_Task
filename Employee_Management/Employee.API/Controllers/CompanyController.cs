using AutoMapper;
using Employee.Core.Entities;
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
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService; 
            _mapper = mapper;
        }

        // Get All Companies
        [HttpGet]
        public async Task<IActionResult> GetAllCompaniesAsync()
        {
            try
            {
                var companies = await _companyService.GetAllCompaniesAsync();
                var companyDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                return Ok(companyDto);
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
                var companyDto = _mapper.Map<CompanyDto>(company);
                return Ok(companyDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Create Company
        [HttpPost]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyDto companyDto)
        {
            try
            {
                var company = _mapper.Map<Company>(companyDto);
                await _companyService.CreateCompanyAsync(company);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // Update Company
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanyAsync(int id, [FromBody] CompanyDto companyDto)
        {
            try
            {
                var existingCompany = await _companyService.GetCompanyByIdAsync(id);
                if (existingCompany == null) return NotFound();

                companyDto.Id = existingCompany.Id;

                _mapper.Map(companyDto, existingCompany);

                var result = await _companyService.UpdateCompanyAsync(id, existingCompany);
                if (!result) return NotFound();

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
