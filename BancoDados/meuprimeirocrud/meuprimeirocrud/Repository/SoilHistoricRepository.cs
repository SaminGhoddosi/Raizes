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
                           PH AS {nameof(SoilHistoricEntity.PH)},
                           Nutricao AS {nameof(SoilHistoricEntity.Nutricao)},
                           Observacoes AS {nameof(SoilHistoricEntity.Observacoes)}
                           PropriedadeId AS {nameof(SoilHistoricEntity.PropriedadeId)}
                          
                    FROM historicosolo
                ";

                IEnumerable<SoilHistoricEntity> soilHistoricList = await con.QueryAsync<SoilHistoricEntity>(sql);
                return soilHistoricList;
            }
        }
        public async Task Insert(SoilHistoricDTO soilHistoric)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO PROPRIEDADE (TIPOSOLOID,PH,NUTRICAO,OBSERVACOES,PROPRIEDADEID)
                            VALUE(@TipoSoloId,@PH,@Nutricao,@Observacoes,@PropriedadeId)
            ";

            await _connection.Execute(sql, soilHistoric);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM PROPRIEDADE WHERE ID = @id";

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
                           PH AS {nameof(SoilHistoricEntity.PH)},
                           Nutricao AS {nameof(SoilHistoricEntity.Nutricao)},
                           Observacoes AS {nameof(SoilHistoricEntity.Observacoes)}
                           PropriedadeId AS {nameof(SoilHistoricEntity.PropriedadeId)}
                           PropriedadeId AS {nameof(SoilHistoricEntity.PropriedadeId)}
                    FROM historicosolo
                    WHERE ID = @id
                ";
                //CidadeId AS {nameof(PropertyEntity.CidadeId)}
                SoilHistoricEntity soilHistoric = await con.QueryFirstAsync<SoilHistoricEntity>(sql, new { id });
                return soilHistoric;
            }
        }
        public async Task Update(SoilHistoricEntity soilHistoric)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE PROPRIEDADE 
                    SET TiposoloId = @Nome,
                    SET PH = @Endereco,
                    SET UsuarioId = @UsuarioId,
                    SET Status = @Status
                WHERE ID = @id
            ";
            //     SET CidadeId = @CidadeId
            await _connection.Execute(sql, soilHistoric);
        }


    }
