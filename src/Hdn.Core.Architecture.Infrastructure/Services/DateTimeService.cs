using Hdn.Core.Architecture.Application.Common.Interfaces;

namespace Hdn.Core.Architecture.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
