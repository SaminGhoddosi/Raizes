using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IRawMaterialStockService
    {
        Task<MessageResponse> Delete(int id);
        Task<RawMaterialStockGetAllResponse> GetAll();
        Task<RawMaterialStockEntity> GetById(int id);
        Task<MessageResponse> Post(RawMaterialStockInsertDTO rawMaterialStock);
        Task<MessageResponse> Update(RawMaterialStockEntity rawMaterialStock);
    }
}