using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models.Entities;

namespace backend.Models.Interfaces.Services
{
    public interface IParcelaService
    {
        Task<Parcela> Get(int id);
        Task<IEnumerable<Parcela>> GetByDividaId(int id);
        Task<bool> Delete(int id);
        Task Post(Parcela parcela);
        Task Put(Parcela parcela);
    }
}
