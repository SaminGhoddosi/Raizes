using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using ApiRaizes.Repository;
using ApiRaizes.Response;
using ApiRaizes.Response;
using Microsoft.AspNetCore.Mvc;

namespace ApiRaizes.Services
{
    public class MeasureUnitService : IMeasureUnitService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            MeasureUnitRepository _repository = new MeasureUnitRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Unidade de medida excluída com sucesso!"
            };
        }

        public async Task<MeasureUnitGetAllResponse> GetAll()
        {
            MeasureUnitRepository _repository = new MeasureUnitRepository();
            return new MeasureUnitGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<MeasureUnitEntity> GetById(int id)
        {
            MeasureUnitRepository _repository = new MeasureUnitRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(MeasureUnitInsertDTO measure)
        {
            MeasureUnitRepository _repository = new MeasureUnitRepository();
            await _repository.Insert(measure);
            return new MessageResponse
            {
                Message = "Unidade de medida inserida com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(MeasureUnitEntity measure)
        {
            MeasureUnitRepository _repository = new MeasureUnitRepository();
            await _repository.Update(measure);
            return new MessageResponse
            {
                Message = "Unidade de medida alterada com sucesso"
            };
        }
    }
}
