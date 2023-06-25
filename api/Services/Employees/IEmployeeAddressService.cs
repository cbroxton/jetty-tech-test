using api.DTOs.Employees;

namespace api.Services.Employees;

public interface IEmployeeAddressService {
    EmployeeAddressDto? GetEmployeeAddressByEmployeeId(int employeeId);
}
