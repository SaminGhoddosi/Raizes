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
                           Nome AS {nameof(InsumoEstoqueEntity.Nome)},
                           CidadeId AS {nameof(InsumoEstoqueEntity.CidadeId)},
                           UsuarioId AS {nameof(InsumoEstoqueEntity.UsuarioId)},
                           Status AS {nameof(InsumoEstoqueEntity.Status)},
                           Tamanho AS {nameof(InsumoEstoqueEntity.Tamanho)},
                           Cultura AS {nameof(InsumoEstoqueEntity.Cultura)},
                           UnidadeMedidaId AS {nameof(InsumoEstoqueEntity.UnidadeMedidaId)}

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
                INSERT INTO INSUMOESTOQUE (NOME,CIDADEID,USUARIOID,STATUS,TAMANHO,CULTURA,UNIDADEMEDIDAID)
                            VALUE(@Nome,@CidadeId,@UsuarioId,@Status,@Tamanho,@Cultura,@UnidadeMedidaId)
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
                           Nome AS {nameof(InsumoEstoqueEntity.Nome)},
                           CidadeId AS {nameof(InsumoEstoqueEntity.CidadeId)},
                           UsuarioId AS {nameof(InsumoEstoqueEntity.UsuarioId)},
                           Status AS {nameof(InsumoEstoqueEntity.Status)},
                           Tamanho AS {nameof(InsumoEstoqueEntity.Tamanho)},
                           Cultura AS {nameof(InsumoEstoqueEntity.Cultura)},
                           UnidadeMedidaId AS {nameof(InsumoEstoqueEntity.UnidadeMedidaId)}
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
                    SET Nome = @Nome,
                    SET CidadeId = @CidadeId,
                    SET UsuarioId = @UsuarioId,
                    SET Status = @Status,
                    SET Tamanho = @Tamanho,
                    SET Cultura = @Cultura,
                    SET UnidadeMedidaId = @UnidadeMedidaId
                WHERE ID = @id
            ";

            await _connection.Execute(sql, insumoEstoque);
        }
    }
}
