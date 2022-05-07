using Database.Domain.Interfaces;
using Database.Domain.ViewModels.Car;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
    }
}
