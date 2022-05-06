using Database.Domain.Interfaces;
using OnlineTaxi.DatabaseAccessLayer.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTaxi.DatabaseAccessLayer.EFCore.Reposiotries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IUserDomain _user { get; set; }
        public IUserDetailDomain _userDetail { get; set; }
        public IRoleDomain _role { get; set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            _user = new UserRepository(context);
            _userDetail = new UserDetailRepository(context);
            _role = new RoleRepository(context);
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
