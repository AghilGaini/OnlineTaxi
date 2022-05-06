using Database.Domain.Interfaces;
using Database.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxi.Core.Generators;

namespace OnlineTaxi.Site.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _unitOfWork._user.GetUser(model.Username);
                if (user != null)
                {
                    //Just update and send verification code
                    user.Password = CodeGenerators.GetActiveCode();
                    //TODO : Send SMS
                }
                else
                {
                    //Create user and send verify code
                    user = new Database.Domain.Entities.UserDomain()
                    {
                        Id = CodeGenerators.GetId(),
                        IsActive = false,
                        Password = CodeGenerators.GetActiveCode(),
                        Username = model.Username
                    };

                    _unitOfWork._user.Add(user);

                    //TODO : Send SMS
                }
                _unitOfWork.Complete();
                TempData["Username"] = user.Username;
                return RedirectToAction("ActiveUser");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ActiveUser()
        {
            ViewBag.Username = TempData["Username"];
            return View();
        }

        [HttpPost]
        public IActionResult ActiveUser(ActiveUserModelView model)
        {
            var user = _unitOfWork._user.GetUser(model.Username);
            if (user != null)
            {
                if (user.Password == model.ActiveCode)
                {
                    user.IsActive = true;
                    _unitOfWork.Complete();
                    ViewBag.Success = "User Activated";
                    return View();
                }
                else
                {
                    ViewBag.Error = "Incorrect Active Code";
                    return View();
                }
            }
            return View("Index", "Test");
        }

    }
}
