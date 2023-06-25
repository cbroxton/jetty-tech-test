using api.Models.Employees;

namespace api.Repositories.Employees;

public interface IEmployeeRepository {
    Employee? GetEmployeeById(int id);
}
