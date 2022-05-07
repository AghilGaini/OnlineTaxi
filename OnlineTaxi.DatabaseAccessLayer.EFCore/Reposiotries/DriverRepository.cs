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
    public class DriverRepository : GenericRepository<DriverDomain>, IDriverDomain
    {
        private readonly ApplicationContext _context;

        public DriverRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
