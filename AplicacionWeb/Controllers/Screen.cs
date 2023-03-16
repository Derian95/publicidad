using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    public class Screen : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
