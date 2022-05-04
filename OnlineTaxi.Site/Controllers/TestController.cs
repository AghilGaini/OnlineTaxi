using Microsoft.AspNetCore.Mvc;

namespace OnlineTaxi.Site.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Json("test");
        }
    }
}
