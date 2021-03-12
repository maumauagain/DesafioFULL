using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Entities;

namespace backend.Models.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        bool Delete(int id);
        Task<bool> SaveChangesAsync();
        T Select(int id);
        IEnumerable<T> Select();
    }
}
