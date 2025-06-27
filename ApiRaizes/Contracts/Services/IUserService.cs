using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;
using ApiRaizes.Response.User;

namespace ApiRaizes.Contracts.Services
{
    public interface IUserService
    {
        Task<MessageResponse> Delete(int id);
        Task<UserGetAllResponse> GetAll();
        Task<UserEntity> GetById(int id);
        Task<MessageResponse> Post(UserInsertDTO user);
        Task<MessageResponse> Update(UserEntity user);
        Task<UserLoginTokenResponse> Login(UserLoginDTO user);
    }
}