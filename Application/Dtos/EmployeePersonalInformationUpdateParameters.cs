namespace Application.Dtos;

public readonly struct EmployeePersonalInformationUpdateParameters
{
    public string CorporateEmail { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string? MiddleName { get; init; }

}
