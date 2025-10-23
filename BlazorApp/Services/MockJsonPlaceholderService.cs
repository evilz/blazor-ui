using BlazorApp.Models;

namespace BlazorApp.Services;

public class MockJsonPlaceholderService : IJsonPlaceholderService
{
    public async Task<List<Post>> GetPostsAsync()
    {
        await Task.Delay(100); // Simulate network delay
        return new List<Post>
        {
            new Post { Id = 1, UserId = 1, Title = "sunt aut facere repellat provident", Body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto" },
            new Post { Id = 2, UserId = 1, Title = "qui est esse", Body = "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis" },
            new Post { Id = 3, UserId = 1, Title = "ea molestias quasi exercitationem repellat", Body = "et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel accusantium quis pariatur" },
            new Post { Id = 4, UserId = 1, Title = "eum et est occaecati", Body = "ullam et saepe reiciendis voluptatem adipisci\nsit amet autem assumenda provident rerum culpa" },
            new Post { Id = 5, UserId = 1, Title = "nesciunt quas odio", Body = "repudiandae veniam quaerat sunt sed\nalias aut fugiat sit autem sed est\nvoluptatem omnis possimus esse voluptatibus quis" },
            new Post { Id = 6, UserId = 1, Title = "dolorem eum magni eos aperiam quia", Body = "ut aspernatur corporis harum nihil quis provident sequi\nmollitia nobis aliquid molestiae\nperspiciatis et ea nemo ab reprehenderit accusantium quas" },
            new Post { Id = 7, UserId = 1, Title = "magnam facilis autem", Body = "dolore placeat quibusdam ea quo vitae\nmagni quis enim qui quis quo nemo aut saepe\nquidem repellat excepturi ut quia" },
            new Post { Id = 8, UserId = 1, Title = "dolorem dolore est ipsam", Body = "dignissimos aperiam dolorem qui eum\nfacilis quibusdam animi sint suscipit qui sint possimus cum\nquaerat magni maiores excepturi" },
            new Post { Id = 9, UserId = 1, Title = "nesciunt iure omnis dolorem", Body = "consectetur animi nesciunt iure dolore\nenim quia ad\nveniam autem ut quam aut nobis\net est aut quod aut provident voluptas autem voluptas" },
            new Post { Id = 10, UserId = 1, Title = "optio molestias id quia eum", Body = "quo et expedita modi cum officia vel magni\ndoloribus qui repudiandae\nvero nisi sit\nquos veniam quod sed accusamus veritatis error" }
        };
    }

    public async Task<List<Comment>> GetCommentsAsync()
    {
        await Task.Delay(100);
        return new List<Comment>
        {
            new Comment { Id = 1, PostId = 1, Name = "id labore ex et quam laborum", Email = "Eliseo@gardner.biz", Body = "laudantium enim quasi est quidem magnam voluptate ipsam eos\ntempora quo necessitatibus\ndolor quam autem quasi\nreiciendis et nam sapiente accusantium" },
            new Comment { Id = 2, PostId = 1, Name = "quo vero reiciendis velit similique earum", Email = "Jayne_Kuhic@sydney.com", Body = "est natus enim nihil est dolore omnis voluptatem numquam\net omnis occaecati quod ullam at\nvoluptatem error expedita pariatur" },
            new Comment { Id = 3, PostId = 1, Name = "odio adipisci rerum aut animi", Email = "Nikita@garfield.biz", Body = "quia molestiae reprehenderit quasi aspernatur\naut expedita occaecati aliquam eveniet laudantium\nomnis quibusdam delectus saepe quia accusamus maiores nam est" },
            new Comment { Id = 4, PostId = 1, Name = "alias odio sit", Email = "Lew@alysha.tv", Body = "non et atque\noccaecati deserunt quas accusantium unde odit nobis qui voluptatem\nquia voluptas consequuntur itaque dolor" },
            new Comment { Id = 5, PostId = 1, Name = "vero eaque aliquid doloribus et culpa", Email = "Hayden@althea.biz", Body = "harum non quasi et ratione\ntempore iure ex voluptates in ratione\nharum architecto fugit inventore cupiditate" }
        };
    }

    public async Task<List<User>> GetUsersAsync()
    {
        await Task.Delay(100);
        return new List<User>
        {
            new User { Id = 1, Name = "Leanne Graham", Username = "Bret", Email = "Sincere@april.biz", Phone = "1-770-736-8031 x56442", Website = "hildegard.org", 
                Address = new Address { City = "Gwenborough", Street = "Kulas Light", Suite = "Apt. 556", Zipcode = "92998-3874" },
                Company = new Company { Name = "Romaguera-Crona", CatchPhrase = "Multi-layered client-server neural-net", Bs = "harness real-time e-markets" }
            },
            new User { Id = 2, Name = "Ervin Howell", Username = "Antonette", Email = "Shanna@melissa.tv", Phone = "010-692-6593 x09125", Website = "anastasia.net",
                Address = new Address { City = "Wisokyburgh", Street = "Victor Plains", Suite = "Suite 879", Zipcode = "90566-7771" },
                Company = new Company { Name = "Deckow-Crist", CatchPhrase = "Proactive didactic contingency", Bs = "synergize scalable supply-chains" }
            },
            new User { Id = 3, Name = "Clementine Bauch", Username = "Samantha", Email = "Nathan@yesenia.net", Phone = "1-463-123-4447", Website = "ramiro.info",
                Address = new Address { City = "McKenziehaven", Street = "Douglas Extension", Suite = "Suite 847", Zipcode = "59590-4157" },
                Company = new Company { Name = "Romaguera-Jacobson", CatchPhrase = "Face to face bifurcated interface", Bs = "e-enable strategic applications" }
            }
        };
    }

    public async Task<List<Todo>> GetTodosAsync()
    {
        await Task.Delay(100);
        return new List<Todo>
        {
            new Todo { Id = 1, UserId = 1, Title = "delectus aut autem", Completed = false },
            new Todo { Id = 2, UserId = 1, Title = "quis ut nam facilis et officia qui", Completed = false },
            new Todo { Id = 3, UserId = 1, Title = "fugiat veniam minus", Completed = false },
            new Todo { Id = 4, UserId = 1, Title = "et porro tempora", Completed = true },
            new Todo { Id = 5, UserId = 1, Title = "laboriosam mollitia et enim quasi adipisci quia provident illum", Completed = false },
            new Todo { Id = 6, UserId = 1, Title = "qui ullam ratione quibusdam voluptatem quia omnis", Completed = false },
            new Todo { Id = 7, UserId = 1, Title = "illo expedita consequatur quia in", Completed = false },
            new Todo { Id = 8, UserId = 1, Title = "quo adipisci enim quam ut ab", Completed = true },
            new Todo { Id = 9, UserId = 1, Title = "molestiae perspiciatis ipsa", Completed = false },
            new Todo { Id = 10, UserId = 1, Title = "illo est ratione doloremque quia maiores aut", Completed = true }
        };
    }

    public async Task<List<Album>> GetAlbumsAsync()
    {
        await Task.Delay(100);
        return new List<Album>
        {
            new Album { Id = 1, UserId = 1, Title = "quidem molestiae enim" },
            new Album { Id = 2, UserId = 1, Title = "sunt qui excepturi placeat culpa" },
            new Album { Id = 3, UserId = 1, Title = "omnis laborum odio" },
            new Album { Id = 4, UserId = 1, Title = "non esse culpa molestiae omnis sed optio" },
            new Album { Id = 5, UserId = 1, Title = "eaque aut omnis a" },
            new Album { Id = 6, UserId = 1, Title = "natus impedit quibusdam illo est" },
            new Album { Id = 7, UserId = 1, Title = "quibusdam autem aliquid et et quia" },
            new Album { Id = 8, UserId = 1, Title = "qui fuga est a eum" }
        };
    }

    public async Task<List<Photo>> GetPhotosAsync()
    {
        await Task.Delay(100);
        var photos = new List<Photo>();
        for (int i = 1; i <= 50; i++)
        {
            photos.Add(new Photo 
            { 
                Id = i, 
                AlbumId = ((i - 1) / 10) + 1, 
                Title = $"accusamus beatae ad facilis cum similique qui sunt {i}",
                Url = $"https://via.placeholder.com/600/{(i % 16):X2}{((i * 7) % 16):X2}{((i * 13) % 16):X2}",
                ThumbnailUrl = $"https://via.placeholder.com/150/{(i % 16):X2}{((i * 7) % 16):X2}{((i * 13) % 16):X2}"
            });
        }
        return photos;
    }

    public Task<Post?> GetPostAsync(int id) => throw new NotImplementedException();
    public Task<List<Comment>> GetPostCommentsAsync(int postId) => throw new NotImplementedException();
    public Task<User?> GetUserAsync(int id) => throw new NotImplementedException();
    public Task<List<Todo>> GetUserTodosAsync(int userId) => throw new NotImplementedException();
    public Task<List<Album>> GetUserAlbumsAsync(int userId) => throw new NotImplementedException();
    public Task<List<Photo>> GetAlbumPhotosAsync(int albumId) => throw new NotImplementedException();
}
