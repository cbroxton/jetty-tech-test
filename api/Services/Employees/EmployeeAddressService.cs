using api.DTOs.Employees;
using api.Models.Employees;
using api.Repositories.Employees;
using AutoMapper;

namespace api.Services.Employees;

public class EmployeeAddressService : IEmployeeAddressService
{
    private readonly IEmployeeAddressRepository _employeeAddressRepository;

    private readonly IMapper _mapper;

    public EmployeeAddressService(IEmployeeAddressRepository employeeAddressRepository, IMapper mapper) {
        this._employeeAddressRepository = employeeAddressRepository;
        this._mapper = mapper;
    }

    public EmployeeAddressDto? GetEmployeeAddressByEmployeeId(int employeeId)
    {
        return this._mapper.Map<EmployeeAddress?, EmployeeAddressDto?>(this._employeeAddressRepository.GetEmployeeAddressByEmployeeId(employeeId));
    }
}
