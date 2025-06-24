using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface IRawMaterialStockRepository
    {
        Task<IEnumerable<RawMaterialStockEntity>> GetAll();

        Task<RawMaterialStockEntity> GetById(int id);

        Task Insert(RawMaterialStockInsertDTO harvest);

        Task Delete(int id);

        Task Update(RawMaterialStockEntity harvest);
    }
}
