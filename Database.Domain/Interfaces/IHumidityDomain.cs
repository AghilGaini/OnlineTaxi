using Database.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface IHumidityDomain : IGenericDomain<HumidityDomain>
    {
        public bool IsDuplicateByName(string name, Guid id);
    }
}
