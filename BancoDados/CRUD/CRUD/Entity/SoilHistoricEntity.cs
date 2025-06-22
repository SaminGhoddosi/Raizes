using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Entity
{
    public class SoilHistoricEntity
    {
        public int Id { get; set; }
        public int TipoSoloId { get; set; }
        public decimal Umidade { get; set; }
        public string Observacoes { get; set; }
        public int PropriedadeId { get; set; }
        public DateTime DataLeitura { get; set; }
    }
}
