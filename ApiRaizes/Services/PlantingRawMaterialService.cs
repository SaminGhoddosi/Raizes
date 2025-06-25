using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using ApiRaizes.Repository;
using ApiRaizes.Response;
using ApiRaizes.Response;
using ApiRaizes.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApiRaizes.Services
{
    public class PlantingRawMaterialService : IPlantingRawMaterialService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            PlantingRawMaterialRepository _repository = new PlantingRawMaterialRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Insumo excluído do plantio com sucesso!"
            };
        }

        public async Task<PlantingRawMaterialGetAllResponse> GetAll()
        {
            PlantingRawMaterialRepository _repository = new PlantingRawMaterialRepository();
            return new PlantingRawMaterialGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<PlantingRawMaterialEntity> GetById(int id)
        {
            PlantingRawMaterialRepository _repository = new PlantingRawMaterialRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(PlantingRawMaterialInsertDTO plantingRawMaterial)
        {
            PlantingRawMaterialRepository _repository = new PlantingRawMaterialRepository();
            await _repository.Insert(plantingRawMaterial);
            return new MessageResponse
            {
                Message = "Insumo inserido no plantio com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(PlantingRawMaterialEntity plantingRawMaterial)
        {
            PlantingRawMaterialRepository _repository = new PlantingRawMaterialRepository();
            await _repository.Update(plantingRawMaterial);
            return new MessageResponse
            {
                Message = "Insumo do plantio alterado com sucesso"
            };
        }
    }
}
