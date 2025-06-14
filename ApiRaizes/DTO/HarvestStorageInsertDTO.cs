using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.DTO
{
    public enum StatusDoArmazenamento
    {
        Disponivel,
        Reservado,
        Vendido
    }
    public class HarvestStorageInsertDTO
    {
        public int ColheitaId { get; set; }
        public decimal QuantidadeDisponivel { get; set; }
        public string LocalArmazenamento { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public StatusDoArmazenamento Status { get; set; }

    }
}
