using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ISaleService
    {
        Task<MessageResponse> Delete(int id);
        Task<SaleGetAllResponse> GetAll();
        Task<SaleEntity> GetById(int id);
        Task<MessageResponse> Post(SaleInsertDTO sale);
        Task<MessageResponse> Update(SaleEntity sale);
    }
}