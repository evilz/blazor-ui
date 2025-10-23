namespace BlazorApp.Models;

public class CalendarEvent
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Organizer { get; set; } = string.Empty;
    public List<string> Attendees { get; set; } = new();
    public string Category { get; set; } = "Other"; // Meeting, Appointment, Event, Reminder, Other
    public string Color { get; set; } = "#3b82f6"; // Blue default
    public bool IsAllDay { get; set; }
    public bool IsOnline { get; set; }
    public string MeetingLink { get; set; } = string.Empty;
}
