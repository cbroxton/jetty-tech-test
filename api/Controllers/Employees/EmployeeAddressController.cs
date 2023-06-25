using api.DTOs.Employees;
using api.Services.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Employees;

[ApiController]
// Have structured like this whereby the controller route will be employee-address but our endpoint overrides. As assuming future scenarios
// might have an i.e. /employee-address/{id} endpoint for getting a specific address by ID in which case this separate controller makes sense.
[Route("[controller]")]
public class EmployeeAddressController : ControllerBase {
    private readonly IEmployeeAddressService _employeeAddressService;

    public EmployeeAddressController(IEmployeeAddressService employeeAddressService) {
        this._employeeAddressService = employeeAddressService;
    }

    [HttpGet("/employee/{employeeId}/address")]
    [Authorize]
    public ActionResult<EmployeeAddressDto> GetEmployeeAddressByEmployeeId(int employeeId) {
        EmployeeAddressDto? employeeAddressDto = this._employeeAddressService.GetEmployeeAddressByEmployeeId(employeeId);

        if (employeeAddressDto is null) {
            return NotFound();
        }

        return Ok(employeeAddressDto);
    }
}
