using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ISupplierService
    {
        Task<MessageResponse> Delete(int id);
        Task<SupplierGetAllResponse> GetAll();
        Task<SupplierEntity> GetById(int id);
        Task<MessageResponse> Post(SupplierInsertDTO supplier);
        Task<MessageResponse> Update(SupplierEntity supplier);
    }
}