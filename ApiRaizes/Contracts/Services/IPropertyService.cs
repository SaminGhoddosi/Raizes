using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IPropertyService
    {
        Task<MessageResponse> Delete(int id);
        Task<PropertyGetAllResponse> GetAll();
        Task<PropertyEntity> GetById(int id);
        Task<MessageResponse> Post(PropertyInsertDTO property);
        Task<MessageResponse> Update(PropertyEntity property);
    }
}