using System;

namespace backend.Models.Entities
{
    public class Parcela : BaseEntity
    {
        public Parcela() { }

        public Parcela(int id, int numero, DateTime dataVencimento, Decimal valor, int dividaId, bool removed, DateTime createAt)
        {
            this.Id = id;
            this.Numero = numero;
            this.DataVencimento = dataVencimento;
            this.Valor = valor;
            this.DividaId = dividaId;
            this.Removed = removed;
            this.CreateAt = createAt;
        }
        public int Numero { get; set; }
        public DateTime DataVencimento { get; set; }
        public Decimal Valor { get; set; }
        public int DividaId { get; set; }
        public Divida Divida { get; set; }
    }
}
