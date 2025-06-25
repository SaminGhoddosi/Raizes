namespace ApiRaizes.Entity
{
    public enum StatusCultura2
    {
        Monocultura,
        Policultura
    }
    public class PropertyEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CidadeId { get; set; }
        public int UsuarioId { get; set; }
        public int Status { get; set; }
        public int Tamanho { get; set; }
        public StatusCultura2 Cultura { get; set; }
        public int UnidadeMedidaId { get; set; }
    }
}