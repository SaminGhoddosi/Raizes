using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface ISpeciesRepository
    {
        Task<IEnumerable<SpeciesEntity>> GetAll();
        Task<SpeciesEntity> GetById(int id);
        Task Insert(SpeciesInsertDTO Species);
        Task Update(SpeciesEntity Species);
        Task Delete(int id);
    }
}
