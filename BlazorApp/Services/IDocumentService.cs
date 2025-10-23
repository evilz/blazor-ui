using BlazorApp.Models;

namespace BlazorApp.Services;

public interface IDocumentService
{
    Task<List<Document>> GetDocumentsAsync();
    Task<Document?> GetDocumentByIdAsync(int id);
    Task<bool> UpdateDocumentStatusAsync(int id, string status);
    Task<bool> AddReviewerCommentAsync(int documentId, string reviewerEmail, string comment);
}
