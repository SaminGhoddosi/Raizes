﻿using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;
using ApiRaizes.Response.User;
using MinhaPrimeiraApi.Infrastructure;

namespace ApiRaizes.Services
{
    public class UserService : IUserService
    {

        private IUserRepository _repository;
        private IAuthentication _authentication;

        public UserService(IUserRepository repository, IAuthentication authentication)
        {
            _repository = repository;
            _authentication = authentication;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Usuário excluido com sucesso!"
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

        public async Task<UserLoginTokenResponse> Login(UserLoginDTO user)
        {
            user.Senha = Criptografy.Criptografia(user.Senha);
            UserEntity newUser = await _repository.Login(user);

            if (newUser == null)
            {
                throw new Exception("Usuário ou senha inválidos.");
            }

            string token = _authentication.GenerateToken(newUser);

            return new UserLoginTokenResponse
            {
                User = newUser,
                Token = token
            };
        }


        public async Task<MessageResponse> Post(UserInsertDTO user)
        {
            user.Senha = Criptografy.Criptografia(user.Senha);
            await _repository.Insert(user);
            return new MessageResponse
            {
                Message = "Usuário inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(UserEntity user)
        {
            await _repository.Update(user);
            return new MessageResponse
            {
                Message = "Usuário alterado com sucesso!"
            };
        }
    }
}