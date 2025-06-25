using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.Entity
{
    public class PlantingRawMaterialEntity
    {
        public int Id { get; set; }
        public int PlantioId { get; set; }
        public int InsumoId { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataAplicacao { get; set; }

    }
}
//Id int AI PK 
//PlantioId int 
//InsumoId int 
//Quantidade decimal(10,2) 
//DataAplicacao date