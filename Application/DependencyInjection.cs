using Application.Commands;
using Application.Queries;
using Application.Queries.Contracts;
using Application.Services;
using Application.Transactions;
using Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;

namespace Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddTransient<IEmployeesQuery, EmployeesQuery>();
    services.AddTransient<IWorkingPlanQuery, WorkingPlanQuery>();
    services.AddTransient<EmployeeCreationCommand>();
    services.AddTransient<EmployeeDeletionCommand>();
    services.AddTransient<ProfileUpdateCommand>();
    services.AddTransient<EmployeesService>();
    services.AddScoped<EmployeeUpdateParametersValidator>();
    services.AddTransient<IClock, Clock>();
    services.AddTransient<EmployeeUpdateTransaction>();
    services.AddTransient<EmployeeQuery>();
    services.AddTransient<EmployeesForAnalyticsQuery>();
    services.AddTransient<CurrentEmployeesQuery>();
    services.AddTransient<EmployeePersonalInformationUpdateCommand>();
    services.AddTransient<GetEmployeesByIdsQuery>();
    services.AddScoped<ProfileUpdatingParametersValidator>();

    return services;
  }
}
