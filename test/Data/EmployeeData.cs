using System.Collections.Generic;
using api.Models.Employees;

namespace test.Data;

public static class EmployeeData {
    public const int VALID_EMPLOYEE_ID = 2;

    public static List<Employee> Data = new() {
        new Employee {
            Id = 1,
            Age = 25,
            FirstName = "John",
            LastName = "Smith"
        },
        new Employee {
            Id = VALID_EMPLOYEE_ID,
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
}
