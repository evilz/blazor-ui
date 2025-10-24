# Blazor UI - Best Practices Guide

This document outlines the best practices and patterns used in this Blazor application.

## Architecture & Code Organization

### 1. Project Structure
```
BlazorApp/
├── Components/
│   ├── Layout/          # Layout components (MainLayout)
│   ├── Pages/           # Page components with @page directive
│   ├── Shared/          # Reusable UI components
│   └── ShowCase/        # Component showcase/demos
├── Models/              # Data models and DTOs
├── Services/            # Service interfaces and implementations
│   ├── I*Service.cs     # Service interfaces
│   └── Mock*Service.cs  # Mock implementations
├── Styles/              # CSS and styling files
└── wwwroot/             # Static assets
```

### 2. Service Layer Pattern

**Best Practice**: Always create an interface for each service to enable dependency injection and testability.

```csharp
// Service interface with XML documentation
/// <summary>
/// Service interface for Kanban board operations
/// </summary>
public interface IKanbanService
{
    /// <summary>
    /// Gets all Kanban cards
    /// </summary>
    Task<List<KanbanCard>> GetCardsAsync();
    
    // ... other methods
}

// Mock implementation for development
public class MockKanbanService : IKanbanService
{
    // Implementation with realistic sample data
}
```

**Registration in Program.cs**:
```csharp
builder.Services.AddScoped<IKanbanService, MockKanbanService>();
```

### 3. Component Base Classes

**Best Practice**: Create base classes for common component patterns to reduce code duplication.

```csharp
public abstract class PageComponentBase : ComponentBase
{
    protected bool IsLoading { get; set; } = true;
    protected bool HasError { get; set; }
    protected string ErrorMessage { get; set; } = string.Empty;
    
    protected async Task ExecuteAsync(Func<Task> operation, string errorMessage = "An error occurred")
    {
        // Centralized loading and error handling
    }
}
```

**Usage**:
```csharp
@code {
    protected override async Task OnInitializedAsync()
    {
        await ExecuteAsync(async () =>
        {
            data = await DataService.GetDataAsync();
        }, "Failed to load data");
    }
}
```

## UI Components

### 4. Reusable UI Components

#### LoadingSpinner Component
**Purpose**: Consistent loading states across the application

```razor
<LoadingSpinner Message="Loading kanban board..." />
```

**Features**:
- Customizable icon and size
- Optional message
- Consistent styling

#### EmptyState Component
**Purpose**: User-friendly display when no data is available

```razor
<EmptyState 
    IconName="inbox" 
    Title="No tasks found" 
    Description="Create your first task to get started">
    <ActionButton>
        <Button Text="Create Task" OnClick="CreateTask" />
    </ActionButton>
</EmptyState>
```

**Features**:
- Icon, title, and description
- Optional action button
- Responsive design

#### ErrorDisplay Component
**Purpose**: Consistent error handling and user feedback

```razor
<ErrorDisplay 
    Title="Something went wrong"
    Message="Failed to load tasks"
    Details="@errorDetails"
    ShowDetails="true"
    OnRetry="RetryAsync" />
```

**Features**:
- User-friendly error messages
- Optional technical details
- Retry functionality

### 5. Page Component Structure

**Best Practice**: Follow a consistent structure for page components:

```razor
@page "/route"
@rendermode InteractiveServer
@inject IService Service
@using Models

<PageTitle>Page Title - Blazor UI</PageTitle>

<!-- Breadcrumb Navigation -->
<div class="page-header">
    <Breadcrumb Items="@breadcrumbItems" />
    <h1>Page Title</h1>
    <p>Page description</p>
</div>

<!-- Loading State -->
@if (isLoading)
{
    <LoadingSpinner Message="Loading..." />
}
<!-- Error State -->
else if (hasError)
{
    <ErrorDisplay Message="@errorMessage" OnRetry="LoadData" />
}
<!-- Main Content -->
else
{
    <!-- Your content here -->
}

@code {
    private bool isLoading = true;
    private bool hasError = false;
    
    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }
}
```

## Data Models

### 6. Model Design

**Best Practice**: Use proper C# properties with initialization

```csharp
public class KanbanCard
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = "todo";
    public List<string> Tags { get; set; } = new();
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? DueDate { get; set; }
}
```

**Key Points**:
- Initialize string properties to `string.Empty` to avoid null reference warnings
- Initialize collections to avoid null checks
- Use nullable types (`?`) for optional properties
- Provide sensible defaults

## Styling

### 7. CSS Organization

**Best Practice**: Use component-scoped styles with CSS custom properties

```html
<style>
    .kanban-board {
        display: grid;
        gap: 1.5rem;
        /* Use CSS custom properties for theming */
        background: var(--card-background, #fff);
        border: 1px solid var(--border-color, #e5e7eb);
        color: var(--text-primary);
    }
</style>
```

