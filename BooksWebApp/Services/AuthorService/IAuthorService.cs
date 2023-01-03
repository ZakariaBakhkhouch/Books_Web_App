using BooksWebApp.Models;

namespace BooksWebApp.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<List<Authors>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(int id);
        Task AddAuthorAsync(AuthorWithoutId author);
        Task DeleteAuthorByIdAsync(int id);
        Task UpdateAuthorAsync(int id, AuthorWithoutId author);
    }
}
