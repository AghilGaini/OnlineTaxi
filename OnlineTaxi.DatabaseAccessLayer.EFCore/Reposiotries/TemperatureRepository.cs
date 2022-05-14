using Database.Domain.Entities;
using Database.Domain.Interfaces;
using OnlineTaxi.DatabaseAccessLayer.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTaxi.DatabaseAccessLayer.EFCore.Reposiotries
{
    public class TemperatureRepository : GenericRepository<TemperatureDomain>, ITemperatureDomain
    {
        private readonly ApplicationContext _context;

        public TemperatureRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public bool IsDuplicateByName(string name, Guid id)
        {
            return _context.Temperatures.Any(r => r.Name == name && r.Id != id);
        }
    }
}
