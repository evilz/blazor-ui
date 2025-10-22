using BlazorApp.Models;
using System.Net.Http.Json;

namespace BlazorApp.Services;

public class JsonPlaceholderService : IJsonPlaceholderService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://jsonplaceholder.typicode.com";

    public JsonPlaceholderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Post>>("posts") ?? new List<Post>();
    }

    public async Task<Post?> GetPostAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Post>($"posts/{id}");
    }

    public async Task<List<Comment>> GetCommentsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Comment>>("comments") ?? new List<Comment>();
    }

    public async Task<List<Comment>> GetPostCommentsAsync(int postId)
    {
        return await _httpClient.GetFromJsonAsync<List<Comment>>($"posts/{postId}/comments") ?? new List<Comment>();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<User>>("users") ?? new List<User>();
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<User>($"users/{id}");
    }

    public async Task<List<Todo>> GetTodosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Todo>>("todos") ?? new List<Todo>();
    }

    public async Task<List<Todo>> GetUserTodosAsync(int userId)
    {
        return await _httpClient.GetFromJsonAsync<List<Todo>>($"users/{userId}/todos") ?? new List<Todo>();
    }

    public async Task<List<Album>> GetAlbumsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Album>>("albums") ?? new List<Album>();
    }

    public async Task<List<Album>> GetUserAlbumsAsync(int userId)
    {
        return await _httpClient.GetFromJsonAsync<List<Album>>($"users/{userId}/albums") ?? new List<Album>();
    }

    public async Task<List<Photo>> GetPhotosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Photo>>("photos") ?? new List<Photo>();
    }

    public async Task<List<Photo>> GetAlbumPhotosAsync(int albumId)
    {
        return await _httpClient.GetFromJsonAsync<List<Photo>>($"albums/{albumId}/photos") ?? new List<Photo>();
    }
}
