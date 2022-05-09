using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Database.Domain.ViewModels.RateType;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxi.Core.Generators;
using System;

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

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewRateTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork._rateType.IsDuplicateByName(model.Name, System.Guid.Empty))
                    ModelState.AddModelError("", "نام تکراری میباشد");
                else
                {
                    var newRateType = new RateTypeDomain()
                    {
                        Id = CodeGenerators.GetId(),
                        Name = model.Name,
                        Ok = model.Ok,
                        ViewOrder = model.ViewOrder
                    };
                    _unitOfWork._rateType.Add(newRateType);
                    _unitOfWork.Complete();

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var rateType = _unitOfWork._rateType.GetByID(Id);
            if (rateType == null)
            {
                ModelState.AddModelError("", "مقدار مورد نظر پیدا نشد");
                return View();
            }
            else
            {
                var model = new UpdateRateTypeViewModel()
                {
                    Id = rateType.Id,
                    Name = rateType.Name,
                    Ok = rateType.Ok ?? false,
                    ViewOrder = rateType.ViewOrder
                };

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Edit(UpdateRateTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rateType = _unitOfWork._rateType.GetByID(model.Id);
                if (rateType == null)
                {
                    ModelState.AddModelError("", "مقدار مورد نظر پیدا نشد");
                    return View(model);
                }
                else
                {
                    if (_unitOfWork._rateType.IsDuplicateByName(model.Name, model.Id))
                    {
                        ModelState.AddModelError("", "نام نظر تکراری میباشد");
                        return View(model);
                    }
                    else
                    {
                        rateType.Name = model.Name;
                        rateType.Ok = model.Ok;
                        rateType.ViewOrder = model.ViewOrder;

                        _unitOfWork._rateType.Update(rateType);
                        _unitOfWork.Complete();

                        return RedirectToAction("Index");
                    }
                }

            }
            return View(model);
        }

        #endregion

        #region Delete

        public IActionResult Delete(Guid id)
        {
            var rateType = _unitOfWork._rateType.GetByID(id);

            if (rateType == null)
            {
                ModelState.AddModelError("", "مقدار مورد نظر پیدا نشد");
            }

            _unitOfWork._rateType.Remove(rateType);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
