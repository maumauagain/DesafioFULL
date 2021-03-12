using backend.Models.Entities;

namespace backend.Models.Interfaces.Repositories
{
    public interface IParcelaRepository<T> : IRepository<T> where T : BaseEntity
    {
        Parcela[] GetParcelasByDivida(int dividaId);
    }
}
