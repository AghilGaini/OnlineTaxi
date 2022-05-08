using Microsoft.AspNetCore.Mvc;

namespace OnlineTaxi.Site.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
