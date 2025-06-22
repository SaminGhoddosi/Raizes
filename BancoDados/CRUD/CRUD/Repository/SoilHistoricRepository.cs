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
    public class SoilHistoricRepository : ISoilHistoricRepository
    {
        public async Task<IEnumerable<SoilHistoricEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(SoilHistoricEntity.Id)},
                           TipoSoloId AS {nameof(SoilHistoricEntity.TipoSoloId)},
                           Observacoes AS {nameof(SoilHistoricEntity.Observacoes)},
                           PropriedadeId AS {nameof(SoilHistoricEntity.PropriedadeId)},
                           Umidade AS {nameof(SoilHistoricEntity.Umidade)},
                           DataLeitura AS {nameof(SoilHistoricEntity.DataLeitura)}
                          
                    FROM historicosolo
                ";

                IEnumerable<SoilHistoricEntity> soilHistoricList = await con.QueryAsync<SoilHistoricEntity>(sql);
                return soilHistoricList;
            }
        }
        public async Task Insert(SoilHistoricInsertDTO soilHistoric)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO HISTORICOSOLO (TIPOSOLOID,OBSERVACOES,PROPRIEDADEID,UMIDADE,DATALEITURA)
                            VALUE(@TipoSoloId,@Observacoes,@PropriedadeId,@Umidade,@DataLeitura)
            ";

            await _connection.Execute(sql, soilHistoric);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM HISTORICOSOLO WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }
        public async Task<SoilHistoricEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                   SELECT Id AS {nameof(SoilHistoricEntity.Id)},
                           TipoSoloId AS {nameof(SoilHistoricEntity.TipoSoloId)},
                           Observacoes AS {nameof(SoilHistoricEntity.Observacoes)},
                           PropriedadeId AS {nameof(SoilHistoricEntity.PropriedadeId)},
                           Umidade AS {nameof(SoilHistoricEntity.Umidade)},
                           DataLeitura AS {nameof(SoilHistoricEntity.DataLeitura)}
 
                    FROM historicosolo
                    WHERE ID = @id
                ";
        
                SoilHistoricEntity soilHistoric = await con.QueryFirstAsync<SoilHistoricEntity>(sql, new { id });
                return soilHistoric;
            }
        }
        public async Task Update(SoilHistoricEntity soilHistoric)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE HISTORICOSOLO 
                    SET TipoSoloId = @TipoSoloId,
                    SET Observacoes = @Observacoes,
                    SET PropriedadeId = @PropriedadeId,
                    SET Umidade = @Umidade,
                    SET DataLeitura = @DataLeitura
                WHERE ID = @id
            ";
            
            await _connection.Execute(sql, soilHistoric);
        }


    }
}
