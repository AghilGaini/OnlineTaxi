using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Database.Domain.ViewModels.Color;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxi.Core.Generators;
using System;

namespace OnlineTaxi.Site.Controllers
{
    public class ColorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ColorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            var res = _unitOfWork._color.GetAll();
            var colors = new ColorsViewModel();
            foreach (var item in res)
            {
                colors.ColorsInfo.Add(new ColorInfoViewModel() { Name = item.Name, Code = item.Code, Id = item.Id });
            }
            colors.Actions.Add(new Database.Domain.Model.ActionItem() { Action = "Edit", Controller = "Color", Title = "ویرایش" });
            colors.Actions.Add(new Database.Domain.Model.ActionItem() { Action = "Delete", Controller = "Color", Title = "حذف" });

            return View(colors);
        }

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewColorViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork._color.IsDuplicateByCodeAndName(model.Name, model.Code, System.Guid.Empty))
                    ModelState.AddModelError("", "نام و کد رنگ تکراری میباشد");

                var newColor = new ColorDomain()
                {
                    Name = model.Name,
                    Code = model.Code,
                    Id = CodeGenerators.GetId()
                };

                _unitOfWork._color.Add(newColor);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
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
                var color = _unitOfWork._color.GetByID(id);
                if (color == null)
                    ModelState.AddModelError("", "رنگ پیدا نشد");
                else
                {
                    return View(new UpdateColorViewModel() { Id = color.Id, Code = color.Code, Name = color.Name });
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateColorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldColor = _unitOfWork._color.GetByID(model.Id);
                if (oldColor == null)
                {
                    ModelState.AddModelError("", "رنگ پیدا نشد");
                    return View(model);
                }
                else
                {
                    if (_unitOfWork._color.IsDuplicateByCodeAndName(model.Name, model.Code, model.Id))
                    {
                        ModelState.AddModelError("", "نام و کد رنگ تکراری میباشد");
                        return View(model);
                    }

                    oldColor.Name = model.Name;
                    oldColor.Code = model.Code;
                    _unitOfWork._color.Update(oldColor);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            var color = _unitOfWork._color.GetByID(Id);

            if (color == null)
            {
                ModelState.AddModelError("", "رنگ پیدا نشد");
            }

            _unitOfWork._color.Remove(color);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        #endregion

    }
}
