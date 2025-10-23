namespace BlazorApp.Models;

public class TravelGuide
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public decimal Price { get; set; }
    public string Duration { get; set; } = string.Empty;
    public bool IsFeatured { get; set; }
}
