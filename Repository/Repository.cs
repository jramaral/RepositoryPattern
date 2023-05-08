using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity); 
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
          return (T)_context.Find(typeof(T),id)!;
        }


        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
