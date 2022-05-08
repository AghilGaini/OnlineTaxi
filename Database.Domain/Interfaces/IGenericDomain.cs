using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface IGenericDomain<T> where T : class
    {
        public List<T> GetAll();
        public void Add(T entity);
        public void AddRange(IEnumerable<T> entities);
        public T GetByID(Guid id);
        public T GetByID(long id);
        public bool Update(T entity);
        public bool Remove(T entity);
    }
}
