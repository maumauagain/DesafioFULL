using System;
using System.Threading.Tasks;
using backend.Data;
using backend.Models.Entities;
using backend.Models.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaService _parcelaService;
        private readonly IDividaService _dividaService;

        public ParcelaController(IParcelaService parcelaService, IDividaService dividaService)
        {
            _parcelaService = parcelaService;
            _dividaService = dividaService;
        }

        [HttpGet("{dividaId}")]
        public async Task<IActionResult> GetParcelasByDivida(int dividaId)
        {
            try
            {
                var result = await _parcelaService.GetByDividaId(dividaId);
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
                if (parcela.DividaId > 0 && await _dividaService.Get(parcela.DividaId) != null)
                {
                    await _parcelaService.Post(parcela);
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
                var result = await _parcelaService.Get(parcela.Id);
                if (result == null)
                    return NotFound();

                await _parcelaService.Put(parcela);

                return Ok(parcela);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpDelete("{parcelaId}")]
        public async Task<IActionResult> Delete(int parcelaId)
        {
            try
            {
                var result = await _parcelaService.Get(parcelaId);
                if (result == null)
                    return NotFound();

                await _parcelaService.Delete(result.Id);

                return Ok(new { message = "Registro removido!" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }


    }
}
