namespace BlazorApp.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string[] Technologies { get; set; } = Array.Empty<string>();
    public int Stars { get; set; }
    public int Forks { get; set; }
    public string RepositoryUrl { get; set; } = string.Empty;
    public string DemoUrl { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}
