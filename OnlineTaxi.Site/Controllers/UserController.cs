using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTaxi.Site.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Others()
        {
            var role = _unitOfWork._role.GetByRoleName("user");
            if (role == null)
            {
                ModelState.AddModelError("", "نقش پیدا نشد");
                return View();
            }

            var users = _unitOfWork._user.GetUsersByRoleId(role.Id);
            return View(users);
        }
    }
}
