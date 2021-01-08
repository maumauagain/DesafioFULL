namespace backend.DTO
{
    public class DividaDTO
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string NomeDevedor { get; set; }
        public int NumParcelas { get; set; }
        public decimal ValorOriginal { get; set; }
        public int DiasEmAtraso { get; set; }
        public decimal ValorAtualizado { get; set; }
    }
}
