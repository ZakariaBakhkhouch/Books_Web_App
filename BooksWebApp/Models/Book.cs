using System.Security.Policy;
using System.Text.Json.Serialization;

namespace BooksWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Descriprtion { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }

        public int? Rate { get; set; }

        public string Gender { get; set; }

        public string CoverUrl { get; set; }

        public DateTime DateAdded { get; set; }

        // ---------------------- navigation properties ----------------------
        //public int? PublisherId { get; set; }

        //public Publisher Publisher { get; set; }

        //public List<Book_Author> Book_Authors { get; set; }
    }
}
