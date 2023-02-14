using BooksWebApp.Helpers;
using BooksWebApp.Services.PublisherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApp.Controllers
{
    [Authorize(Roles = Constants.UserRoles.Admin)]
    public class PublishersController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService= publisherService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var publishers = await _publisherService.GetPublishersAsync();
            return View(publishers);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var publisher = await _publisherService.GetPublisherAsync(id);
            return View(publisher);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PublisherWithoutId publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }
            await _publisherService.AddPublisherAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var publisher = await _publisherService.GetPublisherAsync(id);
            return View(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PublisherWithBooksAndAuthorsVM publisher)
        {
            var _publisher = new PublisherWithoutId
            {
                FullName = publisher.FullName,
            };
            await _publisherService.UpdatePublisherAsync(id, _publisher);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _publisherService.DeletePublisherByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
