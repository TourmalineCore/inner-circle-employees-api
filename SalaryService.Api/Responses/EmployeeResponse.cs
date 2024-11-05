﻿using SalaryService.Domain;

namespace SalaryService.Api.Responses;

public class EmployeeResponse
{
    public long EmployeeId { get; init; }

    public string FullName { get; init; }

    public string CorporateEmail { get; init; }

    public string? PersonalEmail { get; init; }

    public string? Phone { get; init; }

    public string? GitHub { get; init; }

    public string? GitLab { get; init; }

    public bool? IsBlankEmployee { get; init; }

    public bool? IsCurrentEmployee { get; init; }

    public bool? IsEmployedOfficially { get; init; }

    public decimal? NetSalary { get; init; }

    public decimal? RatePerHour { get; init; }

    public decimal? FullSalary { get; init; }

    public decimal? EmploymentType { get; init; }

    public decimal? Parking { get; init; }

    public string? PersonnelNumber { get; init; }

    public DateTime? HireDate { get; init; }

    public EmployeeResponse(Employee employee, bool includeSalaryAndDocumentData = false)
    {
        EmployeeId = employee.Id;
        FullName = employee.GetFullName();
        CorporateEmail = employee.CorporateEmail;
        PersonalEmail = employee.PersonalEmail;
        Phone = employee.Phone;
        GitHub = employee.GitHub;
        GitLab = employee.GitLab;

        if (!includeSalaryAndDocumentData) return;

        IsBlankEmployee = employee.IsBlankEmployee;
        IsCurrentEmployee = employee.IsCurrentEmployee;
        IsEmployedOfficially = employee.IsEmployedOfficially;

        if (employee.FinancialMetrics != null)
        {
            NetSalary = Math.Round(employee.FinancialMetrics.NetSalary, 2);
            RatePerHour = Math.Round(employee.FinancialMetrics.RatePerHour, 2);
            FullSalary = Math.Round(employee.FinancialMetrics.Pay, 2);
            Parking = Math.Round(employee.FinancialMetrics.ParkingCostPerMonth, 2);
            EmploymentType = employee.FinancialMetrics.EmploymentType;
        }

        if (employee.PersonnelNumber != null)
        {
            PersonnelNumber = employee.PersonnelNumber.ToString();
        }

        HireDate = employee.HireDate?.ToDateTimeUtc();
    }
}
