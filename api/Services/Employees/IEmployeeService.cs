using api.DTOs.Employees;

namespace api.Services.Employees;

public interface IEmployeeService {
    EmployeeDto? GetEmployeeById(int id);
}
