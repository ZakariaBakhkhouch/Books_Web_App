namespace BooksWebApp.Services.AccountService
{
    public interface IAccountService
    {
        Task<Response> RegisterAsync(Register model);
        Task<Response> LoginAsync(Login model);
    }
}
