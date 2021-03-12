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

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Divida Get(int id)
        {
            return _repository.Select(id);
        }
        public IEnumerable<Divida> GetAll()
        {
            return _repository.Select()
                              .AsQueryable()
                              .Include(d => d.Parcelas)
                              .AsNoTracking().ToList();
        }

        public void Post(Divida divida)
        {
            _repository.Add(divida);
        }

        public void Put(Divida divida)
        {
            _repository.Update(divida);
        }
    }
}
