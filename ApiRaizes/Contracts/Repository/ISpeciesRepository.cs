using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    interface ISpeciesRepository
    {
        Task<IEnumerable<SpeciesEntity>> GetAll();

        Task<SpeciesEntity> GetById(int id);

        Task Insert(SpeciesInsertDTO species);

        Task Delete(int id);

        Task Update(SpeciesEntity species);
    }
}

