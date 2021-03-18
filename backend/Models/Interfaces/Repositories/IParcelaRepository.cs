using System.Threading.Tasks;
using backend.Models.Entities;

namespace backend.Models.Interfaces.Repositories
{
    public interface IParcelaRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<Parcela[]> GetParcelasByDivida(int dividaId);
    }
}
