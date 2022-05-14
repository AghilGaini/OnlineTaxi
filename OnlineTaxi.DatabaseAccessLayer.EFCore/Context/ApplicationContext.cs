using Database.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTaxi.DatabaseAccessLayer.EFCore.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<UserDomain> Users { get; set; }
        public DbSet<RoleDomain> Roles { get; set; }
        public DbSet<UserDetailDomain> UsersDetail { get; set; }
        public DbSet<DriverDomain> Drivers { get; set; }
        public DbSet<ColorDomain> Colors { get; set; }
        public DbSet<CarDomain> Cars { get; set; }
        public DbSet<SettingDomain> Settings { get; set; }
        public DbSet<RateTypeDomain> RateTypes { get; set; }
        public DbSet<EmailSettingDomain> EmailSetting { get; set; }
        public DbSet<PriceTypeDomain> PriceTypes { get; set; }
        public DbSet<MonthlyTypeDomain> MonthlyTypes { get; set; }
        public DbSet<HumidityDomain> Humidities { get; set; }
        public DbSet<TemperatureDomain> Temperatures { get; set; }
    }
}
