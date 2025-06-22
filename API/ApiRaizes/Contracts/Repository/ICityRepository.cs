using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface ICityRepository
    {
        Task<IEnumerable<CityEntity>> GetAll();

        Task<CityEntity> GetById(int id);

        Task Insert(CityInsertDTO harvest);

        Task Delete(int id);

        Task Update(CityEntity harvest);
    }
}
