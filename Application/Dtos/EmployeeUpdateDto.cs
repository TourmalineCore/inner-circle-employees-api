using Core.Entities;

namespace Application.Dtos;

public class EmployeeUpdateDto
{
  public long EmployeeId { get; init; }

  public string Phone { get; init; }

  public List<Specialization> Specialization { get; init; }

  public string BirthDate { get; init; }

  public string? WorkerTime { get; init; }

  public string? PersonalEmail { get; init; }

  public string? GitHub { get; init; }

  public string? GitLab { get; init; }
}
