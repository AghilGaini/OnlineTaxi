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
    public class EmailSettingRepository : GenericRepository<EmailSettingDomain>, IEmailSettingDomain
    {
        private readonly ApplicationContext _context;

        public EmailSettingRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public bool IsDuplicateByAddress(string emailAddress, long Id)
        {
            return _context.EmailSetting.Any(r => r.Address.ToLower() == emailAddress.ToLower() && r.Id != Id);
        }
    }
}
