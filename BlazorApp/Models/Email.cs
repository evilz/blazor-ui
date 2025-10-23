namespace BlazorApp.Models;

public class Email
{
    public int Id { get; set; }
    public string From { get; set; } = string.Empty;
    public string FromEmail { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Preview { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public bool IsRead { get; set; }
    public bool IsStarred { get; set; }
    public bool HasAttachment { get; set; }
    public string Category { get; set; } = "Inbox";
}
