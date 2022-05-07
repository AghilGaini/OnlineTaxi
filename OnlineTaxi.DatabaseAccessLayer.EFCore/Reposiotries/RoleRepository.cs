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
    public class RoleRepository : GenericRepository<RoleDomain>, IRoleDomain
    {
        private readonly ApplicationContext _context;

        public RoleRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public RoleDomain GetByRoleName(string roleName)
        {
            return _context.Roles.FirstOrDefault(r => r.Name == roleName);
        }
    }
}