**Key Points**:
- Use semantic class names
- Leverage CSS custom properties for theming
- Provide fallback values
- Keep styles scoped to components

### 8. Responsive Design

**Best Practice**: Use CSS Grid and Flexbox for responsive layouts

```css
.kanban-board {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
    gap: 1.5rem;
}
```

**Benefits**:
- Automatic responsive behavior
- Flexible column sizing
- Consistent spacing

## State Management

### 9. Component State

**Best Practice**: Use `StateHasChanged()` after async operations

```csharp
private async Task LoadCards()
{
    isLoading = true;
    cards = await KanbanService.GetCardsAsync();
    isLoading = false;
    StateHasChanged(); // Ensure UI updates
}
```

### 10. Event Handling

**Best Practice**: Use lambda expressions for event handlers with parameters

```razor
<Button OnClick="@(() => HandleClick(item))" />
```

**For async operations**:
```csharp
private async Task HandleClick(Item item)
{
    await ProcessItemAsync(item);
    StateHasChanged();
}
```

## Forms and Dialogs

### 11. Modal Dialogs

**Best Practice**: Create custom dialog overlay with click-outside-to-close

```razor
<div class="dialog-overlay" @onclick="CloseDialog">
    <div class="dialog-container" @onclick:stopPropagation="true">
        <!-- Dialog content -->
    </div>
</div>
```

**CSS**:
```css
.dialog-overlay {
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(0, 0, 0, 0.5);
    z-index: 1000;
}
```

### 12. Form Validation

**Best Practice**: Use two-way binding with validation

```razor
<div class="form-group">
    <Label Text="Title" />
    <Input @bind-Value="model.Title" TItem="string" Placeholder="Enter title" />
</div>
```

## Performance

### 13. Async Operations

**Best Practice**: Always use async/await for I/O operations

```csharp
protected override async Task OnInitializedAsync()
{
    // Load data asynchronously
    data = await DataService.GetDataAsync();
}
```

### 14. Virtualization

**Best Practice**: For large lists, consider virtualization (future enhancement)

## Testing

### 15. Testable Code

**Best Practice**: Design for testability with interfaces and dependency injection

- All services have interfaces
- Components use dependency injection
- Mock services for development and testing
- Separation of concerns

## Documentation

### 16. XML Documentation

**Best Practice**: Add XML comments to all public APIs

```csharp
/// <summary>
/// Gets all Kanban cards
/// </summary>
/// <returns>List of all cards</returns>
Task<List<KanbanCard>> GetCardsAsync();
```

### 17. Component Parameters

**Best Practice**: Document component parameters

```csharp
/// <summary>
/// Message to display below the spinner
/// </summary>
[Parameter]
public string Message { get; set; } = "Loading...";
```

## Security

### 18. Input Validation

**Best Practice**: Always validate user input (to be implemented)

```csharp
// Future enhancement: Add data annotations
public class KanbanCard
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;
}
```

### 19. XSS Prevention

**Best Practice**: Blazor automatically encodes output, but be careful with raw HTML

```razor
<!-- Safe - automatically encoded -->
<p>@userInput</p>

<!-- Dangerous - avoid unless necessary -->
<p>@((MarkupString)userInput)</p>
```

## Accessibility

### 20. Semantic HTML

**Best Practice**: Use semantic HTML elements

```html
<nav>
    <Breadcrumb Items="@breadcrumbItems" />
</nav>

<main>
    <header class="page-header">
        <h1>Page Title</h1>
    </header>
</main>
```

### 21. ARIA Labels

**Best Practice**: Add ARIA labels where needed (to be improved)

```html
<button aria-label="Close dialog" @onclick="CloseDialog">
    <Icon Name="close" />
</button>
```

## Future Enhancements

### Recommended Additions

1. **Authentication & Authorization**
   - Identity integration
   - Role-based access control

2. **Real-time Features**
   - SignalR integration for real-time updates
   - Live collaboration features

3. **Advanced Features**
   - Data validation with FluentValidation
   - Client-side caching
   - Offline support with PWA

4. **Testing**
   - bUnit for component testing
   - Integration tests
   - E2E tests with Playwright

5. **Performance**
   - Lazy loading for routes
   - Virtual scrolling for large lists
   - Image optimization

## Summary

This Blazor UI template demonstrates best practices in:
- ✅ Clean architecture with separation of concerns
- ✅ Reusable component library
- ✅ Consistent error handling and loading states
- ✅ Service layer with dependency injection
- ✅ Mock services for development
- ✅ Responsive design
- ✅ XML documentation
- ✅ Type safety with interfaces

For questions or contributions, please refer to the repository documentation.
