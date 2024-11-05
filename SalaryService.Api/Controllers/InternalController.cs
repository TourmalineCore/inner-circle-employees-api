﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using SalaryService.Api.Models;
using SalaryService.Application.Dtos;
using SalaryService.Application.Services;
using TourmalineCore.AspNetCore.JwtAuthentication.Core.Filters;

namespace SalaryService.Api.Controllers;

[Route("internal")]
[ApiController]
public class InternalController : ControllerBase
{
    private const int CreatedStatusCode = (int)HttpStatusCode.Created;
    private const int InternalServerErrorCode = (int)HttpStatusCode.InternalServerError;

    private readonly EmployeesService _employeeService;

    public InternalController(EmployeesService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("create-employee")]
    public async Task<ActionResult> CreateEmployeeAsync([FromBody] EmployeeCreationParameters employeeCreationParameters)
    {
        try
        {
            await _employeeService.CreateAsync(employeeCreationParameters);
            return StatusCode(CreatedStatusCode);
        }
        catch (Exception ex)
        {
            var message = ex.InnerException != null 
                ? ex.InnerException.Message 
                : ex.Message;

            return Problem(message, null, InternalServerErrorCode);
        }
    }

    [RequiresPermission(UserClaimsProvider.IsAccountsHardDeleteAllowed)]
    [HttpDelete("delete-employee")]
    public async Task DeleteEmployeeAsync([FromBody] EmployeeDeletionParameters employeeDeletionParameters)
    {
        await _employeeService.DeleteAsync(employeeDeletionParameters);
    }

    [HttpGet("get-employee")]
    public async Task<EmployeeDto> GetEmployeeByCorporateEmailAsync([FromQuery] string corporateEmail)
    {
        var employee = await _employeeService.GetByCorporateEmailAsync(corporateEmail);
        return new EmployeeDto(employee);
    }

    [HttpGet("get-employees")]
    public async Task<List<EmployeeDto>> GetEmployeesAsync([FromQuery] long tenantId)
    {
        var employees = await _employeeService.GetAllAsync(tenantId);
        return employees
            .Select(x => new EmployeeDto(x))
            .ToList();
    }
}
