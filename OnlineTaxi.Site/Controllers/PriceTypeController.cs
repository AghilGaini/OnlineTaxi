using Database.Domain.Interfaces;
using Database.Domain.ViewModels.PriceType;
using Microsoft.AspNetCore.Mvc;
using Database.Domain.Model;
using Database.Domain.Entities;
using OnlineTaxi.Core.Generators;
using System;

namespace OnlineTaxi.Site.Controllers
{
    public class PriceTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PriceTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var res = _unitOfWork._priceType.GetAll();

            var priceTypes = new PriceTypeViewModel();

            foreach (var item in res)
            {
                priceTypes.PriceTypesInfo.Add(new PriceTypeInfoViewModel()
                {
                    Id = item.Id,
                    Start = item.Start,
                    End = item.End,
                    Name = item.Name,
                    Price = item.Price
                });
            }

            priceTypes.Actions.Add(new ActionItem() { Controller = "PriceType", Action = "Edit", Title = "ویرایش" });
            priceTypes.Actions.Add(new ActionItem() { Controller = "PriceType", Action = "Delete", Title = "حذف" });

            return View(priceTypes);
        }

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewPriceTyeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork._priceType.IsDuplicateByName(model.Name, System.Guid.Empty))
                {
                    ModelState.AddModelError("", "نام تعرفه تکراری میباشد");
                    return View(model);
                }
                else
                {
                    var newPriceType = new PriceTypeDomain()
                    {
                        Id = CodeGenerators.GetId(),
                        Name = model.Name,
                        End = model.End,
                        Start = model.Start,
                        Price = model.Price
                    };

                    _unitOfWork._priceType.Add(newPriceType);
                    _unitOfWork.Complete();

                    return RedirectToAction("Index");
                }
            }

            return View(model);

        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (ModelState.IsValid)
            {
                var priceType = _unitOfWork._priceType.GetByID(id);
                if (priceType == null)
                    ModelState.AddModelError("", "تعرف پیدا نشد");
                else
                    return View(new UpdatePriceTypeViewModel()
                    {
                        Id = priceType.Id,
                        End = priceType.End,
                        Start = priceType.Start,
                        Price = priceType.Price,
                        Name = priceType.Name,
                    });
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdatePriceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldPriceType = _unitOfWork._priceType.GetByID(model.Id);
                if (oldPriceType == null)
                {
                    ModelState.AddModelError("", "تعرفه پیدا نشد");
                    return View(model);
                }
                else
                {
                    if (_unitOfWork._priceType.IsDuplicateByName(model.Name, model.Id))
                    {
                        ModelState.AddModelError("", "نام تعرف تکراری میباشد");
                        return View(model);
                    }

                    oldPriceType.Name = model.Name;
                    oldPriceType.Start = model.Start;
                    oldPriceType.End = model.End;
                    oldPriceType.Price = model.Price;

                    _unitOfWork._priceType.Update(oldPriceType);
                    _unitOfWork.Complete();

                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        #endregion

        #region Delete

        public IActionResult Delete(Guid id)
        {
            var priceType = _unitOfWork._priceType.GetByID(id);
            if (priceType == null)
            {
                ModelState.AddModelError("", "تعرفه پیدا نشد");
                return RedirectToAction("Index");
            }

            _unitOfWork._priceType.Remove(priceType);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        #endregion

    }
}
