using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Divida[]> GetAllDividasAsync()
        {
            IQueryable<Divida> query = _context.Dividas;

            query = query.Include(divida => divida.Parcelas);
            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Divida> GetDividaAsyncById(int dividaId)
        {
            IQueryable<Divida> query = _context.Dividas;

            query = query.Include(d => d.Parcelas);


            query = query.AsNoTracking()
                         .OrderBy(divida => divida.Id)
                         .Where(divida => divida.Id == dividaId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Parcela[]> GetParcelasByDivida(int dividaId)
        {
            IQueryable<Parcela> query = _context.Parcelas;

            query = query.AsNoTracking()
                         .OrderBy(parcela => parcela.DataVencimento)
                         .Where(parcela => parcela.DividaId == dividaId);

            return await query.ToArrayAsync();
        }

        public async Task<Parcela> GetParcelaById(int parcelaId)
        {
            IQueryable<Parcela> query = _context.Parcelas;

            query = query.AsNoTracking()
                         .Where(parcela => parcela.Id == parcelaId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
