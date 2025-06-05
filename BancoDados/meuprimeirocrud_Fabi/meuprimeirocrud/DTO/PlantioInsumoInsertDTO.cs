using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meuprimeirocrud.DTO
{
    public class PlantioInsumoInsertDTO
    {
        public int PlantioId {  get; set; }
        public int InsumoId { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataAplicacao { get; set; }
    }
}
