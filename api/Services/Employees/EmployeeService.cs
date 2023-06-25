using api.DTOs.Employees;
using api.Models.Employees;
using api.Repositories.Employees;
using AutoMapper;

namespace api.Services.Employees;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) {
        this._employeeRepository = employeeRepository;
        this._mapper = mapper;
    }

    public EmployeeDto? GetEmployeeById(int id)
    {
        return this._mapper.Map<Employee?, EmployeeDto?>(this._employeeRepository.GetEmployeeById(id));
    }
}
