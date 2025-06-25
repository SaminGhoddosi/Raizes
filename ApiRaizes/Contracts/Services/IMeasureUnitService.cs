using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Contracts.Services
{
    public interface IMeasureUnitService
    {
        Task<MessageResponse> Delete(int id);
        Task<MeasureUnitGetAllResponse> GetAll();
        Task<MeasureUnitEntity> GetById(int id);
        Task<MessageResponse> Post(MeasureUnitInsertDTO measureUnit);
        Task<MessageResponse> Update(MeasureUnitEntity measureUnit);
    }
}