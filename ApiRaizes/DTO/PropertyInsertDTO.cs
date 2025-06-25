namespace ApiRaizes.DTO
{
    public enum StatusCultura
    {
        Monocultura,
        Policultura
    }
    public class PropertyInsertDTO
    {
        public string Nome { get; set; }
        public int CidadeId { get; set; }
        public int UsuarioId { get; set; }
        public int Status { get; set; }
        public int Tamanho { get; set; }
        public StatusCultura Cultura { get; set; }
        public int UnidadeMedidaId { get; set; }
    }
}
