using Core;
using Core.Entities;

namespace Api.Responses;

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

  public List<Specialization> Specialization { get; init; }

  public string? BirthDate { get; init; }

  public string? WorkerTime { get; init; }

  public EmployeeResponse(Employee employee)
  {
    EmployeeId = employee.Id;
    FullName = employee.GetFullName();
    CorporateEmail = employee.CorporateEmail;
    PersonalEmail = employee.PersonalEmail;
    Phone = employee.Phone;
    GitHub = employee.GitHub;
    GitLab = employee.GitLab; 
    BirthDate = employee.BirthDate;
    Specialization = employee.Specialization ?? new List<Specialization>();
    WorkerTime = employee.WorkerTime;

    IsBlankEmployee = employee.IsBlankEmployee;
    IsCurrentEmployee = employee.IsCurrentEmployee;
  }
}
