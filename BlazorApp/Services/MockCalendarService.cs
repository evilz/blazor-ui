using BlazorApp.Models;

namespace BlazorApp.Services;

public class MockCalendarService : ICalendarService
{
    private List<CalendarEvent> _events;

    public MockCalendarService()
    {
        _events = GenerateFakeEvents();
    }

    public async Task<List<CalendarEvent>> GetEventsAsync(DateTime? startDate = null, DateTime? endDate = null)
    {
        await Task.Delay(50); // Simulate network delay
        
        var query = _events.AsEnumerable();
        
        if (startDate.HasValue)
            query = query.Where(e => e.StartTime >= startDate.Value);
        
        if (endDate.HasValue)
            query = query.Where(e => e.StartTime <= endDate.Value);
        
        return query.OrderBy(e => e.StartTime).ToList();
    }

    public async Task<CalendarEvent?> GetEventAsync(int id)
    {
        await Task.Delay(30);
        return _events.FirstOrDefault(e => e.Id == id);
    }

    public async Task<bool> CreateEventAsync(CalendarEvent calendarEvent)
    {
        await Task.Delay(100);
        calendarEvent.Id = _events.Max(e => e.Id) + 1;
        _events.Add(calendarEvent);
        return true;
    }

    public async Task<bool> UpdateEventAsync(CalendarEvent calendarEvent)
    {
        await Task.Delay(100);
        var existingEvent = _events.FirstOrDefault(e => e.Id == calendarEvent.Id);
        if (existingEvent != null)
        {
            var index = _events.IndexOf(existingEvent);
            _events[index] = calendarEvent;
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteEventAsync(int id)
    {
        await Task.Delay(50);
        var eventToRemove = _events.FirstOrDefault(e => e.Id == id);
        if (eventToRemove != null)
        {
            _events.Remove(eventToRemove);
            return true;
        }
        return false;
    }

    private List<CalendarEvent> GenerateFakeEvents()
    {
        var events = new List<CalendarEvent>();
        var random = new Random(42); // Fixed seed for consistent data
        var today = DateTime.Today;

        var eventTitles = new[]
        {
            ("Team Standup", "Meeting", "#3b82f6", false),
            ("Project Review", "Meeting", "#8b5cf6", false),
            ("Client Presentation", "Meeting", "#ec4899", false),
            ("Lunch Break", "Appointment", "#10b981", false),
            ("Design Workshop", "Meeting", "#f59e0b", false),
            ("Sprint Planning", "Meeting", "#3b82f6", false),
            ("One-on-One with Manager", "Meeting", "#6366f1", false),
            ("Doctor Appointment", "Appointment", "#ef4444", false),
            ("Coffee Chat", "Appointment", "#10b981", false),
            ("Training Session", "Event", "#8b5cf6", false),
            ("Team Building Event", "Event", "#ec4899", true),
            ("Product Demo", "Meeting", "#3b82f6", true),
            ("Marketing Strategy Meeting", "Meeting", "#f59e0b", false),
            ("Code Review Session", "Meeting", "#6366f1", false),
            ("Customer Call", "Meeting", "#ec4899", true),
            ("All Hands Meeting", "Meeting", "#3b82f6", true),
            ("Focus Time", "Appointment", "#64748b", false),
            ("Quarterly Business Review", "Meeting", "#8b5cf6", false),
            ("Networking Event", "Event", "#10b981", true),
            ("Workshop: Advanced Analytics", "Event", "#f59e0b", false)
        };

        var locations = new[]
        {
            "Conference Room A",
            "Conference Room B",
            "Main Office",
            "Microsoft Teams",
            "Zoom Meeting",
            "Cafeteria",
            "Building 2, Room 301",
            "Online",
            "Client Office",
            "Downtown Office"
        };

        var organizers = new[]
        {
            "Sarah Johnson",
            "Michael Chen",
            "Emily Rodriguez",
            "James Wilson",
            "Alexandra Brown",
            "David Martinez",
            "Jennifer Taylor",
            "You"
        };

        var attendeeNames = new[]
        {
            "Sarah Johnson",
            "Michael Chen",
            "Emily Rodriguez",
            "James Wilson",
            "Alexandra Brown",
            "David Martinez",
            "Jennifer Taylor",
            "Robert Anderson",
            "Lisa Thompson",
            "William Garcia"
        };

        // Generate events for the past week, current week, and next 3 weeks
        for (int i = 0; i < 50; i++)
        {
            var eventInfo = eventTitles[i % eventTitles.Length];
            var daysOffset = random.Next(-7, 28); // Past week to 4 weeks ahead
            var startHour = random.Next(8, 18); // 8 AM to 6 PM
            var duration = random.Next(1, 4) * 30; // 30min, 1hr, 1.5hr, or 2hr
            
            var startTime = today.AddDays(daysOffset).AddHours(startHour).AddMinutes(random.Next(0, 2) * 30);
            var endTime = startTime.AddMinutes(duration);
            
            // Some all-day events
            var isAllDay = random.Next(0, 100) < 10; // 10% all-day events
            if (isAllDay)
            {
                startTime = startTime.Date;
                endTime = startTime.Date.AddDays(1).AddSeconds(-1);
            }

            var isOnline = eventInfo.Item4 || random.Next(0, 100) < 40; // 40% online
            var location = isOnline ? (random.Next(0, 2) == 0 ? "Microsoft Teams" : "Zoom Meeting") : locations[random.Next(locations.Length)];
            
            var attendeeCount = random.Next(2, 6);
            var eventAttendees = new List<string>();
            for (int j = 0; j < attendeeCount; j++)
            {
                var attendee = attendeeNames[random.Next(attendeeNames.Length)];
                if (!eventAttendees.Contains(attendee))
                    eventAttendees.Add(attendee);
            }

            events.Add(new CalendarEvent
            {
                Id = i + 1,
                Title = eventInfo.Item1,
                Description = GenerateDescription(eventInfo.Item1, random),
                StartTime = startTime,
                EndTime = endTime,
                Location = location,
                Organizer = organizers[random.Next(organizers.Length)],
                Attendees = eventAttendees,
                Category = eventInfo.Item2,
                Color = eventInfo.Item3,
                IsAllDay = isAllDay,
                IsOnline = isOnline,
                MeetingLink = isOnline ? GenerateMeetingLink(random) : ""
            });
        }

        return events.OrderBy(e => e.StartTime).ToList();
    }

    private string GenerateDescription(string title, Random random)
    {
        var descriptions = new[]
        {
            $"Join us for {title.ToLower()}. We'll discuss progress, blockers, and next steps.",
            $"Important {title.ToLower()} to align on goals and deliverables.",
            $"Please come prepared with updates for this {title.ToLower()}.",
            $"Agenda will be shared before the {title.ToLower()}.",
            $"This {title.ToLower()} is crucial for project success.",
            $"Looking forward to productive discussion during this {title.ToLower()}.",
            $"Please review the materials before attending this {title.ToLower()}.",
            $"Recurring {title.ToLower()} - please mark your calendar.",
        };
        return descriptions[random.Next(descriptions.Length)];
    }

    private string GenerateMeetingLink(Random random)
    {
        var linkTypes = new[]
        {
            "https://teams.microsoft.com/l/meetup-join/19%3ameeting_",
            "https://zoom.us/j/",
        };
        var linkType = linkTypes[random.Next(linkTypes.Length)];
        return linkType + random.Next(100000000, 999999999);
    }
}
