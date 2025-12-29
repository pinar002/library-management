using Microsoft.AspNetCore.Mvc;

namespace KutuphaneWeb.Controllers
{
    public class LoansController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
