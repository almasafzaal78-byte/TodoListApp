using SQLite;

namespace TodoListApp.Models;

public enum TodoStatus
{
    Active,
    Paused,
    Completed
}

public class TaskItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public TodoStatus Status { get; set; } = TodoStatus.Active;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public bool IsImportant { get; set; } = false;

    public DateTime? Deadline { get; set; }
}