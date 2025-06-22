using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Entity
{
    public class InsumoEstoqueEntity
    {
        public int Id { get; set; }
        public int PropriedadeId { get; set; }
        public int InsumoId { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}
