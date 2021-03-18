using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models.Entities;
using backend.Models.Interfaces.Repositories;
using backend.Models.Interfaces.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class DividaService : IDividaService
    {
        private IRepository<Divida> _repository;

        public DividaService(IRepository<Divida> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Divida> Get(int id)
        {
            return await _repository.Select(id);
        }
        public IEnumerable<Divida> GetAll()
        {
            return _repository.Select()
                              .AsQueryable()
                              .Include(d => d.Parcelas)
                              .AsNoTracking().ToList();
        }

        public async Task Post(Divida divida)
        {
            await _repository.Add(divida);
        }

        public async Task Put(Divida divida)
        {
            await _repository.Update(divida);
        }
    }
}
