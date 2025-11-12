using Core;
using Core.Entities;

namespace Api.Responses;

public class EmployeeProfileResponse
{
  public long Id { get; init; }

  public string FullName { get; init; }

  public string CorporateEmail { get; init; }

  public string BirthDate { get; set; }

  public string? PersonalEmail { get; init; }

  public string? Phone { get; init; }

  public string? GitHub { get; init; }

  public string? GitLab { get; init; }

  public string? WorkerTime { get; set; }

  public List<Specialization>? Specializations { get; set; }

  public EmployeeProfileResponse(Employee employee)
  {
    Id = employee.Id;
    FullName = employee.GetFullName();
    CorporateEmail = employee.CorporateEmail;
    PersonalEmail = employee.PersonalEmail;
    Phone = employee.Phone;
    GitHub = employee.GitHub;
    GitLab = employee.GitLab;
    BirthDate = employee.BirthDate;
    WorkerTime = employee.WorkerTime;
    Specializations = employee.Specializations ?? new List<Specialization>();
  }
}
