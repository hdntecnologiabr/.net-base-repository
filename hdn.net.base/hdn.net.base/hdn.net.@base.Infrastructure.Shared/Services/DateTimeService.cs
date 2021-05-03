using hdn.net._base.Application.Interfaces;
using System;

namespace hdn.net._base.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
