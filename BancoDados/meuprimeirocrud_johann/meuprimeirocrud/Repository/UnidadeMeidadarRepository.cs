using Dapper;
using MeuPrimeiroCrud.Contracts.Repository;
using MeuPrimeiroCrud.DTO;
using MeuPrimeiroCrud.Entity;
using MeuPrimeiroCrud.InfraEstructure;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuPrimeiroCrud.Repository
{
    public class UnidadeMedidaRepository : IUnidadeMedida
    {
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM UNIDADEMEDIDA WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<UnidadeMedidaEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT Id AS {nameof(UnidadeMedidaEntity.Id)},
                           Nome AS {nameof(UnidadeMedidaEntity.Nome)},
                           Sigla AS {nameof(UnidadeMedidaEntity.Sigla)},
                    FROM UNIDADEMEDIDA
                ";
                IEnumerable<UnidadeMedidaEntity> unidadeList = await con.QueryAsync<UnidadeMedidaEntity>(sql);
                return unidadeList;
            }
        }

        public async Task<UnidadeMedidaEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT Id AS {nameof(UnidadeMedidaEntity.Id)},
                           Nome AS {nameof(UnidadeMedidaEntity.Nome)},
                           Sigla AS {nameof(UnidadeMedidaEntity.Sigla)},                  
                    FROM UNIDADEMEDIDA
                    WHERE ID = @id
                ";

                UnidadeMedidaEntity unidade = await con.QueryFirstAsync<UnidadeMedidaEntity>(sql, new { id });
                return unidade;
            }
        }

        public async Task Insert(UnidadeMedidaEntity unidade)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO UNIDADEMEDIDA(NOME, SIGLA)
                VALUES (@Nome, @Sigla)
            ";
            await _connection.Execute(sql, unidade);
        }

        public async Task Update(UnidadeMedidaEntity unidade)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE UNIDADEMEDIDA
                   SET Nome = @Nome,
                       Sigla = @Sigla
                 WHERE ID = @Id
            ";
            await _connection.Execute(sql, unidade);
        }
    }
}
