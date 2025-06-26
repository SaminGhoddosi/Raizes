using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Usuário excluído com sucesso!"
            };
        }

        public async Task<UserGetAllResponse> GetAll()
        {
            return new UserGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<UserEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(UserInsertDTO User)
        {
            await _repository.Insert(User);
            return new MessageResponse
            {
                Message = "Usuário inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(UserEntity User)
        {
            await _repository.Update(User);
            return new MessageResponse
            {
                Message = "Usuário alterado com sucesso"
            };
        }
    }
}
