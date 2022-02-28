namespace Hdn.Core.Architecture.Domain.Entities;

public class TodoItemEntity : AuditableEntity
{
    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    public TodoListEntity List { get; set; } = null!;
}
