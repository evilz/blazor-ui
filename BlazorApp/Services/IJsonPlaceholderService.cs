using BlazorApp.Models;

namespace BlazorApp.Services;

public interface IJsonPlaceholderService
{
    Task<List<Post>> GetPostsAsync();
    Task<Post?> GetPostAsync(int id);
    Task<List<Comment>> GetCommentsAsync();
    Task<List<Comment>> GetPostCommentsAsync(int postId);
    Task<List<User>> GetUsersAsync();
    Task<User?> GetUserAsync(int id);
    Task<List<Todo>> GetTodosAsync();
    Task<List<Todo>> GetUserTodosAsync(int userId);
    Task<List<Album>> GetAlbumsAsync();
    Task<List<Album>> GetUserAlbumsAsync(int userId);
    Task<List<Photo>> GetPhotosAsync();
    Task<List<Photo>> GetAlbumPhotosAsync(int albumId);
}
