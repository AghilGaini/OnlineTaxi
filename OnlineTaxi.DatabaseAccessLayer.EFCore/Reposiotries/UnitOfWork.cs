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
        public ICarDomain _car { get; set; }
        public IColorDomain _color { get; set; }
        public IDriverDomain _driver { get; set; }
        public ISettingDomain _setting { get; set; }
        public IRateTypeDomain _rateType { get; set; }
        public IEmailSettingDomain _emailSetting { get; set; }
        public IPriceTypeDomain _priceType { get; set; }
        public IMonthlyTypeDomain _monthlyType { get; set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            _user = new UserRepository(context);
            _userDetail = new UserDetailRepository(context);
            _role = new RoleRepository(context);
            _car = new CarRepository(context);
            _color = new ColorRepository(context);
            _driver = new DriverRepository(context);
            _setting = new SettingRepository(context);
            _rateType = new RateTypeRepository(context);
            _emailSetting = new EmailSettingRepository(context);
            _priceType = new PriceTypeRepository(context);
            _monthlyType = new MonthlyTypeRepository(context);
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public void Complete()
        {
            _context.SaveChanges();

            if (_context != null)
                this.Dispose();
        }
    }
}
