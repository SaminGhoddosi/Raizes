using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IRawMaterialService
    {
        Task<MessageResponse> Delete(int id);
        Task<RawMaterialGetAllResponse> GetAll();
        Task<RawMaterialEntity> GetById(int id);
        Task<MessageResponse> Post(RawMaterialInsertDTO rawMaterial);
        Task<MessageResponse> Update(RawMaterialEntity rawMaterial);
    }
}