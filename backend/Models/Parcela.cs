using System;

namespace backend.Models
{
    public class Parcela
    {
        public Parcela() { }

        public Parcela(int id, int numero, DateTime dataVencimento, Decimal valor, int dividaId)
        {
            this.Id = id;
            this.Numero = numero;
            this.DataVencimento = dataVencimento;
            this.Valor = valor;
            this.DividaId = dividaId;
        }
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime DataVencimento { get; set; }
        public Decimal Valor { get; set; }
        public int DividaId { get; set; }
        public Divida Divida { get; set; }
    }
}
