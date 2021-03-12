using System.Collections.Generic;
using backend.Models.Entities;

namespace backend.Models.Interfaces.Services
{
    public interface IDividaService
    {
        Divida Get(int id);
        IEnumerable<Divida> GetAll();
        bool Delete(int id);
        void Post(Divida divida);
        void Put(Divida divida);
    }
}
