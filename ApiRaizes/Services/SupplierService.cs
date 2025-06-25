using ApiRaizes.Response;
using ApiRaizes.Repository;
using Microsoft.AspNetCore.Mvc;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Services
{
    public class SupplierService : ISupplierService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            SupplierRepository _repository = new SupplierRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Fornecedor excluído com sucesso!"
            };
        }

        public async Task<SupplierGetAllResponse> GetAll()
        {
            SupplierRepository _repository = new SupplierRepository();
            return new SupplierGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<SupplierEntity> GetById(int id)
        {
            SupplierRepository _repository = new SupplierRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(SupplierInsertDTO supplier)
        {
            SupplierRepository _repository = new SupplierRepository();
            await _repository.Insert(supplier);
            return new MessageResponse
            {
                Message = "Fornecedor inserido com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(SupplierEntity supplier)
        {
            SupplierRepository _repository = new SupplierRepository();
            await _repository.Update(supplier);
            return new MessageResponse
            {
                Message = "Fornecedor alterado com sucesso"
            };
        }
    }
}
