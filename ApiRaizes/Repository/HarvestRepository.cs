using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
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
    class HarvestRepository : IHarvestRepository
    {
        public async Task<IEnumerable<HarvestEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                  SELECT ID AS {nameof(HarvestEntity.Id)},
                                  PLANTIOID AS {nameof(HarvestEntity.PlantioId)},
                               DATACOLHEITA AS {nameof(HarvestEntity.DataColheita)},
                                 QUANTIDADE AS {nameof(HarvestEntity.Quantidade)},
                            UNIDADEMEDIDAID AS {nameof(HarvestEntity.UnidadeMedidaId)},
                                 OBSERVACAO AS {nameof(HarvestEntity.Observacao)}
                                          FROM COLHEITA
                ";
                IEnumerable<HarvestEntity> harvestList = await con.QueryAsync<HarvestEntity>(sql);
                return harvestList;
            }
        }
        public async Task Insert(HarvestInsertDTO harvest)
        {
            Connection _connection = new Connection();
            string sql = @$"
                INSERT INTO COLHEITA (PLANTIOID,DATACOLHEITA,QUANTIDADE,UNIDADEMEDIDAID,OBSERVACAO)
                                VALUES (@PlantioId,@DataColheita,@Quantidade,@UnidadeMedidaId,@Observacao)                                                         
            ";
            await _connection.Execute(sql, harvest);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM COLHEITA WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<HarvestEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                  SELECT ID AS {nameof(HarvestEntity.Id)},
                                  PLANTIOID AS {nameof(HarvestEntity.PlantioId)},
                               DATACOLHEITA AS {nameof(HarvestEntity.DataColheita)},
                                 QUANTIDADE AS {nameof(HarvestEntity.Quantidade)},
                            UNIDADEMEDIDAID AS {nameof(HarvestEntity.UnidadeMedidaId)},
                                 OBSERVACAO AS {nameof(HarvestEntity.Observacao)}
                                          FROM COLHEITA
                                      WHERE ID = @Id
                              
                            ";
                HarvestEntity aeroporto = await con.QueryFirstAsync<HarvestEntity>(sql, new { id });
                return aeroporto;
            }
        }
        public async Task Update(HarvestEntity harvest)
        {
            Connection _connection = new Connection();
            string sql = @$"
                                        UPDATE   COLHEITA
                                 SET PLANTIOID = @PlantioId,
                                  DATACOLHEITA = @DataColheita,
                                    QUANTIDADE = @Quantidade,
                               UNIDADEMEDIDAID = @UnidadeMedidaId,
                                    OBSERVACAO = @Observacao
                                      WHERE ID = @Id
                          ";
            await _connection.Execute(sql, harvest);
        }
    }
}
