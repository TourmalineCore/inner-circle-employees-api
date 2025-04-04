﻿using Application.Queries.Contracts;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class WorkingPlanQuery : IWorkingPlanQuery
{
    private readonly EmployeeDbContext _context;

    public WorkingPlanQuery(EmployeeDbContext employeeDbContext)
    {
        _context = employeeDbContext;
    }

    public async Task<WorkingPlan> GetWorkingPlanAsync()
    {
        return await _context.QueryableAsNoTracking<WorkingPlan>().SingleAsync();
    }
}
