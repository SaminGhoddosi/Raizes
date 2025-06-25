using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.Contracts.Repository
{
    public interface IPlantingRawMaterialRepository
    {
        Task<IEnumerable<PlantingRawMaterialEntity>> GetAll();

        Task<PlantingRawMaterialEntity> GetById(int id);
        Task Insert(PlantingRawMaterialInsertDTO planting);
        Task Delete(int id);

        Task Update(PlantingRawMaterialEntity planting);
    }
}
