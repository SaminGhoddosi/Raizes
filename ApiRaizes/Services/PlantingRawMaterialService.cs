using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class PlantingRawMaterialService : IPlantingRawMaterialService
    {
        private readonly IPlantingRawMaterialRepository _repository;

        public PlantingRawMaterialService(IPlantingRawMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Insumo excluído do plantio com sucesso!"
            };
        }

        public async Task<PlantingRawMaterialGetAllResponse> GetAll()
        {
            return new PlantingRawMaterialGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<PlantingRawMaterialEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(PlantingRawMaterialInsertDTO plantingRawMaterial)
        {
            await _repository.Insert(plantingRawMaterial);
            return new MessageResponse
            {
                Message = "Insumo inserido no plantio com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(PlantingRawMaterialEntity PlantingRawMaterial)
        {
            await _repository.Update(PlantingRawMaterial);
            return new MessageResponse
            {
                Message = "Insumo do plantio atualizado com sucesso!"
            };
        }
    }
}
