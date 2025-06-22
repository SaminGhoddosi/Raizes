using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.Entity
{
    public class HarvestEntity
    {
        public int Id { get; set; }
        public int PlantioId { get; set; }
        public DateTime DataColheita { get; set; }
        public decimal Quantidade { get; set; }

        public int UnidadeMedidaId { get; set; }
        public string Observacao { get; set; }
    }
}
