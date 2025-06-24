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
    public class HarvestService : IHarvestService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            HarvestRepository _repository = new HarvestRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Colheita excluída com sucesso!"
            };
        }

        public async Task<HarvestGetAllResponse> GetAll()
        {
            HarvestRepository _repository = new HarvestRepository();
            return new HarvestGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<HarvestEntity> GetById(int id)
        {
            HarvestRepository _repository = new HarvestRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(HarvestInsertDTO harvest)
        {
            HarvestRepository _repository = new HarvestRepository();
            await _repository.Insert(harvest);
            return new MessageResponse
            {
                Message = "Colheita inserida com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(HarvestEntity harvest)
        {
            HarvestRepository _repository = new HarvestRepository();
            await _repository.Update(harvest);
            return new MessageResponse
            {
                Message = "Colheita alterada com sucesso"
            };
        }
    }
}