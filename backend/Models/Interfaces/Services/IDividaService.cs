using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models.Entities;

namespace backend.Models.Interfaces.Services
{
    public interface IDividaService
    {
        Task<Divida> Get(int id);
        IEnumerable<Divida> GetAll();
        Task<bool> Delete(int id);
        Task Post(Divida divida);
        Task Put(Divida divida);
    }
}
