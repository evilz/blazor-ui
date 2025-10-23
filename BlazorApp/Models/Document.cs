namespace BlazorApp.Models;

public class Document
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Content { get; set; } = "";
    public string Status { get; set; } = "Draft";
    public string Type { get; set; } = "Contract";
    public string Author { get; set; } = "";
    public DateTime CreatedDate { get; set; }
    public DateTime LastModified { get; set; }
    public string FileSize { get; set; } = "";
    public int Version { get; set; }
    public List<DocumentVersion> VersionHistory { get; set; } = new();
    public List<DocumentReviewer> Reviewers { get; set; } = new();
    public List<DocumentActivity> Activities { get; set; } = new();
}

public class DocumentVersion
{
    public int Version { get; set; }
    public string Description { get; set; } = "";
    public string Author { get; set; } = "";
    public DateTime Date { get; set; }
    public bool IsCurrent { get; set; }
}

public class DocumentReviewer
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Role { get; set; } = "";
    public string Status { get; set; } = "Pending";
    public DateTime? ReviewedDate { get; set; }
    public string? Comment { get; set; }
}

public class DocumentActivity
{
    public string Action { get; set; } = "";
    public string User { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public string Icon { get; set; } = "info";
    public string? Details { get; set; }
}
