using Database.Domain.Entities;
using Database.Domain.Interfaces;
using Database.Domain.ViewModels.Car;
using OnlineTaxi.DatabaseAccessLayer.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTaxi.DatabaseAccessLayer.EFCore.Reposiotries
{
    public class CarRepository : GenericRepository<CarDomain>, ICarDomain
    {
        private readonly ApplicationContext _context;

        public CarRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public bool IsDuplicateCarName(string name, Guid id)
        {
            return _context.Cars.Any(c => c.Name == name && c.Id != id);
        }
    }
}
