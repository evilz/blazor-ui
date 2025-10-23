using BlazorApp.Models;

namespace BlazorApp.Services;

public class MockMailService : IMailService
{
    private List<Email> _emails;

    public MockMailService()
    {
        _emails = GenerateFakeEmails();
    }

    public async Task<List<Email>> GetEmailsAsync(string category = "Inbox")
    {
        await Task.Delay(100); // Simulate network delay
        return _emails.Where(e => e.Category == category).OrderByDescending(e => e.Date).ToList();
    }

    public async Task<Email?> GetEmailAsync(int id)
    {
        await Task.Delay(50);
        return _emails.FirstOrDefault(e => e.Id == id);
    }

    public async Task<bool> SendEmailAsync(Email email)
    {
        await Task.Delay(200);
        email.Id = _emails.Max(e => e.Id) + 1;
        email.Date = DateTime.Now;
        email.Category = "Sent";
        _emails.Add(email);
        return true;
    }

    public async Task<bool> MarkAsReadAsync(int id)
    {
        await Task.Delay(50);
        var email = _emails.FirstOrDefault(e => e.Id == id);
        if (email != null)
        {
            email.IsRead = true;
            return true;
        }
        return false;
    }

    public async Task<bool> ToggleStarAsync(int id)
    {
        await Task.Delay(50);
        var email = _emails.FirstOrDefault(e => e.Id == id);
        if (email != null)
        {
            email.IsStarred = !email.IsStarred;
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteEmailAsync(int id)
    {
        await Task.Delay(50);
        var email = _emails.FirstOrDefault(e => e.Id == id);
        if (email != null)
        {
            _emails.Remove(email);
            return true;
        }
        return false;
    }

    private List<Email> GenerateFakeEmails()
    {
        var senders = new[]
        {
            ("Sarah Johnson", "sarah.j@company.com"),
            ("Michael Chen", "mchen@techcorp.io"),
            ("Emily Rodriguez", "emily.r@startup.dev"),
            ("James Wilson", "jwilson@enterprise.net"),
            ("Alexandra Brown", "alex.b@business.com"),
            ("David Martinez", "dmartinez@consulting.pro"),
            ("Jennifer Taylor", "jtaylor@design.studio"),
            ("Robert Anderson", "randerson@marketing.agency"),
            ("Lisa Thompson", "lthompson@sales.biz"),
            ("William Garcia", "wgarcia@finance.co"),
            ("Microsoft Teams", "noreply@teams.microsoft.com"),
            ("GitHub", "noreply@github.com"),
            ("LinkedIn", "notifications@linkedin.com"),
            ("Amazon", "orders@amazon.com"),
            ("Slack", "feedback@slack.com")
        };

        var subjects = new[]
        {
            "Q4 Project Review Meeting",
            "Action Required: Approve Budget Request",
            "Welcome to the Team!",
            "Weekly Status Report - Week 42",
            "Important: Security Update Required",
            "Your order has been shipped",
            "Meeting Notes - Product Roadmap Discussion",
            "Reminder: Complete Your Performance Review",
            "New Feature Release - v2.1.0",
            "Team Building Event - Save the Date",
            "Invoice #12345 - Payment Due",
            "Congratulations on Your Work Anniversary!",
            "System Maintenance Scheduled",
            "Customer Feedback Summary",
            "Project Milestone Achieved",
            "Vacation Request Approval",
            "Training Session: Advanced Analytics",
            "Code Review Request - PR #456",
            "Monthly Newsletter - October 2025",
            "Urgent: Production Issue Detected"
        };

        var emails = new List<Email>();
        var random = new Random(42); // Fixed seed for consistent fake data

        for (int i = 0; i < 25; i++)
        {
            var sender = senders[i % senders.Length];
            var subject = subjects[i % subjects.Length];
            var daysAgo = random.Next(0, 30);
            var hoursAgo = random.Next(0, 24);
            
            emails.Add(new Email
            {
                Id = i + 1,
                From = sender.Item1,
                FromEmail = sender.Item2,
                Subject = subject,
                Preview = GeneratePreview(subject, random),
                Body = GenerateBody(subject, sender.Item1, random),
                Date = DateTime.Now.AddDays(-daysAgo).AddHours(-hoursAgo),
                IsRead = random.Next(0, 100) < 60, // 60% read
                IsStarred = random.Next(0, 100) < 15, // 15% starred
                HasAttachment = random.Next(0, 100) < 25, // 25% with attachment
                Category = "Inbox"
            });
        }

        return emails;
    }

    private string GeneratePreview(string subject, Random random)
    {
        var previews = new[]
        {
            "Hi, I wanted to follow up on our previous discussion about the project timeline...",
            "Please find attached the latest report for your review. Let me know if you have any questions...",
            "Thank you for your continued support. We're excited to share some updates with you...",
            "This is a reminder that the deadline is approaching. Please make sure to submit your work...",
            "Great news! We've successfully completed the first phase of the project...",
            "I hope this email finds you well. I wanted to reach out regarding the upcoming event...",
            "As discussed in our last meeting, here are the action items we need to address...",
            "Your feedback has been incredibly valuable. We've implemented several of your suggestions...",
            "We're pleased to announce some exciting changes coming to our platform...",
            "Just a quick note to confirm the details we discussed earlier today..."
        };
        return previews[random.Next(previews.Length)];
    }

    private string GenerateBody(string subject, string sender, Random random)
    {
        return $@"Dear Team,

{GeneratePreview(subject, random)}

{(random.Next(0, 100) < 50 ? "I've reviewed the documents you sent and everything looks good. We can proceed with the next steps as planned." : "I wanted to bring to your attention some important updates that require immediate action.")}

{(random.Next(0, 100) < 40 ? "Please let me know if you need any additional information or clarification on any of these points." : "Looking forward to hearing your thoughts on this matter.")}

Best regards,
{sender}";
    }
}
