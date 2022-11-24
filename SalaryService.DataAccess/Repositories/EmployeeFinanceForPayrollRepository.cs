﻿using Microsoft.EntityFrameworkCore;
using SalaryService.Domain;

namespace SalaryService.DataAccess.Repositories
{
    public class EmployeeFinanceForPayrollRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeFinanceForPayrollRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public Task UpdateAsync(EmployeeFinanceForPayroll employeeFinanceForPayroll, 
            EmployeeFinancialMetrics metrics, 
            EmployeeFinancialMetricsHistory employeeFinancialMetricsHistory)
        {
            _employeeDbContext.Update(employeeFinanceForPayroll);
            _employeeDbContext.Update(metrics);
            _employeeDbContext.Add(employeeFinancialMetricsHistory);
            return _employeeDbContext.SaveChangesAsync();
        }

        public Task<EmployeeFinanceForPayroll> GetByEmployeeIdAsync(long employeeId)
        {
            return _employeeDbContext
                    .Set<EmployeeFinanceForPayroll>()
                    .SingleAsync(x => x.EmployeeId == employeeId);
        }
    }
}
