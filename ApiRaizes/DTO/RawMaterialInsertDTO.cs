using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.DTO
{
    public class RawMaterialInsertDTO
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime DataDeValidade { get; set; }

        public string Descricao { get; set; }
        public int FornecedorId { get; set; }
    }
}
//Id int AI PK 
//PlantioId int 
//InsumoId int 
//Quantidade decimal(10,2) 
//DataAplicacao date