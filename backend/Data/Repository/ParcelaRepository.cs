using System.Linq;
using System.Threading.Tasks;
using backend.Models.Entities;
using backend.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repository
{
    public class ParcelaRepository<T> : Repository<T>, IParcelaRepository<T> where T : BaseEntity
    {
        public ParcelaRepository(DataContext context) : base(context) { }

        public Task<Parcela[]> GetParcelasByDivida(int dividaId)
        {
            IQueryable<Parcela> query = _context.Parcelas;

            query = query.AsNoTracking()
                         .OrderBy(parcela => parcela.DataVencimento)
                         .Where(parcela => parcela.DividaId == dividaId);

            return query.ToArrayAsync();
        }

    }
}
