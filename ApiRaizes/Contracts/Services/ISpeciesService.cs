using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ISpeciesService
    {
        Task<MessageResponse> Delete(int id);
        Task<SpeciesGetAllResponse> GetAll();
        Task<SpeciesEntity> GetById(int id);
        Task<MessageResponse> Post(SpeciesInsertDTO species);
        Task<MessageResponse> Update(SpeciesEntity species);
    }
}