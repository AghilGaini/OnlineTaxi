using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Database.Domain.Model;
using Database.Domain.ViewModels.Termperature;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxi.Core.Generators;
using System;

namespace OnlineTaxi.Site.Controllers
{
    public class TemperatureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TemperatureController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var res = _unitOfWork._temperature.GetAll();

            var temperatures = new TemperatureViewModel();

            foreach (var item in res)
            {
                temperatures.TemperaturesInfo.Add(new TemperatureInfoViewModel()
                {
                    Id = item.Id,
                    Start = item.Start,
                    End = item.End,
                    Name = item.Name,
                    Percent = item.Percent,
                });
            }

            temperatures.Actions.Add(new ActionItem() { Controller = "Temperature", Action = "Edit", Title = "ویرایش" });
            temperatures.Actions.Add(new ActionItem() { Controller = "Temperature", Action = "Delete", Title = "حذف" });

            return View(temperatures);
        }

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewTemperatureViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork._temperature.IsDuplicateByName(model.Name, Guid.Empty))
                {
                    ModelState.AddModelError("", "نام تعرفه تکراری میباشد");
                    return View(model);
                }
                else
                {
                    var newTemperature = new TemperatureDomain()
                    {
                        Id = CodeGenerators.GetId(),
                        Name = model.Name,
                        End = model.End,
                        Start = model.Start,
                        Percent = model.Percent,
                    };

                    _unitOfWork._temperature.Add(newTemperature);
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
                var temperature = _unitOfWork._temperature.GetByID(id);
                if (temperature == null)
                    ModelState.AddModelError("", "تعرف پیدا نشد");
                else
                    return View(new UpdateTemperatureViewModel()
                    {
                        Id = temperature.Id,
                        End = temperature.End,
                        Start = temperature.Start,
                        Percent = temperature.Percent,
                        Name = temperature.Name,
                    });
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateTemperatureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldTemperature = _unitOfWork._temperature.GetByID(model.Id);
                if (oldTemperature == null)
                {
                    ModelState.AddModelError("", "تعرفه پیدا نشد");
                    return View(model);
                }
                else
                {
                    if (_unitOfWork._temperature.IsDuplicateByName(model.Name, model.Id))
                    {
                        ModelState.AddModelError("", "نام تعرف تکراری میباشد");
                        return View(model);
                    }

                    oldTemperature.Name = model.Name;
                    oldTemperature.Start = model.Start;
                    oldTemperature.End = model.End;
                    oldTemperature.Percent = model.Percent;

                    _unitOfWork._temperature.Update(oldTemperature);
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
            var temperature = _unitOfWork._temperature.GetByID(id);
            if (temperature == null)
            {
                ModelState.AddModelError("", "تعرفه پیدا نشد");
                return RedirectToAction("Index");
            }

            _unitOfWork._temperature.Remove(temperature);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
