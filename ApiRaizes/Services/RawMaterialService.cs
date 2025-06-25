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
    public class RawMaterialService : IRawMaterialService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            RawMaterialRepository _repository = new RawMaterialRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Insumo excluído com sucesso!"
            };
        }

        public async Task<RawMaterialGetAllResponse> GetAll()
        {
            RawMaterialRepository _repository = new RawMaterialRepository();
            return new RawMaterialGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<RawMaterialEntity> GetById(int id)
        {
            RawMaterialRepository _repository = new RawMaterialRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(RawMaterialInsertDTO rawMaterial)
        {
            RawMaterialRepository _repository = new RawMaterialRepository();
            await _repository.Insert(rawMaterial);
            return new MessageResponse
            {
                Message = "Insumo inserido com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(RawMaterialEntity rawMaterial)
        {
            RawMaterialRepository _repository = new RawMaterialRepository();
            await _repository.Update(rawMaterial);
            return new MessageResponse
            {
                Message = "Insumo alterado com sucesso"
            };
        }
    }
}
