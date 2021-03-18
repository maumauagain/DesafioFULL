using System.Collections.Generic;
using backend.Models.Entities;
using backend.Models.Interfaces.Repositories;
using backend.Models.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class ParcelaService : IParcelaService
    {
        private IParcelaRepository<Parcela> _repository;

        public ParcelaService(IParcelaRepository<Parcela> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Parcela> Get(int id)
        {
            return await _repository.Select(id);
        }

        public async Task<IEnumerable<Parcela>> GetByDividaId(int id)
        {
            return await _repository.GetParcelasByDivida(id);
        }

        public async Task Post(Parcela parcela)
        {
            await _repository.Add(parcela);
        }

        public async Task Put(Parcela parcela)
        {
            await _repository.Update(parcela);
        }
    }
}
