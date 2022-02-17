using Hdn.Core.Architecture.Domain.Common;

namespace Hdn.Core.Architecture.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
