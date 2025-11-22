// Ana sayfa (dashboard) controllerı

using Microsoft.AspNetCore.Mvc;

namespace KutuphaneWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Views/Home/Index.cshtml dosyasını göster
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}