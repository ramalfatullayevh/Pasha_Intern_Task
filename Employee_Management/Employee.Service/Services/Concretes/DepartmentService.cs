using AutoMapper;
using Employee.Core.Entities;
using Employee.Data.UnitOfWorks;
using Employee.Service.DTOs;
using Employee.Service.Services.Abstractions;

namespace Employee.Service.Services.Concretes
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateDepartmentAsync(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            await _unitOfWork.GetRepository<Department>().AddAsync(department);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _unitOfWork.GetRepository<Department>().DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ICollection<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _unitOfWork.GetRepository<Department>().GetAllAsync();
            return _mapper.Map<ICollection<DepartmentDto>>(departments);
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Department>().GetByIdAsync(id);
        }

        public async Task<ICollection<Department>> GetDepartmentsByCompanyIdAsync(int companyId)
        {
            var allDepartments = await _unitOfWork.GetRepository<Department>().GetAllAsync();
            return allDepartments.Where(d => d.CompanyId == companyId).ToList();
        }

        public async Task<ICollection<Employe>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            var allEmployees = await _unitOfWork.GetRepository<Employe>().GetAllAsync();
            return allEmployees.Where(e => e.DepartmentId == departmentId).ToList();
        }

        public async Task<ICollection<Department>> GetFilteredDepartmentsAsync(DepartmentFilterDto filterDto)
        {
            var departments = await _unitOfWork.GetRepository<Department>().GetAllAsync();

            if (!string.IsNullOrWhiteSpace(filterDto.Name)) departments = departments
                    .Where(e => e.Name.Contains(filterDto.Name, StringComparison.OrdinalIgnoreCase))
                    .ToList();


            if (filterDto.CompanyId.HasValue)
                departments = departments.Where(e => e.CompanyId == filterDto.CompanyId.Value).ToList();

            if (filterDto.CreatedDate != null) departments = departments
                    .Where(e => e.CreatedDate.Date == filterDto.CreatedDate.Value.Date)
                    .ToList();

            return departments
                .Skip((filterDto.PageNumber - 1) * filterDto.PageSize)
                .Take(filterDto.PageSize)
                .ToList();
        }

        public async Task<bool> UpdateDepartmentAsync(int id, DepartmentDto departmentDto)
        {
            var existingDepartment = await GetDepartmentByIdAsync(id);
            if (existingDepartment == null) return false;
            _mapper.Map(departmentDto, existingDepartment);
            await _unitOfWork.GetRepository<Department>().UpdateAsync(existingDepartment);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
