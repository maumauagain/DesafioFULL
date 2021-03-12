using System.Collections.Generic;
using backend.Models.Entities;
using backend.Models.Interfaces;
using backend.Models.Interfaces.Services;
using System.Linq;

namespace backend.Services
{
    public class ParcelaService : IParcelaService
    {
        private IRepository<Parcela> _repository;

        public ParcelaService(IRepository<Parcela> repository)
        {
            _repository = repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Parcela Get(int id)
        {
            return _repository.Select(id);
        }

        public IEnumerable<Parcela> GetByDividaId(int id)
        {
            return _repository.GetParcelasByDivida(id);
        }

        public void Post(Parcela parcela)
        {
            _repository.Add(parcela);
        }

        public void Put(Parcela parcela)
        {
            _repository.Update(parcela);
        }
    }
}
