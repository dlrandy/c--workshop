using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToDoListApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IList<ToDoTask> Tasks {get; set;} = new List<ToDoTask>();
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Tasks = new List<ToDoTask>{
            new ToDoTask("Create",ETaskStatus.ToDo),
            new ToDoTask("Creating", ETaskStatus.Doing),
            new ToDoTask("Created",ETaskStatus.Done),
        };
    }
}
