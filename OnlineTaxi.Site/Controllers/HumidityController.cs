using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Database.Domain.Model;
using Database.Domain.ViewModels.Humidity;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxi.Core.Generators;
using System;

namespace OnlineTaxi.Site.Controllers
{
    public class HumidityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HumidityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var res = _unitOfWork._humidity.GetAll();

            var humidityTypes = new HumidityViewModels();

            foreach (var item in res)
            {
                humidityTypes.HumiditiesInfo.Add(new HumidityInfoViewModel()
                {
                    Id = item.Id,
                    Start = item.Start,
                    End = item.End,
                    Name = item.Name,
                    Percent = item.Percent,
                });
            }

            humidityTypes.Actions.Add(new ActionItem() { Controller = "Humidity", Action = "Edit", Title = "ویرایش" });
            humidityTypes.Actions.Add(new ActionItem() { Controller = "Humidity", Action = "Delete", Title = "حذف" });

            return View(humidityTypes);
        }

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewHumidityViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork._humidity.IsDuplicateByName(model.Name, Guid.Empty))
                {
                    ModelState.AddModelError("", "نام تعرفه تکراری میباشد");
                    return View(model);
                }
                else
                {
                    var newHumidityType = new HumidityDomain()
                    {
                        Id = CodeGenerators.GetId(),
                        Name = model.Name,
                        End = model.End,
                        Start = model.Start,
                        Percent = model.Percent,
                    };

                    _unitOfWork._humidity.Add(newHumidityType);
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
                var humidityType = _unitOfWork._humidity.GetByID(id);
                if (humidityType == null)
                    ModelState.AddModelError("", "تعرف پیدا نشد");
                else
                    return View(new UpdateHumidityViewModel()
                    {
                        Id = humidityType.Id,
                        End = humidityType.End,
                        Start = humidityType.Start,
                        Percent = humidityType.Percent,
                        Name = humidityType.Name,
                    });
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateHumidityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldHumidityType = _unitOfWork._humidity.GetByID(model.Id);
                if (oldHumidityType == null)
                {
                    ModelState.AddModelError("", "تعرفه پیدا نشد");
                    return View(model);
                }
                else
                {
                    if (_unitOfWork._humidity.IsDuplicateByName(model.Name, model.Id))
                    {
                        ModelState.AddModelError("", "نام تعرف تکراری میباشد");
                        return View(model);
                    }

                    oldHumidityType.Name = model.Name;
                    oldHumidityType.Start = model.Start;
                    oldHumidityType.End = model.End;
                    oldHumidityType.Percent = model.Percent;

                    _unitOfWork._humidity.Update(oldHumidityType);
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
            var humidityType = _unitOfWork._humidity.GetByID(id);
            if (humidityType == null)
            {
                ModelState.AddModelError("", "تعرفه پیدا نشد");
                return RedirectToAction("Index");
            }

            _unitOfWork._humidity.Remove(humidityType);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
