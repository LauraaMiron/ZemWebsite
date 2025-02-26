using Microsoft.AspNetCore.Mvc;

namespace MyAuthApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
