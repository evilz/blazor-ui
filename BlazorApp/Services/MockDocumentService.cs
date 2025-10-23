using BlazorApp.Models;

namespace BlazorApp.Services;

public class MockDocumentService : IDocumentService
{
    private List<Document> documents = new();

    public MockDocumentService()
    {
        InitializeDocuments();
    }

    private void InitializeDocuments()
    {
        documents = new List<Document>
        {
            new Document
            {
                Id = 1,
                Title = "Annual Service Agreement 2025",
                Description = "Comprehensive service agreement covering maintenance and support for the fiscal year 2025",
                Content = @"ANNUAL SERVICE AGREEMENT

This Agreement is entered into as of January 1, 2025, between Company A (""Client"") and Service Provider B (""Provider"").

1. SCOPE OF SERVICES
The Provider agrees to deliver the following services to the Client:
- 24/7 Technical Support
- Monthly System Maintenance
- Quarterly Security Audits
- Annual Performance Review

2. TERM AND TERMINATION
This Agreement shall commence on January 1, 2025, and continue for a period of twelve (12) months unless terminated earlier in accordance with the terms herein.

3. COMPENSATION
Client agrees to pay Provider the sum of $50,000 annually, payable in quarterly installments of $12,500.

4. CONFIDENTIALITY
Both parties agree to maintain the confidentiality of proprietary information shared during the term of this Agreement.

5. LIABILITY
Provider's liability shall be limited to the total amount paid by Client under this Agreement.

6. GOVERNING LAW
This Agreement shall be governed by the laws of the State of California.",
                Status = "Under Review",
                Type = "Contract",
                Author = "Sarah Johnson",
                CreatedDate = DateTime.Now.AddDays(-30),
                LastModified = DateTime.Now.AddDays(-2),
                FileSize = "2.4 MB",
                Version = 3,
                VersionHistory = new List<DocumentVersion>
                {
                    new DocumentVersion { Version = 3, Description = "Updated compensation terms", Author = "Sarah Johnson", Date = DateTime.Now.AddDays(-2), IsCurrent = true },
                    new DocumentVersion { Version = 2, Description = "Added confidentiality clause", Author = "Michael Chen", Date = DateTime.Now.AddDays(-10), IsCurrent = false },
                    new DocumentVersion { Version = 1, Description = "Initial draft", Author = "Sarah Johnson", Date = DateTime.Now.AddDays(-30), IsCurrent = false }
                },
                Reviewers = new List<DocumentReviewer>
                {
                    new DocumentReviewer { Name = "John Smith", Email = "john.smith@company.com", Role = "Legal Counsel", Status = "Approved", ReviewedDate = DateTime.Now.AddDays(-1), Comment = "Legal terms are acceptable. Approved for signature." },
                    new DocumentReviewer { Name = "Emily Davis", Email = "emily.davis@company.com", Role = "Finance Manager", Status = "Approved", ReviewedDate = DateTime.Now.AddHours(-6), Comment = "Budget allocation confirmed." },
                    new DocumentReviewer { Name = "Robert Wilson", Email = "robert.wilson@company.com", Role = "Operations Director", Status = "Pending", ReviewedDate = null, Comment = null }
                },
                Activities = new List<DocumentActivity>
                {
                    new DocumentActivity { Action = "Document created", User = "Sarah Johnson", Timestamp = DateTime.Now.AddDays(-30), Icon = "description" },
                    new DocumentActivity { Action = "Version 2 uploaded", User = "Michael Chen", Timestamp = DateTime.Now.AddDays(-10), Icon = "upload_file" },
                    new DocumentActivity { Action = "Sent for review", User = "Sarah Johnson", Timestamp = DateTime.Now.AddDays(-5), Icon = "rate_review" },
                    new DocumentActivity { Action = "Approved by Legal", User = "John Smith", Timestamp = DateTime.Now.AddDays(-1), Icon = "check_circle" },
                    new DocumentActivity { Action = "Approved by Finance", User = "Emily Davis", Timestamp = DateTime.Now.AddHours(-6), Icon = "check_circle" },
                    new DocumentActivity { Action = "Version 3 uploaded", User = "Sarah Johnson", Timestamp = DateTime.Now.AddDays(-2), Icon = "upload_file" }
                }
            },
            new Document
            {
                Id = 2,
                Title = "Product Requirements Document - Mobile App",
                Description = "Detailed requirements specification for the new mobile application",
                Content = @"PRODUCT REQUIREMENTS DOCUMENT
Mobile Application v2.0

1. EXECUTIVE SUMMARY
This document outlines the functional and technical requirements for our next-generation mobile application.

2. PROJECT GOALS
- Improve user engagement by 40%
- Reduce app loading time by 50%
- Implement offline functionality
- Support both iOS and Android platforms

3. FEATURES
3.1 User Authentication
- Social login integration
- Biometric authentication
- Two-factor authentication

3.2 Dashboard
- Personalized content feed
- Real-time notifications
- Quick action shortcuts

3.3 Search & Discovery
- Advanced search filters
- AI-powered recommendations
- Voice search capability",
                Status = "Draft",
                Type = "Requirements",
                Author = "Alex Martinez",
                CreatedDate = DateTime.Now.AddDays(-14),
                LastModified = DateTime.Now.AddDays(-1),
                FileSize = "1.8 MB",
                Version = 2,
                VersionHistory = new List<DocumentVersion>
                {
                    new DocumentVersion { Version = 2, Description = "Added voice search feature", Author = "Alex Martinez", Date = DateTime.Now.AddDays(-1), IsCurrent = true },
                    new DocumentVersion { Version = 1, Description = "Initial requirements", Author = "Alex Martinez", Date = DateTime.Now.AddDays(-14), IsCurrent = false }
                },
                Reviewers = new List<DocumentReviewer>
                {
                    new DocumentReviewer { Name = "Lisa Anderson", Email = "lisa.anderson@company.com", Role = "Product Manager", Status = "Pending", ReviewedDate = null, Comment = null },
                    new DocumentReviewer { Name = "David Kim", Email = "david.kim@company.com", Role = "Tech Lead", Status = "Pending", ReviewedDate = null, Comment = null }
                },
                Activities = new List<DocumentActivity>
                {
                    new DocumentActivity { Action = "Document created", User = "Alex Martinez", Timestamp = DateTime.Now.AddDays(-14), Icon = "description" },
                    new DocumentActivity { Action = "Shared with team", User = "Alex Martinez", Timestamp = DateTime.Now.AddDays(-13), Icon = "share" },
                    new DocumentActivity { Action = "Version 2 uploaded", User = "Alex Martinez", Timestamp = DateTime.Now.AddDays(-1), Icon = "upload_file" }
                }
            }
        };
    }

