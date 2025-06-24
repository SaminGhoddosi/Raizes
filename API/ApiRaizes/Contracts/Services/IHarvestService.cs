using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IHarvestService
    {
        Task<MessageResponse> Delete(int id);
        Task<HarvestGetAllResponse> GetAll();
        Task<HarvestEntity> GetById(int id);
        Task<MessageResponse> Post(HarvestInsertDTO harvest);
        Task<MessageResponse> Update(HarvestEntity harvest);
    }
}