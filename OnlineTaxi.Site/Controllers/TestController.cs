using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxi.Core.Senders;

namespace OnlineTaxi.Site.Controllers
{
    public class TestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            EmailSender.Send("aghilgaini@yahoo.com", "Test Subject", "Test body");
            return View();
        }
    }
}
