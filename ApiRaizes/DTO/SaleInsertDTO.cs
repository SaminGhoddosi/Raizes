using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.DTO
{
    public class SaleInsertDTO
    {
        public int ColheitaId { get; set; }
        public int EspecieId { get; set; }
        public decimal Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int CompradorId { get; set; }
        public int UnidadeMedidaId { get; set; }
        public DateTime DataVenda { get; set; }

    }
}