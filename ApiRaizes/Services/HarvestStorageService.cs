using ApiRaizes.Response;
using ApiRaizes.Repository;
using Microsoft.AspNetCore.Mvc;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class HarvestStorageService : IHarvestStorageService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            HarvestStorageRepository _repository = new HarvestStorageRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Armazenamento da colheita excluído com sucesso!"
            };
        }

        public async Task<HarvestStorageGetAllResponse> GetAll()
        {
            HarvestStorageRepository _repository = new HarvestStorageRepository();
            return new HarvestStorageGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<HarvestStorageEntity> GetById(int id)
        {
            HarvestStorageRepository _repository = new HarvestStorageRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(HarvestStorageInsertDTO harvestStorage)
        {
            HarvestStorageRepository _repository = new HarvestStorageRepository();
            await _repository.Insert(harvestStorage);
            return new MessageResponse
            {
                Message = "Armazenamento da colheita inserido com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(HarvestStorageEntity harvestStorage)
        {
            HarvestStorageRepository _repository = new HarvestStorageRepository();
            await _repository.Update(harvestStorage);
            return new MessageResponse
            {
                Message = "Armazenamento da colheira alterado com sucesso"
            };
        }
    }
}