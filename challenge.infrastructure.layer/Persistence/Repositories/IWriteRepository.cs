using challenge.domain.layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.infrastructure.layer.Persistence.Repositories
{
    public interface IWriteRepository<in T> where T : Auditoria
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
