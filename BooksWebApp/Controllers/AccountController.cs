using BooksWebApp.Helpers;
using BooksWebApp.Services.AccountService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BooksWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public readonly Settings settings;

        public AccountController(IAccountService accountService, 
            IOptions<Settings> settings)
        {
            _accountService = accountService;
            this.settings = settings.Value;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var response = await _accountService.LoginAsync(model);
            if(response.IsAuthenticated == true)
            {
                settings.Token = response.Token;
                return RedirectToAction("Index", "Books");
            }
            
            return View(response.Message);
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
