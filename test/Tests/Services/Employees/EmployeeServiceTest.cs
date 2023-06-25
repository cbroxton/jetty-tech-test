using api.DTOs.Employees;
using api.Models.Employees;
using api.Profiles;
using api.Repositories.Employees;
using api.Services.Employees;
using AutoMapper;
using FluentAssertions;
using Moq;
using test.Data;

namespace test.Tests.Services.Employees;

// not a full set of tests for all classes etc but should hopefully demo key concepts.
public class EmployeeServiceTest
{
    private readonly EmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeeServiceTest() {
        var mockEmployeeRepository = new Mock<IEmployeeRepository>();
        mockEmployeeRepository
            .Setup(employeeRepository => employeeRepository.GetEmployeeById(It.IsAny<int>()))
            .Returns((int employeeId) => EmployeeData.Data.FirstOrDefault(employee => employee.Id == employeeId));

        var config = new MapperConfiguration(config => config.AddProfile<EmployeesProfile>());
        _mapper = config.CreateMapper();

        _employeeService = new EmployeeService(mockEmployeeRepository.Object, this._mapper);
    }

    [Fact]
    public void GetEmployeeById_WhenEmployeeExists_ShouldReturnCorrectEmployee() {
        int employeeId = EmployeeData.VALID_EMPLOYEE_ID;
        EmployeeDto expected = _mapper.Map<Employee, EmployeeDto>(EmployeeData.Data.First(employee => employee.Id == employeeId));

        EmployeeDto? result = this._employeeService.GetEmployeeById(employeeId);

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GetEmployeeById_WhenEmployeeDoesNotExist_ShouldReturnNull() {
        EmployeeDto? result = this._employeeService.GetEmployeeById(99999);

        Assert.Null(result);
    }
}
