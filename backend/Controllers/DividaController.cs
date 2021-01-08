using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DividaController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetDividas()
        {
            Divida divida = new Divida
            {
                Id = 1,
                CPFDevedor = "12345",
                Juros = 1,
                Multa = 2,
                NomeDevedor = "Roger",
                Numero = 1010,
                Parcelas = new List<Parcela>(){
                    new Parcela{
                        Id = 1,
                        DataVencimento = new DateTime(2020, 10, 5),
                        Numero = 5,
                        Valor = 100
                    },
                    new Parcela{
                        Id = 2,
                        DataVencimento = new DateTime(2020, 11, 5),
                        Numero = 6,
                        Valor = 100
                    }
                }
            };

            Divida divida2 = new Divida
            {
                Id = 2,
                CPFDevedor = "123456",
                Juros = 1,
                Multa = 2,
                NomeDevedor = "Ygor",
                Numero = 1011,
                Parcelas = new List<Parcela>(){
                    new Parcela{
                        Id = 3,
                        DataVencimento = new DateTime(2020, 12, 5),
                        Numero = 7,
                        Valor = 200
                    },
                    new Parcela{
                        Id = 4,
                        DataVencimento = new DateTime(2021, 1, 5),
                        Numero = 8,
                        Valor = 200
                    }
                }
            };

            List<Divida> Dividas = new List<Divida>();
            Dividas.Add(divida);
            Dividas.Add(divida2);

            var dias = divida.DiasEmAtraso();
            var valor = divida.ValorAtualizado();

            return Ok(Dividas);

        }
    }
}
