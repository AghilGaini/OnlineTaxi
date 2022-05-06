using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserDomain _user { get; set; }
        public IUserDetailDomain _userDetail { get; set; }
        public IRoleDomain _role { get; set; }
        public void Complete();
    }
}
