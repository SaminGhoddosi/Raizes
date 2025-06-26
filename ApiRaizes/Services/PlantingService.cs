using ApiRaizes.Response;
using ApiRaizes.Repository;
using Microsoft.AspNetCore.Mvc;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Services
{
    public class PlantingService : IPlantingService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            PlantingRepository _repository = new PlantingRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Plantio excluído com sucesso!"
            };
        }

        public async Task<PlantingGetAllResponse> GetAll()
        {
            PlantingRepository _repository = new PlantingRepository();
            return new PlantingGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<PlantingEntity> GetById(int id)
        {
            PlantingRepository _repository = new PlantingRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(PlantingInsertDTO planting)
        {
            PlantingRepository _repository = new PlantingRepository();
            await _repository.Insert(planting);
            return new MessageResponse
            {
                Message = "Plantio inserido com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(PlantingEntity planting)
        {
            PlantingRepository _repository = new PlantingRepository();
            await _repository.Update(planting);
            return new MessageResponse
            {
                Message = "Plantio alterado com sucesso"
            };
        }
    }

}