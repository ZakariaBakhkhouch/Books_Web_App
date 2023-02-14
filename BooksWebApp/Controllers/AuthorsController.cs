using BooksWebApp.Helpers;
using BooksWebApp.Services.AuthorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApp.Controllers
{
    [Authorize(Roles = Constants.UserRoles.Admin)]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService= authorService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAuthorsAsync();
            return View(authors);
        }

        [AllowAnonymous]
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
            AuthorWithoutId _authorWithoutId = new()
            {
                FullName = author.FullName,
            };
            await _authorService.UpdateAuthorAsync(author.Id, _authorWithoutId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorWithoutId author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }
            await _authorService.AddAuthorAsync(author);
            return RedirectToAction(nameof(Index));
        }

    }
}
