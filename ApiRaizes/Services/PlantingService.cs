using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class PlantingService : IPlantingService
    {
        private readonly IPlantingRepository _repository;

        public PlantingService(IPlantingRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Plantio excluído com sucesso!"
            };
        }

        public async Task<PlantingGetAllResponse> GetAll()
        {
            return new PlantingGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<PlantingEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(PlantingInsertDTO Planting)
        {
            await _repository.Insert(Planting);
            return new MessageResponse
            {
                Message = "Plantio inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(PlantingEntity Planting)
        {
            await _repository.Update(Planting);
            return new MessageResponse
            {
                Message = "Plantio alterado com sucesso"
            };
        }
    }
}
