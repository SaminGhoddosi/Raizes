using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Infrastructure;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class RawMaterialStockRepository : IRawMaterialStockRepository
    {
        public async Task<IEnumerable<RawMaterialStockEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(RawMaterialStockEntity.Id)},
                                  PROPRIEDADEID AS {nameof(RawMaterialStockEntity.PropriedadeId)},
                                     INSUMOID AS {nameof(RawMaterialStockEntity.InsumoId)},
                                   QUANTIDADE AS {nameof(RawMaterialStockEntity.Quantidade)},
                               PRECOUNITARIO AS {nameof(RawMaterialStockEntity.PrecoUnitario)},
                                  PRECOTOTAL AS {nameof(RawMaterialStockEntity.PrecoTotal)},
                            DATAMOVIMENTACAO AS {nameof(RawMaterialStockEntity.DataMovimentacao)}
                    FROM ESTOQUEINSUMO
";

                IEnumerable<RawMaterialStockEntity> rawMaterialStockList = await con.QueryAsync<RawMaterialStockEntity>(sql);
                return rawMaterialStockList;
            }
        }
        public async Task Insert(RawMaterialStockInsertDTO rawMaterialStock)
        {
            Connection _connection = new Connection();
            string sql = @$"
                 INSERT INTO ESTOQUEINSUMO (PROPRIEDADEID, INSUMOID, QUANTIDADE, PRECOUNITARIO, PRECOTOTAL, DATAMOVIMENTACAO)
                                 VALUES (@PropriedadeId, @InsumoId, @Quantidade, @PrecoUnitario, @PrecoTotal, @DataMovimentacao)                                                         
            ";

            await _connection.Execute(sql, rawMaterialStock);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM INSUMOESTOQUE WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<RawMaterialStockEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                      SELECT ID AS {nameof(RawMaterialStockEntity.Id)},
                             PROPRIEDADEID AS {nameof(RawMaterialStockEntity.PropriedadeId)},
                             INSUMOID AS {nameof(RawMaterialStockEntity.InsumoId)},
                             QUANTIDADE AS {nameof(RawMaterialStockEntity.Quantidade)},
                             PRECOUNITARIO AS {nameof(RawMaterialStockEntity.PrecoUnitario)},
                             PRECOTOTAL AS {nameof(RawMaterialStockEntity.PrecoTotal)},
                             DATAMOVIMENTACAO AS {nameof(RawMaterialStockEntity.DataMovimentacao)}
                        FROM ESTOQUEINSUMO
                       WHERE ID = @Id
                ";

                RawMaterialStockEntity aeroporto = await con.QueryFirstAsync<RawMaterialStockEntity>(sql, new { id });
                return aeroporto;
            }
        }
        public async Task Update(RawMaterialStockEntity rawMaterialStock)
        {
            Connection _connection = new Connection();
            string sql = @$"
                               UPDATE ESTOQUEINSUMO
                          SET PROPRIEDADEID = @PropriedadeId,
                              INSUMOID = @InsumoId,
                              QUANTIDADE = @Quantidade,
                              PRECOUNITARIO = @PrecoUnitario,
                              PRECOTOTAL = @PrecoTotal,
                              DATAMOVIMENTACAO = @DataMovimentacao
                            WHERE ID = @Id
                 ";

            await _connection.Execute(sql, rawMaterialStock);
        }
    }
}
