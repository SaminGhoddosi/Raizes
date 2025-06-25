using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IPlantingRawMaterialService
    {
        Task<MessageResponse> Delete(int id);
        Task<PlantingRawMaterialGetAllResponse> GetAll();
        Task<PlantingRawMaterialEntity> GetById(int id);
        Task<MessageResponse> Post(PlantingRawMaterialInsertDTO plantingRawMaterial);
        Task<MessageResponse> Update(PlantingRawMaterialEntity plantingRawMaterial);
    }
}