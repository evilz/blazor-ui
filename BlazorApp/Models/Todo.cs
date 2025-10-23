namespace BlazorApp.Models;

public class Todo
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool Completed { get; set; }
    
    // Extended properties for task management
    public string Status { get; set; } = "todo";
    public string Priority { get; set; } = "medium";
    public string Label { get; set; } = "bug";
}
