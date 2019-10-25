using Microsoft.AspNetCore.Mvc;

namespace waInventario.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}