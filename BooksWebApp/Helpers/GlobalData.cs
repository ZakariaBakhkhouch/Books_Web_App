namespace BooksWebApp.Helpers
{
    public class GlobalData
    {
        public static GlobalData Instance { get; } = new GlobalData();
        public string BaseApiEndpoint { get; set; }

        public GlobalData()
        {
            BaseApiEndpoint = "https://books-web-api.azurewebsites.net";
        }
        
    }
}
