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
    public class PriceTypeRepository : GenericRepository<PriceTypeDomain>, IPriceTypeDomain
    {
        private readonly ApplicationContext _context;

        public PriceTypeRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public bool IsDuplicateByName(string name, Guid id)
        {
            return _context.PriceTypes.Any(x => x.Name == name && x.Id != id);
        }
    }
}
