using ApiTrottling.Application.Common.Interfaces;

namespace ApiTrottling.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
