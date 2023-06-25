using api.Models.Employees;

namespace api.Repositories.Employees;

public interface IEmployeeAddressRepository {
    EmployeeAddress? GetEmployeeAddressByEmployeeId(int employeeId);
}
