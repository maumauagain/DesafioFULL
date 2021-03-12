using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Entities;

namespace backend.Models.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        bool Delete(int id);
        Task<bool> SaveChangesAsync();
        T Select(int id);
        IEnumerable<T> Select();

        //Parcela
        Parcela[] GetParcelasByDivida(int dividaId);
    }
}
