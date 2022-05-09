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
        public ICarDomain _car { get; set; }
        public IColorDomain _color { get; set; }
        public IDriverDomain _driver { get; set; }
        public ISettingDomain _setting { get; set; }
        public IRateTypeDomain _rateType { get; set; }

        public void Complete();
    }
}
