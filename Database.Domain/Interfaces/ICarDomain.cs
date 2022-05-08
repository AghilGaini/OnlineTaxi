using Database.Domain.Entities;
using Database.Domain.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface ICarDomain : IGenericDomain<CarDomain>
    {
        bool IsDuplicateCarName(string name, Guid id);
    }
}
