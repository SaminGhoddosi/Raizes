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
    class SaleRepository : ISaleRepository
    {
        public async Task<IEnumerable<SaleEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                          SELECT ID AS {nameof(SaleEntity.Id)},
                         COLHEITAID AS {nameof(SaleEntity.ColheitaId)},
                          ESPECIEID AS {nameof(SaleEntity.EspecieId)},
                         QUANTIDADE AS {nameof(SaleEntity.Quantidade)},
                      PRECOUNITARIO AS {nameof(SaleEntity.PrecoUnitario)},
                         PRECOTOTAL AS {nameof(SaleEntity.PrecoTotal)},
                        COMPRADORID AS {nameof(SaleEntity.CompradorId)},
                    UNIDADEMEDIDAID AS {nameof(SaleEntity.UnidadeMedidaId)},
                          DATAVENDA AS {nameof(SaleEntity.DataVenda)}
                                      FROM VENDA
                ";
                IEnumerable<SaleEntity> saleList = await con.QueryAsync<SaleEntity>(sql);
                return saleList;
            }
        }
        public async Task Insert(SaleInsertDTO sale)
        {
            Connection _connection = new Connection();
            string sql = @$"
                INSERT INTO VENDA (COLHEITAID,ESPECIEID,QUANTIDADE,PRECOUNITARIO,COMPRADORID,UNIDADEMEDIDAID,DATAVENDA)
                VALUES (@ColheitaId,@EspecieId,@Quantidade,@PrecoUnitario,@CompradorId,@UnidadeMedidaId,@DataVenda)                                                         
            ";
            await _connection.Execute(sql, sale);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM VENDA WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<SaleEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                             SELECT ID AS {nameof(SaleEntity.Id)},
                         COLHEITAID AS {nameof(SaleEntity.ColheitaId)},
                          ESPECIEID AS {nameof(SaleEntity.EspecieId)},
                         QUANTIDADE AS {nameof(SaleEntity.Quantidade)},
                      PRECOUNITARIO AS {nameof(SaleEntity.PrecoUnitario)},
                         PRECOTOTAL AS {nameof(SaleEntity.PrecoTotal)},
                        COMPRADORID AS {nameof(SaleEntity.CompradorId)},
                    UNIDADEMEDIDAID AS {nameof(SaleEntity.UnidadeMedidaId)},
                          DATAVENDA AS {nameof(SaleEntity.DataVenda)}
                                      FROM VENDA
                                WHERE ID = @Id
                              
                            ";
                SaleEntity venda = await con.QueryFirstAsync<SaleEntity>(sql, new { id });
                return venda;
            }
        }
        public async Task Update(SaleEntity venda)
        {
            Connection _connection = new Connection();
            string sql = @$"
                                         UPDATE   VENDA
                                 SET COLHEITAID = @ColheitaId,
                                      ESPECIEID = @EspecieId,
                                     QUANTIDADE = @Quantidade,
                                  PRECOUNITARIO = @PrecoUnitario,
                                    COMPRADORID = @CompradorId,
                                UNIDADEMEDIDAID = @UnidadeMedidaId,
                                      DATAVENDA = @DataVenda
                                       WHERE ID = @Id;
                          ";
            await _connection.Execute(sql, venda);
        }
    }
}
