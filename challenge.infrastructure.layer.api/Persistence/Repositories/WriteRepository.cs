using challenge.domain.layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.infrastructure.layer.Persistence.Repositories
{
    public class WriteRepository<T> : ReadRepository<T>, IWriteRepository<T> where T : Auditoria
    {
        //private readonly DbSet<T> _dbSet;
        //public WriteRepository(dDbContext context) : base(context)
        //{
        //    _dbSet = _context.Set<T>();
        //}

        //public virtual void Insert(T entity)
        //{
        //    _dbSet.Add(entity);
        //}
        //public virtual void Update(T entity)
        //{
        //    _dbSet.Update(entity);
        //}
        //public virtual void Delete(object id)
        //{
        //    _dbSet.Remove(Get(id));
        //}

        //public virtual Task DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
        //public virtual Task InsertAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}


        //public virtual Task UpdateAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
