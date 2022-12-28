using BooksWebApp.Models;
using BooksWebApp.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApp.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService= authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAuthorsAsync();
            return View(authors);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var author = await _authorService.GetAuthorAsync(id);
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetAuthorAsync(id);
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Author author)
        {
            await _authorService.UpdateBookAsync(author);
            return RedirectToAction(nameof(Index));
        }
    }
}
