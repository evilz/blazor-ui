using BlazorApp.Models;

namespace BlazorApp.Services;

/// <summary>
/// Service interface for Kanban board operations
/// </summary>
public interface IKanbanService
{
    /// <summary>
    /// Gets all Kanban cards
    /// </summary>
    Task<List<KanbanCard>> GetCardsAsync();
    
    /// <summary>
    /// Gets a specific Kanban card by ID
    /// </summary>
    Task<KanbanCard?> GetCardByIdAsync(int id);
    
    /// <summary>
    /// Creates a new Kanban card
    /// </summary>
    Task<bool> CreateCardAsync(KanbanCard card);
    
    /// <summary>
    /// Updates an existing Kanban card
    /// </summary>
    Task<bool> UpdateCardAsync(KanbanCard card);
    
    /// <summary>
    /// Deletes a Kanban card
    /// </summary>
    Task<bool> DeleteCardAsync(int id);
    
    /// <summary>
    /// Updates the status of a Kanban card
    /// </summary>
    Task<bool> UpdateCardStatusAsync(int id, string newStatus);
}
