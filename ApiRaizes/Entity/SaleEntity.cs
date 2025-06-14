using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRaizes.DTO
{
    public class SaleEntity
    {
        public int Id { get; set; }
        public int ColheitaId { get; set; }
        public int EspecieId { get; set; }
        public decimal Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }
        [BindNever]
        public decimal PrecoTotal { get; set; }

        public int CompradorId { get; set; }
        public int UnidadeMedidaId { get; set; }
        public DateTime DataVenda { get; set; }

    }
}