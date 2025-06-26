using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Fornecedor excluído com sucesso!"
            };
        }

        public async Task<SupplierGetAllResponse> GetAll()
        {
            return new SupplierGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<SupplierEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(SupplierInsertDTO Supplier)
        {
            await _repository.Insert(Supplier);
            return new MessageResponse
            {
                Message = "Fornecedor inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(SupplierEntity Supplier)
        {
            await _repository.Update(Supplier);
            return new MessageResponse
            {
                Message = "Fornecedor alterado com sucesso"
            };
        }
    }
}
