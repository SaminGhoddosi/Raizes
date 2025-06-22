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
    public class CidadeRepository : ICidadeRepository
    {

        public async Task<IEnumerable<cidadeEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(cidadeEntity.Id)},
                           Nome AS {nameof(cidadeEntity.Nome)},
                           Estado AS {nameof(cidadeEntity.Estado)},
                           Pais AS {nameof(cidadeEntity.Pais)},
                           Regiao AS {nameof(cidadeEntity.Regiao)}
                    FROM cidade
                ";

                IEnumerable<cidadeEntity> citylist = await con.QueryAsync<cidadeEntity>(sql);

                return citylist;
            }
        }

        public async Task Insert(CidadeInsertDTO cidade)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO CIDADE (NOME,ESTADO,PAIS,REGIAO)
                            VALUE(@Nome,@Estado,@Pais,@Regiao)
            ";

            await _connection.Execute(sql, cidade);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM CIDADE WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

        public async Task<cidadeEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(cidadeEntity.Id)},
                           Nome AS {nameof(cidadeEntity.Nome)},
                           Estado AS {nameof(cidadeEntity.Estado)},
                           Pais AS {nameof(cidadeEntity.Pais)},
                           Regiao AS {nameof(cidadeEntity.Regiao)}
                    FROM cidade
                    WHERE ID = @id
                ";

                cidadeEntity cidade = await con.QueryFirstAsync<cidadeEntity>(sql, new { id });
                return cidade;
            }

        }

        public async Task Update(cidadeEntity cidade)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE CIDADE 
                    SET Nome = @Nome,
                    SET Estado = @Estado,
                    SET Pais = @Pais,
                    SET Regiao = @Regiao
                WHERE ID = @id
            ";

            await _connection.Execute(sql, cidade);
        }

   
    }
}
