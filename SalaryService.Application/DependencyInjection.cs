﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using SalaryService.Application.Commands;
using SalaryService.Application.Queries;
using SalaryService.Application.Services;

namespace SalaryService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<GetColleaguesQueryHandler>();
            services.AddTransient<GetEmployeeQueryHandler>();
            services.AddTransient<GetAnalyticQueryHandler>();
            services.AddTransient<GetTotalFinancesQueryHandler>();
            services.AddTransient<GetCoefficientsQueryHandler>();
            services.AddTransient<GetFinancialMetricsQueryHandler>();
            services.AddTransient<CreateEmployeeCommandHandler>();
            services.AddTransient<UpdateEmployeeCommandHandler>();
            services.AddTransient<UpdateFinancesCommandHandler>();
            services.AddTransient<DeleteEmployeeCommandHandler>();
            services.AddTransient<CalculatePreviewMetricsCommandHandler>();
            services.AddTransient<CalculateTotalExpensesCommandHandler>();
            services.AddTransient<EmployeeService>();
            services.AddTransient<FinanceAnalyticService>();
            services.AddTransient<IClock, Clock>();
            return services;
        }
    }
}
