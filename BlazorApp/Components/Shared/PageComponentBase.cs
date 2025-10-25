using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Shared;

/// <summary>
/// Base class for page components with common functionality
/// Implements loading, error handling, and state management patterns
/// </summary>
public abstract class PageComponentBase : ComponentBase
{
    /// <summary>
    /// Indicates whether the component is in loading state
    /// </summary>
    protected bool IsLoading { get; set; } = true;

    /// <summary>
    /// Indicates whether an error has occurred
    /// </summary>
    protected bool HasError { get; set; }

    /// <summary>
    /// Error message to display
    /// </summary>
    protected string ErrorMessage { get; set; } = string.Empty;

    /// <summary>
    /// Error details for debugging
    /// </summary>
    protected string ErrorDetails { get; set; } = string.Empty;

    /// <summary>
    /// Executes an async operation with loading and error handling
    /// </summary>
    /// <param name="operation">The operation to execute</param>
    /// <param name="errorMessage">Custom error message to display on failure</param>
    protected async Task ExecuteAsync(Func<Task> operation, string errorMessage = "An error occurred")
    {
        try
        {
            IsLoading = true;
            HasError = false;
            StateHasChanged();

            await operation();
        }
        catch (Exception ex)
        {
            HasError = true;
            ErrorMessage = errorMessage;
            ErrorDetails = ex.ToString();
        }
        finally
        {
            IsLoading = false;
            StateHasChanged();
        }
    }

    /// <summary>
    /// Executes an async operation with loading and error handling, returning a result
    /// </summary>
    /// <typeparam name="T">The type of result</typeparam>
    /// <param name="operation">The operation to execute</param>
    /// <param name="errorMessage">Custom error message to display on failure</param>
    /// <returns>The result of the operation, or default(T) if an error occurred</returns>
    protected async Task<T?> ExecuteAsync<T>(Func<Task<T>> operation, string errorMessage = "An error occurred")
    {
        try
        {
            IsLoading = true;
            HasError = false;
            StateHasChanged();

            return await operation();
        }
        catch (Exception ex)
        {
            HasError = true;
            ErrorMessage = errorMessage;
            ErrorDetails = ex.ToString();
            return default;
        }
        finally
        {
            IsLoading = false;
            StateHasChanged();
        }
    }

    /// <summary>
    /// Retries the last failed operation
    /// Override this method to implement retry logic
    /// </summary>
    protected virtual async Task RetryAsync()
    {
        await OnInitializedAsync();
    }
}
