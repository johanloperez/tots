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
