using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class SoilHistoricService : ISoilHistoricService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            SoilHistoricRepository _repository = new SoilHistoricRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Historico do solo excluído com sucesso!"
            };
        }

        public async Task<SoilHistoricGetAllResponse> GetAll()
        {
            SoilHistoricRepository _repository = new SoilHistoricRepository();
            return new SoilHistoricGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<SoilHistoricEntity> GetById(int id)
        {
            SoilHistoricRepository _repository = new SoilHistoricRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(SoilHistoricInsertDTO soilHistoric)
        {
            SoilHistoricRepository _repository = new SoilHistoricRepository();
            await _repository.Insert(soilHistoric);
            return new MessageResponse
            {
                Message = "Histórico do solo inserido com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(SoilHistoricEntity soilHistoric)
        {
            SoilHistoricRepository _repository = new SoilHistoricRepository();
            await _repository.Update(soilHistoric);
            return new MessageResponse
            {
                Message = "Histórico do solo alterado com sucesso!"
            };
        }
    }
}