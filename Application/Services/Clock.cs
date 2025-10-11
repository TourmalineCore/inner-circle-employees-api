using NodaTime;

namespace Application.Services;

public class Clock : IClock
{
  public Instant GetCurrentInstant()
  {
    return Instant.FromDateTimeUtc(DateTime.UtcNow);
  }
}
