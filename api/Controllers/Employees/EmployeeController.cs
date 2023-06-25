using api.DTOs.Employees;
using api.Services.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Employees;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase {
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService) {
        this._employeeService = employeeService;
    }

    [HttpGet("{employeeId}")]
    [Authorize]
    public ActionResult<EmployeeDto> GetEmployeeById(int employeeId) {
        EmployeeDto? employee = this._employeeService.GetEmployeeById(employeeId);

        if (employee is null) {
            return NotFound();
        }

        return Ok(employee);
    }
}
