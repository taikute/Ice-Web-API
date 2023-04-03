using Ice_Web_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/book");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var books = JsonConvert.DeserializeObject<List<BookViewModel>>(data);
                return View(books);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Create()
        {
            return View(new BookViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(bookViewModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(client.BaseAddress + "/book", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            return View(bookViewModel);
        }
    }
}
