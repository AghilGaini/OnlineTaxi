using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTaxi.Site.Controllers
{
    public class EmailSettingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmailSettingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {


            return View();
        }
    }
}
