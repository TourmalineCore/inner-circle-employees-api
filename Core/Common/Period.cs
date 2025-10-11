using NodaTime;

namespace Core.Common;

public class Period
{
  public Instant FromUtc { get; set; }
  public Instant? ToUtc { get; set; }

  public Period(Instant fromUtc, Instant? toUtc)
  {
    FromUtc = fromUtc;
    ToUtc = toUtc;
  }
}
