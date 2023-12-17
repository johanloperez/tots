using challenge.domain.layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.infrastructure.layer.Persistence.Repositories
{
    public abstract class ReadRepository<T> : IReadRepository<T> where T : Auditoria
    {
        //protected readonly DbContext _context;
        //private readonly DbSet<T> _dbSet;
        //protected ReadRepository(DbContext context)
        //{
        //    _context = context;
        //    _dbSet = _context.Set<T>();
        //}
        //public virtual T Get(object id)
        //{
        //    return _dbSet.Where(t => t.Id.Equals(id)).Single();
        //}

        //public virtual IEnumerable<T> GetAll()
        //{
        //    return _dbSet.ToList();
        //}

        //public virtual async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await _dbSet.ToListAsync();
        //}

        //public virtual async Task<T> GetAsync(int id)
        //{
        //    return await _dbSet.FirstAsync(t => t.Id.Equals(id.ToString()));
        //}
        public T Get(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
