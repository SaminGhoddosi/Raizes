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
    public class SpeciesService : ISpeciesService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            SpeciesRepository _repository = new SpeciesRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Espécie excluída com sucesso!"
            };
        }

        public async Task<SpeciesGetAllResponse> GetAll()
        {
            SpeciesRepository _repository = new SpeciesRepository();
            return new SpeciesGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<SpeciesEntity> GetById(int id)
        {
            SpeciesRepository _repository = new SpeciesRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(SpeciesInsertDTO species)
        {
            SpeciesRepository _repository = new SpeciesRepository();
            await _repository.Insert(species);
            return new MessageResponse
            {
                Message = "Espécie inserida com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(SpeciesEntity species)
        {
            SpeciesRepository _repository = new SpeciesRepository();
            await _repository.Update(species);
            return new MessageResponse
            {
                Message = "Espécie alterada com sucesso"
            };
        }
    }
}