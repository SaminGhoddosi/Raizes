using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ISoilTypeService
    {
        Task<MessageResponse> Delete(int id);
        Task<SoilTypeGetAllResponse> GetAll();
        Task<SoilTypeEntity> GetById(int id);
        Task<MessageResponse> Post(SoilTypeInsertDTO soilType);
        Task<MessageResponse> Update(SoilTypeEntity soilType);
    }
}