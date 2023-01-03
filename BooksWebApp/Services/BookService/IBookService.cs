using BooksWebApp.Models;

namespace BooksWebApp.Services.BookService
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();
        Task<BookWithAuthors> GetBookAsync(int id);
        Task AddBookAsync(BookWithAuthors book);
        Task DeleteBookByIdAsync(int id);
        Task UpdateBookAsync(int id, BookWithAuthors book);
    }
}
