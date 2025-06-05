using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroCrud.DTO
{
    public class SoilHistoricDTO
    {
        public int Id { get; set; }
        public int TipoSoloId { get; set; }
        public decimal PH { get; set; }
        public decimal Nutricao { get; set; }
        public string Observacoes { get; set; }
        public int PropriedadeId { get; set; }
    }
}
