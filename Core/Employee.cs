using NodaTime;

namespace Core;

public class Employee : IIdentityEntity
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    public string CorporateEmail { get; set; }

    public string? PersonalEmail { get; set; }

    public string? Phone { get; set; }

    public string? GitHub { get; set; }

    public string? GitLab { get; set; }

    public EmployeeFinancialMetrics? FinancialMetrics { get; set; }

    public Instant? HireDate { get; set; }

    public bool IsBlankEmployee { get; set; }

    public bool IsCurrentEmployee { get; set; }

    public bool IsEmployedOfficially { get; set; }

    public EmployeePersonnelNumber? PersonnelNumber { get; set; }

    public Instant? DeletedAtUtc { get; set; }

    public bool IsSpecial { get; set; }

    public long TenantId { get; set; }

    public Employee(string firstName, string lastName, string middleName, string corporateEmail, long tenantId,
        bool isEmployedOfficially = false)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        CorporateEmail = corporateEmail;
        IsBlankEmployee = true;
        IsCurrentEmployee = false;
        IsEmployedOfficially = isEmployedOfficially;
        TenantId = tenantId;
    }

    public void Delete(Instant deletedAtUtc)
    {
        DeletedAtUtc = deletedAtUtc;
    }

    public void Update(
        string phone,
        string? personalEmail,
        string? gitHub,
        string? gitLab)
    {
        PersonalEmail = personalEmail;
        Phone = phone;
        GitHub = gitHub;
        GitLab = gitLab;
    }

    public void UpdatePersonalInfo(
        string firstName,
        string middleName,
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public void Update(
        string phone,
        string? personalEmail,
        string? gitHub,
        string? gitLab,
        Instant? hireDate,
        bool isEmployedOfficially,
        string? personnelNumber)
    {
        Phone = phone;
        PersonalEmail = personalEmail;
        GitHub = gitHub;
        GitLab = gitLab;
        HireDate = hireDate;
        IsEmployedOfficially = isEmployedOfficially;
        IsBlankEmployee = false;
        IsCurrentEmployee = true;

        if(!IsEmployedOfficially)
        {
            PersonnelNumber = null;
        }

        if(!string.IsNullOrEmpty(personnelNumber))
        {
            PersonnelNumber = new EmployeePersonnelNumber(personnelNumber);
        }
    }

    public void UpdateFinancialMetrics(FinancesForPayroll financesForPayroll, CoefficientOptions coefficients,
        WorkingPlan workingPlan, Instant createdAtUtc)
    {
        FinancialMetrics = new EmployeeFinancialMetrics(
            financesForPayroll,
            IsEmployedOfficially,
            coefficients,
            workingPlan,
            createdAtUtc);
    }

    public string GetFullName()
    {
        return MiddleName == null
            ? $"{LastName} {FirstName}"
            : $"{LastName} {FirstName} {MiddleName}";
    }
}