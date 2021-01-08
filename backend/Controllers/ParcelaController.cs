using System;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelaController : ControllerBase
    {
        private readonly IRepository _repository;

        public ParcelaController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{dividaId}")]
        public async Task<IActionResult> GetParcelasByDivida(int dividaId)
        {
            try
            {
                var result = await _repository.GetParcelasByDivida(dividaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Parcela parcela)
        {
            try
            {
                if (parcela.DividaId > 0 && _repository.GetDividaAsyncById(parcela.DividaId) != null)
                {
                    _repository.Add(parcela);

                    if (await _repository.SaveChangesAsync())
                        return Ok(parcela);

                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Parcela parcela)
        {
            try
            {
                var result = await _repository.GetParcelaById(parcela.Id);
                if (result == null)
                    return NotFound();

                _repository.Update(parcela);

                if (await _repository.SaveChangesAsync())
                    return Ok(parcela);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }

        [HttpDelete("{parcelaId}")]
        public async Task<IActionResult> Delete(int parcelaId)
        {
            try
            {
                var result = await _repository.GetParcelaById(parcelaId);
                if (result == null)
                    return NotFound();

                _repository.Delete(result);

                if (await _repository.SaveChangesAsync())
                    return Ok("Registro removido!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }


    }
}
