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
    class SoilHistoricRepository : ISoilHistoricRepository
    {
        public async Task<IEnumerable<SoilHistoricEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                          SELECT ID     AS {nameof(SoilHistoricEntity.Id)},
                          TIPOSOLOID AS {nameof(SoilHistoricEntity.TipoSoloId)},
                          DATALEITURA AS {nameof(SoilHistoricEntity.DataLeitura)},
                          UMIDADE AS {nameof(SoilHistoricEntity.Umidade)},
                          OBSERVACOES AS {nameof(SoilHistoricEntity.Observacoes)},
                          PROPRIEDADEID AS {nameof(SoilHistoricEntity.PropriedadeId)}
                                      FROM HISTORICOSOLO
                ";
                IEnumerable<SoilHistoricEntity> soilHistoric = await con.QueryAsync<SoilHistoricEntity>(sql);
                return soilHistoric;
            }
        }
        public async Task Insert(SoilHistoricInsertDTO sale)
        {
            Connection _connection = new Connection();
            string sql = @$"
                INSERT INTO HISTORICOSOLO (TIPOSOLOID,DATALEITURA,UMIDADE,OBSERVACOES,PROPRIEDADEID)
                VALUES (@TipoSoloId,@DataLeitura,@Umidade,@Observacoes,@PropriedadeId)                                                         
            ";
            await _connection.Execute(sql, sale);
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
                              SELECT ID     AS {nameof(SoilHistoricEntity.Id)},
                              TIPOSOLOID    AS {nameof(SoilHistoricEntity.TipoSoloId)},
                              DATALEITURA   AS {nameof(SoilHistoricEntity.DataLeitura)},
                              UMIDADE       AS {nameof(SoilHistoricEntity.Umidade)},
                              OBSERVACOES   AS {nameof(SoilHistoricEntity.Observacoes)},
                              PROPRIEDADEID AS {nameof(SoilHistoricEntity.PropriedadeId)}
                                            FROM HISTORICOSOLO
                                            WHERE ID = @Id
                              
                            ";
                SoilHistoricEntity soilHistoric = await con.QueryFirstAsync<SoilHistoricEntity>(sql, new { id });
                return soilHistoric;
            }
        }
        public async Task Update(SoilHistoricEntity soilHistoric)
        {
            Connection _connection = new Connection();
            string sql = @$"
                             UPDATE HISTORICOSOLO
                                 SET TIPOSOLOID   = @TipoSoloId,
                                      DATALEITURA = @DataLeitura,
                                     UMIDADE      = @Umidade,
                                  OBSERVACOES     = @Observacoes,
                                  PROPRIEDADEID   = @PropriedadeId
                                       WHERE ID   = @Id;
                          ";
            await _connection.Execute(sql, soilHistoric);
        }
    }
}
