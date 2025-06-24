using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface ICityService
    {
        Task<MessageResponse> Delete(int id);
        Task<CityGetAllResponse> GetAll();
        Task<CityEntity> GetById(int id);
        Task<MessageResponse> Post(CityInsertDTO city);
        Task<MessageResponse> Update(CityEntity city);
    }
}
