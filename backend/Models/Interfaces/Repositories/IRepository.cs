using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Entities;

namespace backend.Models.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        Task Update(T entity);
        Task<bool> Delete(int id);
        Task<bool> SaveChangesAsync();
        Task<T> Select(int id);
        IEnumerable<T> Select();
    }
}
