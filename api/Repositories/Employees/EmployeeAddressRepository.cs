using api.Models.Employees;

namespace api.Repositories.Employees;

public class EmployeeAddressRepository : IEmployeeAddressRepository {
    // spec didn't mention a db so have done this in memory to save time
    private readonly static List<EmployeeAddress> EmployeeAddresses = new() {
        new EmployeeAddress {
            Id = 1,
            EmployeeId = 1,
            City = "city1",
            StreetAddress = "address1"
        },
        new EmployeeAddress {
            Id = 2,
            EmployeeId = 2,
            City = "city2",
            StreetAddress = "address2"
        },
        new EmployeeAddress {
            Id = 3,
            EmployeeId = 3,
            City = "city3",
            StreetAddress = "address3"
        }
    };

    public EmployeeAddress? GetEmployeeAddressByEmployeeId(int employeeId) {
        return EmployeeAddresses.FirstOrDefault(employeeAddress => employeeAddress.EmployeeId == employeeId);
    }
}
