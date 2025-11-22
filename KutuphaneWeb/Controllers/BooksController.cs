// Kitap sayfaları controllerı

using Microsoft.AspNetCore.Mvc;

namespace KutuphaneWeb.Controllers
{
    public class BooksController : Controller
    {
        // URL: /Books/Index
        public IActionResult Index()
        {
            return View();
        }

        // URL: /Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // URL: /Books/Edit?id=5
        public IActionResult Edit()
        {
            return View();
        }
        // not: ID javascript ile url'den gelecek

        // URL: /Books/Details?id=5
        public IActionResult Details()
        {
            // Views/Books/Details.cshtml'i aç
            return View();
        }
    }
}