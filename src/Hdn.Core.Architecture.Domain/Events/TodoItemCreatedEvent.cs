namespace Hdn.Core.Architecture.Domain.Events;

public class TodoItemCreatedEvent : DomainEvent
{
    public TodoItemCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
