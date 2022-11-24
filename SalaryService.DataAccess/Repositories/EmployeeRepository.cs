﻿using Microsoft.EntityFrameworkCore;
using SalaryService.Domain;

namespace SalaryService.DataAccess.Repositories
{
    public class EmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        
        public async Task<Employee> CreateAsync(Employee employee)
        {
            await _employeeDbContext.AddAsync(employee);
            await _employeeDbContext.SaveChangesAsync();

            return employee;
        }

        public Task<Employee> GetByIdAsync(long employeeId)
        {
            return _employeeDbContext
                    .Set<Employee>()
                    .Include(x => x.EmployeeFinanceForPayroll)
                    .Include(x => x.EmployeeFinancialMetrics)
                    .SingleAsync(x => x.Id == employeeId && x.DeletedAtUtc == null);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeDbContext
                .QueryableAsNoTracking<Employee>()
                .Where(x => x.DeletedAtUtc == null)
                .Include(x => x.EmployeeFinanceForPayroll)
                .Include(x => x.EmployeeFinancialMetrics)
                .ToListAsync();
        }

        public Task UpdateAsync(Employee employee)
        {
            _employeeDbContext.Update(employee);
            return _employeeDbContext.SaveChangesAsync();
        }

        public Task DeleteEmployeeAsync(Employee employee, 
            EmployeeFinanceForPayroll employeeFinanceForPayroll, 
            EmployeeFinancialMetrics employeeFinancialMetrics,
            EmployeeFinancialMetricsHistory employeeFinancialMetricsHistory)
        {
            _employeeDbContext.Add(employeeFinancialMetricsHistory);
            _employeeDbContext.Remove(employeeFinancialMetrics);
            _employeeDbContext.Remove(employeeFinanceForPayroll);
            _employeeDbContext.Update(employee);
            return _employeeDbContext.SaveChangesAsync();
        }
    }
}
