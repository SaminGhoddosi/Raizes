using Dapper;
using CRUD.Contracts.Repository;
using CRUD.DTO;
using CRUD.Entity;
using CRUD.InfraEstructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository
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
                           UsuarioId AS {nameof(PropertyEntity.UsuarioId)},
                           CidadeId AS {nameof(PropertyEntity.CidadeId)},
                           Status AS {nameof(PropertyEntity.Status)},
                           Tamanho AS {nameof(PropertyEntity.Tamanho)},
                           Cultura AS {nameof(PropertyEntity.Cultura)},
                           UnidadeMedidaId AS {nameof(PropertyEntity.UnidadeMedidaId)}
                          
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
                INSERT INTO PROPRIEDADE (NOME,USUARIOID,CIDADEID,STATUS,TAMANHO,CULTURA,UNIDADEMEDIDAID)
                            VALUE(@Nome,@UsuarioId,@CidadeId,@Status,@Tamanho,@Cultura,@UnidadeMedidaId)
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
                           UsuarioId AS {nameof(PropertyEntity.UsuarioId)},
                           CidadeId AS {nameof(PropertyEntity.CidadeId)},
                           Status AS {nameof(PropertyEntity.Status)},
                           Tamanho AS {nameof(PropertyEntity.Tamanho)},
                           Cultura AS {nameof(PropertyEntity.Cultura)},
                           UnidadeMedidaId AS {nameof(PropertyEntity.UnidadeMedidaId)}
                           
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
                    SET UsuarioId = @UsuarioId,
                    SET Status = @Status,
                    SET CidadeId = @CidadeId,
                    SET Status = @Status,
                    SET Tamanho = @Tamanho,
                    SET Cultura = @Cultura,
                    SET UnidadeMedidaId = @UnidadeMedidaId
    
                WHERE ID = @id
            ";
            //     SET CidadeId = @CidadeId
            await _connection.Execute(sql, property);
        }



    }
}
