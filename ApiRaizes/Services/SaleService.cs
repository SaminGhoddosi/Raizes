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
    public class SaleService : ISaleService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            SaleRepository _repository = new SaleRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Venda excluída com sucesso!"
            };
        }

        public async Task<SaleGetAllResponse> GetAll()
        {
            SaleRepository _repository = new SaleRepository();
            return new SaleGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<SaleEntity> GetById(int id)
        {
            SaleRepository _repository = new SaleRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(SaleInsertDTO sale)
        {
            SaleRepository _repository = new SaleRepository();
            await _repository.Insert(sale);
            return new MessageResponse
            {
                Message = "Venda inserida com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(SaleEntity sale)
        {
            SaleRepository _repository = new SaleRepository();
            await _repository.Update(sale);
            return new MessageResponse
            {
                Message = "Venda alterada com sucesso"
            };
        }
    }
}