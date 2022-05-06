using Database.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface IUserDomain : IGenericDomain<UserDomain>
    {
        public bool HasUsername(string username);
        public UserDomain GetUser(string username);
    }
}
