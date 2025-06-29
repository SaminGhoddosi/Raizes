namespace ApiRaizes.Entity
{
    public class SaleEntity
    {
        public int Id { get; set; }
        public int ColheitaId { get; set; }
        public int EspecieId { get; set; }
        public decimal Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }

        public int CompradorId { get; set; }
        public int UnidadeMedidaId { get; set; }
        public DateTime DataVenda { get; set; }

    }
}