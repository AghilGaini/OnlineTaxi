using Database.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface IRoleDomain : IGenericDomain<RoleDomain>
    {
        RoleDomain GetByRoleName(string roleName);
        bool IsDuplicateByName(string name, Guid id);
    }
}
