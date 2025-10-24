using BlazorApp.Models;

namespace BlazorApp.Services;

/// <summary>
/// Mock implementation of IKanbanService for development and testing
/// </summary>
public class MockKanbanService : IKanbanService
{
    private List<KanbanCard> _cards;
    private int _nextId = 1;

    public MockKanbanService()
    {
        _cards = GenerateMockCards();
    }

    public async Task<List<KanbanCard>> GetCardsAsync()
    {
        await Task.Delay(50); // Simulate network delay
        return _cards.OrderBy(c => c.CreatedDate).ToList();
    }

    public async Task<KanbanCard?> GetCardByIdAsync(int id)
    {
        await Task.Delay(30);
        return _cards.FirstOrDefault(c => c.Id == id);
    }

    public async Task<bool> CreateCardAsync(KanbanCard card)
    {
        await Task.Delay(100);
        card.Id = _nextId++;
        card.CreatedDate = DateTime.Now;
        _cards.Add(card);
        return true;
    }

    public async Task<bool> UpdateCardAsync(KanbanCard card)
    {
        await Task.Delay(100);
        var existingCard = _cards.FirstOrDefault(c => c.Id == card.Id);
        if (existingCard != null)
        {
            var index = _cards.IndexOf(existingCard);
            _cards[index] = card;
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteCardAsync(int id)
    {
        await Task.Delay(100);
        var card = _cards.FirstOrDefault(c => c.Id == id);
        if (card != null)
        {
            _cards.Remove(card);
            return true;
        }
        return false;
    }

    public async Task<bool> UpdateCardStatusAsync(int id, string newStatus)
    {
        await Task.Delay(100);
        var card = _cards.FirstOrDefault(c => c.Id == id);
        if (card != null)
        {
            card.Status = newStatus;
            return true;
        }
        return false;
    }

    private List<KanbanCard> GenerateMockCards()
    {
        var cards = new List<KanbanCard>();
        var statuses = new[] { "todo", "in-progress", "review", "done" };
        var priorities = new[] { "low", "medium", "high" };
        var assignees = new[] { "Alice Johnson", "Bob Smith", "Carol Williams", "David Brown", "Emma Davis" };
        var tags = new[] { "Feature", "Bug", "Enhancement", "Documentation", "Testing", "UI/UX", "Backend", "Frontend" };

        var tasks = new[]
        {
            ("Implement user authentication", "Add OAuth2 authentication for users", "todo", "high", new[] { "Feature", "Backend" }),
            ("Fix navigation menu bug", "Menu items not highlighting correctly on mobile", "todo", "medium", new[] { "Bug", "UI/UX" }),
            ("Update documentation", "Add API documentation for new endpoints", "todo", "low", new[] { "Documentation" }),
            ("Design dashboard mockups", "Create wireframes for new analytics dashboard", "in-progress", "high", new[] { "UI/UX", "Feature" }),
            ("Code review for PR #123", "Review and test pull request changes", "in-progress", "medium", new[] { "Testing" }),
            ("Optimize database queries", "Improve query performance on user table", "in-progress", "high", new[] { "Backend", "Enhancement" }),
            ("Add unit tests", "Write tests for authentication service", "review", "medium", new[] { "Testing", "Backend" }),
            ("Refactor API endpoints", "Clean up REST API structure", "review", "low", new[] { "Backend", "Enhancement" }),
            ("User profile page", "Completed user profile with avatar upload", "done", "high", new[] { "Feature", "Frontend" }),
            ("Fix CSS layout issues", "Resolved flexbox issues on product page", "done", "medium", new[] { "Bug", "UI/UX" }),
            ("Setup CI/CD pipeline", "Configured GitHub Actions for deployments", "done", "high", new[] { "Enhancement" })
        };

        for (int i = 0; i < tasks.Length; i++)
        {
            var task = tasks[i];
            var dueDate = DateTime.Now.AddDays(Random.Shared.Next(-10, 20));
            
            cards.Add(new KanbanCard
            {
                Id = _nextId++,
                Title = task.Item1,
                Description = task.Item2,
                Status = task.Item3,
                Priority = task.Item4,
                AssignedTo = assignees[Random.Shared.Next(assignees.Length)],
                CreatedDate = DateTime.Now.AddDays(-Random.Shared.Next(1, 30)),
                DueDate = task.Item3 != "done" ? dueDate : null,
                Tags = task.Item5.ToList()
            });
        }

        return cards;
    }
}
