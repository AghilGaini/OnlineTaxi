using Database.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface IColorDomain : IGenericDomain<ColorDomain>
    {
        bool IsDuplicateByCodeAndName(string name, string code, Guid id);
    }
}
