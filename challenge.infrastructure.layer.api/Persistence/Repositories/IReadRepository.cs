using challenge.domain.layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.infrastructure.layer.Persistence.Repositories
{
    public interface IReadRepository<T> where T : Auditoria
    {
        T Get(object id);
        IEnumerable<T> GetAll();
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
