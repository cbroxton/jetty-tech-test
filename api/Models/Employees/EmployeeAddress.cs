namespace api.Models.Employees;

public class EmployeeAddress {
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string? StreetAddress { get; set; }

    public string? City { get; set; }
}
