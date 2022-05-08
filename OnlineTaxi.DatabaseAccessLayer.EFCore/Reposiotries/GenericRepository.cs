using Database.Domain.Interfaces;
using OnlineTaxi.DatabaseAccessLayer.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTaxi.DatabaseAccessLayer.EFCore.Reposiotries
{
    public class GenericRepository<T> : IGenericDomain<T> where T : class
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetByID(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public bool Remove(T entity)
        {
            if (entity == null)
                return false;

            _context.Set<T>().Remove(entity);
            return true;
        }

        public bool Update(T entity)
        {
            if (entity == null)
                return false;
            _context.Set<T>().Update(entity);
            return true;
        }
    }
}
