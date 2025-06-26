using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IPlantingService
    {
        Task<MessageResponse> Delete(int id);
        Task<PlantingGetAllResponse> GetAll();
        Task<PlantingEntity> GetById(int id);
        Task<MessageResponse> Post(PlantingInsertDTO planting);
        Task<MessageResponse> Update(PlantingEntity planting);
    }
}