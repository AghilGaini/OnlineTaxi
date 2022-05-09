using Database.Domain.Interfaces;
using Database.Domain.ViewModels.RateType;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTaxi.Site.Controllers
{
    public class RateTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RateTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var res = _unitOfWork._rateType.GetAll();
            var rateTypes = new RateTypeViewModel();
            foreach (var item in res)
            {
                rateTypes.RateTypesInfo.Add(new RateTypeInfoViewModle()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Ok = item.Ok,
                    ViewOrder = item.ViewOrder
                });
            }

            rateTypes.Actions.Add(new Database.Domain.Model.ActionItem() { Controller = "RateType", Action = "Edit", Title = "ویرایش" });
            rateTypes.Actions.Add(new Database.Domain.Model.ActionItem() { Controller = "RateType", Action = "Edit", Title = "حذف" });

            return View(rateTypes);
        }
    }
}
