using BlazorApp.Models;

namespace BlazorApp.Services;

public interface IMailService
{
    Task<List<Email>> GetEmailsAsync(string category = "Inbox");
    Task<Email?> GetEmailAsync(int id);
    Task<bool> SendEmailAsync(Email email);
    Task<bool> MarkAsReadAsync(int id);
    Task<bool> ToggleStarAsync(int id);
    Task<bool> DeleteEmailAsync(int id);
}
