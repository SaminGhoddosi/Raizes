using Dapper;
using MeuPrimeiroCrud.Contracts.Repository;
using MeuPrimeiroCrud.DTO;
using MeuPrimeiroCrud.Entity;
using MeuPrimeiroCrud.InfraEstructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroCrud.Repository
{
    public class PropertyRepository:IPropertyRepository
    {
        public async Task<IEnumerable<PropertyEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(PropertyEntity.Id)},
                           Nome AS {nameof(PropertyEntity.Nome)},
                           Endereco AS {nameof(PropertyEntity.Endereco)},
                           UsuarioId AS {nameof(PropertyEntity.UsuarioId)},
                           Status AS {nameof(PropertyEntity.Status)}
                          
                    FROM propriedade
                ";
                //CidadeId AS {nameof(PropertyEntity.CidadeId)}
                IEnumerable<PropertyEntity> propertyList = await con.QueryAsync<PropertyEntity>(sql);

                return propertyList;
            }
        }

        public async Task Insert(PropertyInsertDTO property)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO PROPRIEDADE (NOME,ENDERECO,USUARIOID,STATUS)
                            VALUE(@Nome,@Endereco,@UsuarioId,@Status)
            ";

            await _connection.Execute(sql, property);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM PROPRIEDADE WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }
        public async Task<PropertyEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(PropertyEntity.Id)},
                           Nome AS {nameof(PropertyEntity.Nome)},
                           Endereco AS {nameof(PropertyEntity.Endereco)},
                           UsuarioId AS {nameof(PropertyEntity.UsuarioId)},
                           Status AS {nameof(PropertyEntity.Status)},
                           
                    FROM propriedade
                    WHERE ID = @id
                ";
                //CidadeId AS {nameof(PropertyEntity.CidadeId)}
                PropertyEntity property = await con.QueryFirstAsync<PropertyEntity>(sql, new { id });
                return property;
            }
        }
        public async Task Update(PropertyEntity property)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE PROPRIEDADE 
                    SET Nome = @Nome,
                    SET Endereco = @Endereco,
                    SET UsuarioId = @UsuarioId,
                    SET Status = @Status
                WHERE ID = @id
            ";
            //     SET CidadeId = @CidadeId
            await _connection.Execute(sql, property);
        }



    }
}
