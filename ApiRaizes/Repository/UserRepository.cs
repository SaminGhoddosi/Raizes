using ApiRaizes.Infrastructure;
using Dapper;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                  SELECT ID AS {nameof(UserEntity.Id)},
                                         NOME AS {nameof(UserEntity.Nome)},
                                   SOBRENOME AS {nameof(UserEntity.Sobrenome)},
                                        CPF AS {nameof(UserEntity.Cpf)},
                                      EMAIL AS {nameof(UserEntity.Email)},
                                      SENHA AS {nameof(UserEntity.Senha)},
                                     STATUS AS {nameof(UserEntity.Status)}
                                    FROM USUARIO
                ";

                IEnumerable<UserEntity> userList = await con.QueryAsync<UserEntity>(sql);
                return userList;
            }
        }
        public async Task Insert(UserInsertDTO user)
        {
            Connection _connection = new Connection();
            string sql = @$"
                 INSERT INTO USUARIO (NOME, SOBRENOME, CPF, EMAIL, SENHA, STATUS)
                                 VALUES (@Nome, @Sobrenome, @Cpf, @Email, @Senha, @Status)                                                         
            ";

            await _connection.Execute(sql, user);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM USUARIO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<UserEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                   SELECT ID AS {nameof(UserEntity.Id)},
                                          NOME AS {nameof(UserEntity.Nome)},
                                     SOBRENOME AS {nameof(UserEntity.Sobrenome)},
                                          CPF AS {nameof(UserEntity.Cpf)},
                                        EMAIL AS {nameof(UserEntity.Email)},
                                        SENHA AS {nameof(UserEntity.Senha)},
                                       STATUS AS {nameof(UserEntity.Status)}
                                     FROM USUARIO
                                    WHERE ID = @Id
                ";

                UserEntity aeroporto = await con.QueryFirstAsync<UserEntity>(sql, new { id });
                return aeroporto;
            }
        }
        public async Task Update(UserEntity user)
        {
            Connection _connection = new Connection();
            string sql = @$"
                                        UPDATE USUARIO
                                   SET NOME = @Nome,
                                       SOBRENOME = @Sobrenome,
                                       CPF = @Cpf,
                                       EMAIL = @Email,
                                       SENHA = @Senha,
                                       STATUS = @Status
                                     WHERE ID = @Id
                          ";

            await _connection.Execute(sql, user);
        }
    }
}