    public Task<List<Document>> GetDocumentsAsync()
    {
        return Task.FromResult(documents);
    }

    public Task<Document?> GetDocumentByIdAsync(int id)
    {
        var document = documents.FirstOrDefault(d => d.Id == id);
        return Task.FromResult(document);
    }

    public Task<bool> UpdateDocumentStatusAsync(int id, string status)
    {
        var document = documents.FirstOrDefault(d => d.Id == id);
        if (document != null)
        {
            document.Status = status;
            document.Activities.Add(new DocumentActivity
            {
                Action = $"Status changed to {status}",
                User = "Current User",
                Timestamp = DateTime.Now,
                Icon = "update"
            });
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> AddReviewerCommentAsync(int documentId, string reviewerEmail, string comment)
    {
        var document = documents.FirstOrDefault(d => d.Id == documentId);
        if (document != null)
        {
            var reviewer = document.Reviewers.FirstOrDefault(r => r.Email == reviewerEmail);
            if (reviewer != null)
            {
                reviewer.Comment = comment;
                reviewer.ReviewedDate = DateTime.Now;
                document.Activities.Add(new DocumentActivity
                {
                    Action = "Comment added",
                    User = reviewer.Name,
                    Timestamp = DateTime.Now,
                    Icon = "comment",
                    Details = comment
                });
                return Task.FromResult(true);
            }
        }
        return Task.FromResult(false);
    }
}
