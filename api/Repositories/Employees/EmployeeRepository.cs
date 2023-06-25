using api.Models.Employees;

namespace api.Repositories.Employees;

public class EmployeeRepository : IEmployeeRepository {
    private readonly static List<Employee> Employees = new() {
        new Employee {
            Id = 1,
            Age = 25,
            FirstName = "John",
            LastName = "Smith"
        },
        new Employee {
            Id = 2,
            Age = 35,
            FirstName = "Dave",
            LastName = "Wicke"
        },
        new Employee {
            Id = 3,
            Age = 29,
            FirstName = "Connor",
            LastName = "Broxton"
        }
    };

    public Employee? GetEmployeeById(int id) {
        return Employees.FirstOrDefault(employee => employee.Id == id);
    }
}
