using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Divida
        Task<IEnumerable<Divida>> GetAllDividasAsync();
        Task<Divida> GetDividaAsyncById(int dividaId);

        //Parcela
        Task<Parcela[]> GetParcelasByDivida(int dividaId);
        Task<Parcela> GetParcelaById(int parcelaId);
    }
}
