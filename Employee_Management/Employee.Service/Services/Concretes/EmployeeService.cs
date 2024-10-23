using AutoMapper;
using Employee.Core.Entities;
using Employee.Data.UnitOfWorks;
using Employee.Service.DTOs;
using Employee.Service.Services.Abstractions;

namespace Employee.Service.Services.Concretes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public async Task AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employe>(employeeDto);
            await _unitOfWork.GetRepository<Employe>().AddAsync(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _unitOfWork.GetRepository<Employe>().DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ICollection<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _unitOfWork.GetRepository<Employe>().GetAllAsync();
            return _mapper.Map<ICollection<EmployeeDto>>(employees);
        }

        public async Task<Employe> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Employe>().GetByIdAsync(id);
        }

        public async Task<ICollection<Employe>> GetFilteredEmployeesAsync(EmployeeFilterDto filterDto)
        {
            var employees = await _unitOfWork.GetRepository<Employe>().GetAllAsync();

            if (!string.IsNullOrWhiteSpace(filterDto.Name)) employees = employees
                    .Where(e => e.Name.Contains(filterDto.Name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            
            if (!string.IsNullOrWhiteSpace(filterDto.Surname))  employees = employees
                    .Where(e => e.Surname.Contains(filterDto.Surname, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            

            if (filterDto.DepartmentId.HasValue)
                employees = employees.Where(e => e.DepartmentId == filterDto.DepartmentId.Value).ToList();

            if (filterDto.CreatedDate != null) employees = employees
                    .Where(e => e.CreatedDate.Date == filterDto.CreatedDate.Value.Date)
                    .ToList();

            if (filterDto.BirthDate != null) employees = employees
                    .Where(e => e.CreatedDate.Date == filterDto.BirthDate.Value.Date)
                    .ToList();


            return employees
                .Skip((filterDto.PageNumber - 1) * filterDto.PageSize)
                .Take(filterDto.PageSize)
                .ToList();
        }

        public async Task<bool> UpdateEmployeeAsync(int id, EmployeeDto employeeDto)
        {
            var existingEmployee = await GetEmployeeByIdAsync(id);
            if (existingEmployee == null) return false;
            _mapper.Map(employeeDto, existingEmployee);
            await _unitOfWork.GetRepository<Employe>().UpdateAsync(existingEmployee);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
