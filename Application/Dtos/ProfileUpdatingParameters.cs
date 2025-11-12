using Core.Entities;

namespace Application.Dtos;

public readonly struct ProfileUpdatingParameters
{
  public string Phone { get; init; }

  public List<Specialization> Specializations { get; init; }

  public string? PersonalEmail { get; init; }

  public string? GitHub { get; init; }

  public string? GitLab { get; init; }

  public string? WorkerTime { get; init; }
}
