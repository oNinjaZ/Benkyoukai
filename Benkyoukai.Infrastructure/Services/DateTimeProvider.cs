using Benkyoukai.Application.Common.Interfaces.Services;

namespace Benkyoukai.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}