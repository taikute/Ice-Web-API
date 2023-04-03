using Ice_Web_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ice_Web_MVC.Controllers
{
    public class BookController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7268/api");
        HttpClient client = new HttpClient();

        public BookController()
        {
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<BookViewModel>? books = new List<BookViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/book").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<BookViewModel>>(data);
            }
            return View(books);
        }
    }
}
