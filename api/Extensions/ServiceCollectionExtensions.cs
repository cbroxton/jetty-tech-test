using api.Repositories.Employees;
using api.Services.Auth;
using api.Services.Employees;

namespace api.Extensions;

public static class ServiceCollectionExtensions {
    public static void AddCustomServices(this IServiceCollection services) {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeAddressRepository, EmployeeAddressRepository>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmployeeAddressService, EmployeeAddressService>();
    }

    public static void AddCorsRules(this IServiceCollection services) {
        services.AddCors(options =>
            options.AddDefaultPolicy(policy =>
                // not particularly safe but bodges around the issue for purposes of this demo
                policy.AllowAnyOrigin()
            )
        );
    }
}
