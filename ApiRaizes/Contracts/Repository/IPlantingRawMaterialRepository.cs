using ApiRaizes.DTO;
using ApiRaizes.Entity;

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
