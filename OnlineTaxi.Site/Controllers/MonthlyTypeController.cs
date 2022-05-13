using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Database.Domain.Model;
using Database.Domain.ViewModels.MonthlyType;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxi.Core.Generators;
using System;

namespace OnlineTaxi.Site.Controllers
{
    public class MonthlyTypeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public MonthlyTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var res = _unitOfWork._monthlyType.GetAll();

            var monthlyTypes = new MonthlyTypeViewModel();

            foreach (var item in res)
            {
                monthlyTypes.MonthlyTypesInfo.Add(new MonthlyTypeInfoViewModel()
                {
                    Id = item.Id,
                    Start = item.Start,
                    End = item.End,
                    Name = item.Name,
                    Price = item.Price
                });
            }

            monthlyTypes.Actions.Add(new ActionItem() { Controller = "MonthlyType", Action = "Edit", Title = "ویرایش" });
            monthlyTypes.Actions.Add(new ActionItem() { Controller = "MonthlyType", Action = "Delete", Title = "حذف" });

            return View(monthlyTypes);
        }

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewMonthlyTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork._monthlyType.IsDuplicateByName(model.Name, System.Guid.Empty))
                {
                    ModelState.AddModelError("", "نام تعرفه تکراری میباشد");
                    return View(model);
                }
                else
                {
                    var newMonthlyType = new MonthlyTypeDomain()
                    {
                        Id = CodeGenerators.GetId(),
                        Name = model.Name,
                        End = model.End,
                        Start = model.Start,
                        Price = model.Price
                    };

                    _unitOfWork._monthlyType.Add(newMonthlyType);
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
                var monthlyType = _unitOfWork._monthlyType.GetByID(id);
                if (monthlyType == null)
                    ModelState.AddModelError("", "تعرف پیدا نشد");
                else
                    return View(new UpdateMonthlyTypeViewModel()
                    {
                        Id = monthlyType.Id,
                        End = monthlyType.End,
                        Start = monthlyType.Start,
                        Price = monthlyType.Price,
                        Name = monthlyType.Name,
                    });
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateMonthlyTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldMonthlyType = _unitOfWork._monthlyType.GetByID(model.Id);
                if (oldMonthlyType == null)
                {
                    ModelState.AddModelError("", "تعرفه پیدا نشد");
                    return View(model);
                }
                else
                {
                    if (_unitOfWork._monthlyType.IsDuplicateByName(model.Name, model.Id))
                    {
                        ModelState.AddModelError("", "نام تعرف تکراری میباشد");
                        return View(model);
                    }

                    oldMonthlyType.Name = model.Name;
                    oldMonthlyType.Start = model.Start;
                    oldMonthlyType.End = model.End;
                    oldMonthlyType.Price = model.Price;

                    _unitOfWork._monthlyType.Update(oldMonthlyType);
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
            var monthlyType = _unitOfWork._monthlyType.GetByID(id);
            if (monthlyType == null)
            {
                ModelState.AddModelError("", "تعرفه پیدا نشد");
                return RedirectToAction("Index");
            }

            _unitOfWork._monthlyType.Remove(monthlyType);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
