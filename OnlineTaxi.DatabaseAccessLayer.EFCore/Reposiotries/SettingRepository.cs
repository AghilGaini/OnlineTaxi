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
    public class SettingRepository : GenericRepository<SettingDomain>, ISettingDomain
    {
        private readonly ApplicationContext _context;

        public SettingRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public SettingDomain GetByKey(string key)
        {
            return _context.Settings.FirstOrDefault(r => r.KeyString == key);
        }
    }
}
