using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.Entity
{
    public enum StatusArmazenamento
    {
        Disponivel,
        Reservado,
        Vendido
    }
    public class HarvestStorageEntity
    {
        public int Id { get; set; }
        public int ColheitaId { get; set; }
        public decimal QuantidadeDisponivel { get; set; }
        public string LocalArmazenamento { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public StatusArmazenamento Status { get; set; }
    }
}
