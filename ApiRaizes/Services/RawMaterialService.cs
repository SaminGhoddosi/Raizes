using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class RawMaterialService : IRawMaterialService
    {
        private readonly IRawMaterialRepository _repository;

        public RawMaterialService(IRawMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Insumo excluída com sucesso!"
            };
        }

        public async Task<RawMaterialGetAllResponse> GetAll()
        {
            return new RawMaterialGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<RawMaterialEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(RawMaterialInsertDTO RawMaterial)
        {
            await _repository.Insert(RawMaterial);
            return new MessageResponse
            {
                Message = "Insumo inserida com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(RawMaterialEntity RawMaterial)
        {
            await _repository.Update(RawMaterial);
            return new MessageResponse
            {
                Message = "Insumo alterada com sucesso"
            };
        }
    }
}

