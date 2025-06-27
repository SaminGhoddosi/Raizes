using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Infrastructure;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.Repository
{
    public class MeasureUnitRepository : IMeasureUnitRepository
    {
        private IConnection _connection;

        public MeasureUnitRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM UNIDADEMEDIDA WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<MeasureUnitEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT Id AS {nameof(MeasureUnitEntity.Id)},
                           Nome AS {nameof(MeasureUnitEntity.Nome)},
                           Sigla AS {nameof(MeasureUnitEntity.Sigla)}
                    FROM UNIDADEMEDIDA
                ";
                IEnumerable<MeasureUnitEntity> measureList = await con.QueryAsync<MeasureUnitEntity>(sql);
                return measureList;
            }
        }

        public async Task<MeasureUnitEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT Id AS {nameof(MeasureUnitEntity.Id)},
                           Nome AS {nameof(MeasureUnitEntity.Nome)},
                           Sigla AS {nameof(MeasureUnitEntity.Sigla)}                 
                    FROM UNIDADEMEDIDA
                    WHERE ID = @id
                ";

                MeasureUnitEntity measure = await con.QueryFirstAsync<MeasureUnitEntity>(sql, new { id });
                return measure;
            }
        }

        public async Task Insert(MeasureUnitInsertDTO measureUnit)
        {
            string sql = @"
                INSERT INTO UNIDADEMEDIDA(NOME, SIGLA)
                VALUES (@Nome, @Sigla)
            ";
            await _connection.Execute(sql, measureUnit);
        }

        public async Task Update(MeasureUnitEntity measure)
        {
            string sql = @"
                UPDATE UNIDADEMEDIDA
                   SET Nome = @Nome,
                       Sigla = @Sigla
                 WHERE ID = @Id
            ";
            await _connection.Execute(sql, measure);
        }
    }
}