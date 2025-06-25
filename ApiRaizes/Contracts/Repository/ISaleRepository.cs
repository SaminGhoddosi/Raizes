using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    interface ISaleRepository
    {
        Task<IEnumerable<SaleEntity>> GetAll();

        Task<SaleEntity> GetById(int id);

        Task Insert(SaleInsertDTO sale);

        Task Delete(int id);

        Task Update(SaleEntity sale);
    }
}
