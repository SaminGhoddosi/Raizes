using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Contracts.Repository;
using CRUD.DTO;
using CRUD.Entity;
using CRUD.InfraEstructure;
using Dapper;
using MySql.Data.MySqlClient;

namespace CRUD.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public async Task<IEnumerable<UsuarioEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(UsuarioEntity.Id)},
                           Nome AS {nameof(UsuarioEntity.Nome)},      
                           Sobrenome AS {nameof(UsuarioEntity.Sobrenome)},      
                           Cpf AS {nameof(UsuarioEntity.Cpf)},      
                           Email AS {nameof(UsuarioEntity.Email)},      
                           Senha AS {nameof(UsuarioEntity.Senha)},      
                           Status AS {nameof(UsuarioEntity.Status)}     

                    FROM usuario
                ";

                IEnumerable<UsuarioEntity> usuariolist = await con.QueryAsync<UsuarioEntity>(sql);

                return usuariolist;
            }
        }

        public async Task Insert(UsuarioInsertDTO usuario)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO USUARIO (NOME,SOBRENOME,CPF,EMAIL,SENHA,STATUS)
                            VALUE(@Nome,@Sobrenome,@Cpf,@Email,@Senha,@Status)
            ";

            await _connection.Execute(sql, usuario);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM USUARIO WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

        public async Task<UsuarioEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(UsuarioEntity.Id)},
                           Nome AS {nameof(UsuarioEntity.Nome)},      
                           Sobrenome AS {nameof(UsuarioEntity.Sobrenome)},      
                           Cpf AS {nameof(UsuarioEntity.Cpf)},      
                           Email AS {nameof(UsuarioEntity.Email)},      
                           Senha AS {nameof(UsuarioEntity.Senha)},      
                           Status AS {nameof(UsuarioEntity.Status)} 
                    FROM usuario
                    WHERE ID = @id
                ";

                UsuarioEntity usuario = await con.QueryFirstAsync<UsuarioEntity>(sql, new { id });
                return usuario;
            }

        }

        public async Task Update(UsuarioEntity usuario)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE USUARIO 
                    SET Nome = @Nome,
                    SET Sobrenome = @Sobrenome,
                    SET Cpf = @Cpf,
                    SET Email = @Email,
                    SET Senha = @Senha,
                    SET Status = @Status
                    
                WHERE ID = @id
            ";

            await _connection.Execute(sql, usuario);
        }
    }
}
