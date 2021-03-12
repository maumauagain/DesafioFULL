using System.Collections.Generic;
using backend.Models.Entities;

namespace backend.Models.Interfaces.Services
{
    public interface IParcelaService
    {
        Parcela Get(int id);
        IEnumerable<Parcela> GetByDividaId(int id);
        bool Delete(int id);
        void Post(Parcela parcela);
        void Put(Parcela parcela);
    }
}
