using BooksWebApp.Helpers;
using BooksWebApp.Services.AuthorService;
using BooksWebApp.Services.BookService;
using BooksWebApp.Services.PublisherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApp.Controllers
{
    [AllowAnonymous]
    //[Authorize(Roles = Constants.UserRoles.Admin)]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public BooksController(IBookService bookService, IAuthorService authorService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _authorService= authorService;
            _publisherService= publisherService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBooksAsync();
            return View(books);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBookAsync(id);
            return View(book);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookAsync(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> PostDelete(int id)
        {
            await _bookService.DeleteBookByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var authors = await _authorService.GetAuthorsAsync();
            var publishers = await _publisherService.GetPublishersAsync();
            ViewBag.Authors = authors;
            ViewBag.Publishers = publishers;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookWithAuthors book)
        {
            await _bookService.AddBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookAsync(id);
            var authors = await _authorService.GetAuthorsAsync();
            var publishers = await _publisherService.GetPublishersAsync();
            ViewBag.Authors = authors;
            ViewBag.Publishers = publishers;
            //Book _book = new()
            //{
            //    Id = book.Id,
            //    Title = book.Title,
            //    Genre = book.Genre,
            //    Description = book.Description,
            //    Rate = book.Rate,
            //    IsRead = book.IsRead,
            //    DateAdded = book.DateAdded,
            //    DateRead = book.DateRead,
            //    CoverUrl = book.CoverUrl,
            //    PublisherId = book.PublisherId,
            //};
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookWithAuthors book, int id)
        {
            await _bookService.UpdateBookAsync(id, book);
            return RedirectToAction(nameof(Index));
        }

    }
}
