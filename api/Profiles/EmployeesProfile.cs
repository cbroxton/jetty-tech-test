using api.DTOs.Employees;
using api.Models.Employees;
using AutoMapper;

namespace api.Profiles;

public class EmployeesProfile : Profile {
    public EmployeesProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeAddress, EmployeeAddressDto>();
    }
}
