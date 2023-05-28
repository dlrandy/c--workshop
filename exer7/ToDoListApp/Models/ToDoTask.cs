using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class ToDoTask
{
    public Guid Id { get; set; }

    [DisplayName("Created At")]
    public DateTime CreatedAt { get; set; }
    [DisplayName("Due Date")]
    [Required]
    public DateTime? DueTo { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public ETaskStatus Status { get; set; }
    public ToDoTask()
    {
        CreatedAt = DateTime.UtcNow;
        Id = Guid.NewGuid();
    }
    public ToDoTask(string title, ETaskStatus status) : this()
    {
        Title = title;
        Status = status;
    }
}