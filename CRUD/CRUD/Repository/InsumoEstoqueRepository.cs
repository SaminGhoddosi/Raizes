using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.DTO;
using CRUD.Entity;
using CRUD.InfraEstructure;
using Dapper;
using MySql.Data.MySqlClient;

namespace CRUD.Repository
{
    public class InsumoEstoqueRepository
    {
        public async Task<IEnumerable<InsumoEstoqueEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(InsumoEstoqueEntity.Id)},
                           PropriedadeId AS {nameof(InsumoEstoqueEntity.PropriedadeId)},
                           InsumoId AS {nameof(InsumoEstoqueEntity.InsumoId)},
                           Quantidade AS {nameof(InsumoEstoqueEntity.Quantidade)},
                           PrecoUnitario AS {nameof(InsumoEstoqueEntity.PrecoUnitario)},
                           PrecoTotal AS {nameof(InsumoEstoqueEntity.PrecoTotal)},
                           DataMovimentacao AS {nameof(InsumoEstoqueEntity.DataMovimentacao)}

                    FROM insumoestoque
                ";

                IEnumerable<InsumoEstoqueEntity> insumolist = await con.QueryAsync<InsumoEstoqueEntity>(sql);

                return insumolist;
            }
        }

        public async Task Insert(InsumoEstoqueInsertDTO insumoEstoque)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO INSUMOESTOQUE (PROPRIEDADEID, INSUMOID, QUANTIDADE, PRECOUNITARIO, PRECOTOTAL, DATAMOVIMENTACAO)
                       VALUES (@PropriedadeId, @InsumoId, @Quantidade, @PrecoUnitario, @PrecoTotal, @DataMovimentacao)
            ";

            await _connection.Execute(sql, insumoEstoque);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM INSUMOESTOQUE WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

        public async Task<InsumoEstoqueEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(InsumoEstoqueEntity.Id)},
                           PropriedadeId AS {nameof(InsumoEstoqueEntity.PropriedadeId)},
                           InsumoId AS {nameof(InsumoEstoqueEntity.InsumoId)},
                           Quantidade AS {nameof(InsumoEstoqueEntity.Quantidade)},
                           PrecoUnitario AS {nameof(InsumoEstoqueEntity.PrecoUnitario)},
                           PrecoTotal AS {nameof(InsumoEstoqueEntity.PrecoTotal)},
                           DataMovimentacao AS {nameof(InsumoEstoqueEntity.DataMovimentacao)}
                    FROM insumoestoque
                    WHERE ID = @id
                ";

                InsumoEstoqueEntity insumoEstoque = await con.QueryFirstAsync<InsumoEstoqueEntity>(sql, new { id });
                return insumoEstoque;
            }

        }

        public async Task Update(InsumoEstoqueEntity insumoEstoque)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE INSUMOESTOQUE 
                    SET Propriedade = @Propriedade,
                    SET InsumoId = @InsumoId,
                    SET Quantidade = @Quantidade,
                    SET PrecoUnitario = @PrecoUnitario,
                    SET PrecoTotal = @PrecoTotal,
                    SET DataMovimentacao = @DataMovimentacao
                   
                WHERE ID = @id
            ";

            await _connection.Execute(sql, insumoEstoque);
        }
    }
}
