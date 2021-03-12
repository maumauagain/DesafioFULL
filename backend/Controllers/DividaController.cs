using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.DTO;
using backend.Models.Entities;
using backend.Models.Interfaces;
using backend.Models.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DividaController : ControllerBase
    {
        private readonly IDividaService _dividaService;
        private readonly IMapper _mapper;

        public DividaController(IDividaService dividaService, IMapper mapper)
        {
            _dividaService = dividaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDividas()
        {
            try
            {
                var result = _dividaService.GetAll();
                var debts = _mapper.Map<IEnumerable<DividaDTO>>(result);
                return Ok(debts);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpGet("{dividaId}")]
        public IActionResult GetDividaById(int dividaId)
        {
            try
            {
                var result = _dividaService.Get(dividaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpPost]
        public IActionResult Post(Divida divida)
        {
            try
            {
                _dividaService.Post(divida);

                var dividaDTO = _mapper.Map<DividaDTO>(divida);
                return Ok(dividaDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Put(Divida divida)
        {
            try
            {
                var result = _dividaService.Get(divida.Id);
                if (result == null)
                    return NotFound();

                _dividaService.Put(divida);

                var dividaDTO = _mapper.Map<DividaDTO>(divida);
                return Ok(dividaDTO);

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpDelete("{dividaId}")]
        public IActionResult Delete(int dividaId)
        {
            try
            {
                var result = _dividaService.Get(dividaId);
                if (result == null)
                    return NotFound();

                if (_dividaService.Delete(dividaId))
                    return Ok(new { message = "Registro removido!" });

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }
    }
}
