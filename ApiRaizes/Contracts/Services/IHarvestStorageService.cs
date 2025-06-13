using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IHarvestStorageService
    {
        Task<MessageResponse> Delete(int id);
        Task<HarvestStorageGetAllResponse> GetAll();
        Task<HarvestStorageEntity> GetById(int id);
        Task<MessageResponse> Post(HarvestStorageInsertDTO harvestStorage);
        Task<MessageResponse> Update(HarvestStorageEntity harvestStorage);
    }
}