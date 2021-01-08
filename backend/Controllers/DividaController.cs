using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DividaController : ControllerBase
    {
        private readonly IRepository _repository;

        public DividaController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDividas()
        {
            try
            {
                var result = await _repository.GetAllDividasAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpGet("{dividaId}")]
        public async Task<IActionResult> GetDividaById(int dividaId)
        {
            try
            {
                var result = await _repository.GetDividaAsyncById(dividaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Divida divida)
        {
            try
            {
                _repository.Add(divida);

                if (await _repository.SaveChangesAsync())
                    return Ok(divida);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }

        [HttpPut]
        public async Task<IActionResult> Put(Divida divida)
        {
            try
            {
                var result = await _repository.GetDividaAsyncById(divida.Id);
                if (result == null)
                    return NotFound();

                _repository.Update(divida);

                if (await _repository.SaveChangesAsync())
                    return Ok(divida);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }

        [HttpDelete("{dividaId}")]
        public async Task<IActionResult> Delete(int dividaId)
        {
            try
            {
                var result = await _repository.GetDividaAsyncById(dividaId);
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
