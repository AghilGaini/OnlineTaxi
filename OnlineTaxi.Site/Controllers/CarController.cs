using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Database.Domain.ViewModels.Car;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxi.Core.Generators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTaxi.Site.Controllers
{
    public class CarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var res = _unitOfWork._car.GetAll();
            var cars = new List<CarsViewModel>();
            foreach (var item in res)
            {
                cars.Add(new CarsViewModel() { Id = item.Id, Name = item.Name });
            }
            return View(cars);
        }


        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork._car.IsDuplicateCarName(model.Name, Guid.Empty))
                    ModelState.AddModelError("", "نام ماشین تکراری میباشد غرمساق");
                else
                {
                    var newCar = new CarDomain()
                    {
                        Name = model.Name,
                        Id = CodeGenerators.GetId()
                    };
                    _unitOfWork._car.Add(newCar);
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
            if (ModelState.IsValid)
            {
                var car = _unitOfWork._car.GetByID(Id);
                if (car == null)
                    ModelState.AddModelError("", "ماشین پیدا نشد");
                else
                {
                    return View(new UpdateCarViewModel() { Id = car.Id, Name = car.Name });
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldCar = _unitOfWork._car.GetByID(model.Id);
                if (oldCar == null)
                {
                    ModelState.AddModelError("", "ماشین قبلی پیدا نشد");
                    return View(model);
                }
                else
                {
                    if (_unitOfWork._car.IsDuplicateCarName(model.Name, model.Id))
                    {
                        ModelState.AddModelError("", "نام ماشین تکراری میباشد");
                        return View(model);
                    }
                    oldCar.Name = model.Name;
                    _unitOfWork._car.Update(oldCar);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var car = _unitOfWork._car.GetByID(id);
            if (car == null)
            {
                ModelState.AddModelError("", "ماشین پیدا نشد");
                return View("Index");
            }

            _unitOfWork._car.Remove(car);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
