using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.ViewModels;

namespace MyApp.Controllers
{
    public class BookController : Controller
    {
        
        private static readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 10.99m },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 8.99m },
            new Book { Id = 3, Title = "1984", Author = "George Orwell", Price = 9.99m }
        };
        public IActionResult Index()
        {
            ViewData["Taleh"] = "Kitablar siyahisi";
            return View("Test", _books);
        }

        public IActionResult Details(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBookRequest request)
        {
            var newBook = new Book
            {
                Id = _books.Count + 1,
                Title = request.Title,
                Author = request.Author,
                Price = request.Price
            };

            _books.Add(newBook);

            return RedirectToAction("Index");
        }
    }
}
