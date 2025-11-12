using Core.Entities;
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

  public string? BirthDate { get; set; }

  public string? WorkerTime { get; set; }

  public List<Specialization>? Specializations { get; set; }

  public bool IsBlankEmployee { get; set; }

  public bool IsCurrentEmployee { get; set; }

  public Instant? DeletedAtUtc { get; set; }

  public bool IsSpecial { get; set; }

  public long TenantId { get; set; }

  public Employee(
    string firstName,
    string lastName,
    string middleName,
    string corporateEmail,
    long tenantId
  )
  {
    FirstName = firstName;
    LastName = lastName;
    MiddleName = middleName;
    CorporateEmail = corporateEmail;
    IsBlankEmployee = true;
    IsCurrentEmployee = false;
    TenantId = tenantId;
  }

  public void Delete(Instant deletedAtUtc)
  {
    DeletedAtUtc = deletedAtUtc;
  }

  public void Update(
    string phone,
    string birthDate,
    List<Specialization> specializations,
    string? personalEmail,
    string? gitHub,
    string? gitLab,
    string? workerTime
  )
  {
    PersonalEmail = personalEmail;
    Phone = phone;
    GitHub = gitHub;
    GitLab = gitLab;
    WorkerTime = workerTime;
    BirthDate = birthDate;
    Specializations = specializations;
  }

  public void UpdateProfile(
   string phone,
   List<Specialization> specializations,
   string? personalEmail,
   string? gitHub,
   string? gitLab,
   string? workerTime
  )
  {
    PersonalEmail = personalEmail;
    Phone = phone;
    GitHub = gitHub;
    GitLab = gitLab;
    WorkerTime = workerTime;
    Specializations = specializations;
  }

  public void UpdatePersonalInfo(
    string firstName,
    string middleName,
    string lastName
  )
  {
    FirstName = firstName;
    LastName = lastName;
    MiddleName = middleName;
  }

  public string GetFullName()
  {
    return MiddleName == null
      ? $"{LastName} {FirstName}"
      : $"{LastName} {FirstName} {MiddleName}";
  }
}
