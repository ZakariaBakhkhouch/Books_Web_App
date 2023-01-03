using BooksWebApp.Models;

namespace BooksWebApp.Services.PublisherService
{
    public interface IPublisherService
    {
        Task<List<Publisher>> GetPublishersAsync();
        Task<PublisherWithBooksAndAuthorsVM> GetPublisherAsync(int id);
        Task AddPublisherAsync(PublisherWithoutId publisher);
        Task DeletePublisherByIdAsync(int id);
        Task UpdatePublisherAsync(int id, PublisherWithoutId publisher);
    }
}
