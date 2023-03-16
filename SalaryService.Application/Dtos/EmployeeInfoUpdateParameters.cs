﻿namespace SalaryService.Application.Dtos;

public readonly struct EmployeeInfoUpdateParameters
{
    public long EmployeeId { get; init; }

    public string Phone { get; init; }

    public string? PersonalEmail { get; init; }

    public string? GitHub { get; init; }

    public string? GitLab { get; init; }

    public DateTime HireDate { get; init; }

    public bool IsEmployedOfficially { get; init; }

    public string? PersonnelNumber { get; init; }
}