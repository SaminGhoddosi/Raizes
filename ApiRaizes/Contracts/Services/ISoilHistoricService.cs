using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ISoilHistoricService
    {
        Task<MessageResponse> Delete(int id);
        Task<SoilHistoricGetAllResponse> GetAll();
        Task<SoilHistoricEntity> GetById(int id);
        Task<MessageResponse> Post(SoilHistoricInsertDTO rawMaterialStock);
        Task<MessageResponse> Update(SoilHistoricEntity rawMaterialStock);
    }
}