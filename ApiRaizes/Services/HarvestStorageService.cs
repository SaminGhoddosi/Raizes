using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class HarvestStorageService : IHarvestStorageService
    {
        private readonly IHarvestStorageRepository _repository;

        public HarvestStorageService(IHarvestStorageRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "armazenamento de colheita excluída com sucesso!"
            };
        }

        public async Task<HarvestStorageGetAllResponse> GetAll()
        {
            return new HarvestStorageGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<HarvestStorageEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(HarvestStorageInsertDTO harvestStorage)
        {
            await _repository.Insert(harvestStorage);
            return new MessageResponse
            {
                Message = "armazenamento de colheita inserida com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(HarvestStorageEntity harvestStorage)
        {
            await _repository.Update(harvestStorage);
            return new MessageResponse
            {
                Message = "armazenamento de colheita alterada com sucesso"
            };
        }
    }
}
