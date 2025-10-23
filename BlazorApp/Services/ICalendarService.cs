using BlazorApp.Models;

namespace BlazorApp.Services;

public interface ICalendarService
{
    Task<List<CalendarEvent>> GetEventsAsync(DateTime? startDate = null, DateTime? endDate = null);
    Task<CalendarEvent?> GetEventAsync(int id);
    Task<bool> CreateEventAsync(CalendarEvent calendarEvent);
    Task<bool> UpdateEventAsync(CalendarEvent calendarEvent);
    Task<bool> DeleteEventAsync(int id);
}
