using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IStockMovimentService
    {
        Task<MessageResponse> Delete(int id);
        Task<StockMovimentGetAllResponse> GetAll();
        Task<StockMovimentEntity> GetById(int id);
        Task<MessageResponse> Post(StockMovimentInsertDTO stockMoviment);
        Task<MessageResponse> Update(StockMovimentEntity stockMoviment);
    }
}