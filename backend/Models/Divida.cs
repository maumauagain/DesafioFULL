using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Models
{
    public class Divida
    {
        public Divida() { }
        public Divida(int id, int numero, string nomeDevedor, string cPFDevedor, decimal juros, decimal multa)
        {
            this.Id = id;
            this.Numero = numero;
            this.NomeDevedor = nomeDevedor;
            this.CPFDevedor = cPFDevedor;
            this.Juros = juros;
            this.Multa = multa;

        }
        public int Id { get; set; }
        public int Numero { get; set; }
        public string NomeDevedor { get; set; }
        public string CPFDevedor { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public List<Parcela> Parcelas { get; set; }

        public decimal RecuperarValorOriginal()
        {
            return Parcelas.Sum(parcela => parcela.Valor);
        }

        public int DiasEmAtraso()
        {
            var primeiroVencimento = Parcelas.OrderBy(parcela => parcela.DataVencimento).First().DataVencimento;
            return DiferencaEmDiasAPartirDeHoje(primeiroVencimento);
        }

        public decimal ValorAtualizado()
        {
            decimal acrescimo = 0;
            foreach (Parcela parcela in Parcelas)
            {
                acrescimo += (parcela.Valor / 100 * Juros / 30) * DiferencaEmDiasAPartirDeHoje(parcela.DataVencimento);
            }

            return RecuperarValorOriginal() + acrescimo + RecuperarMulta();
        }

        public decimal RecuperarMulta()
        {
            return RecuperarValorOriginal() / 100 * Multa;
        }

        private int DiferencaEmDiasAPartirDeHoje(DateTime vencimento)
        {
            var dias = DateTime.Now.Subtract(vencimento).Days;
            return dias > 0 ? dias : 0;
        }
    }
}
