using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Infrastructure;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class PropertyRepository : IPropertyRepository
    {

        public async Task<IEnumerable<PropertyEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                  SELECT ID AS {nameof(PropertyEntity.Id)},
                                         NOME AS {nameof(PropertyEntity.Nome)},
                                     CIDADEID AS {nameof(PropertyEntity.CidadeId)},
                                    USUARIOID AS {nameof(PropertyEntity.UsuarioId)},
                                       STATUS AS {nameof(PropertyEntity.Status)},
                                     TAMANHO AS {nameof(PropertyEntity.Tamanho)},
                                      CULTURA AS {nameof(PropertyEntity.Cultura)},
                              UNIDADEMEDIDAID AS {nameof(PropertyEntity.UnidadeMedidaId)}
                                    FROM PROPRIEDADE
                ";
                IEnumerable<PropertyEntity> propertyList = await con.QueryAsync<PropertyEntity>(sql);
                return propertyList;
            }
        }
        public async Task Insert(PropertyInsertDTO property)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO PROPRIEDADE (NOME, CIDADEID, USUARIOID, STATUS, TAMANHO, CULTURA, UNIDADEMEDIDAID)
                     VALUES (@Nome, @CidadeId, @UsuarioId, @Status, @Tamanho, @Cultura, @UnidadeMedidaId)
            ";

            await _connection.Execute(sql, property);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM PROPRIEDADE WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<PropertyEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                   SELECT ID AS {nameof(PropertyEntity.Id)},
                          NOME AS {nameof(PropertyEntity.Nome)},
                      CIDADEID AS {nameof(PropertyEntity.CidadeId)},
                     USUARIOID AS {nameof(PropertyEntity.UsuarioId)},
                        STATUS AS {nameof(PropertyEntity.Status)},
                      TAMANHO AS {nameof(PropertyEntity.Tamanho)},
                       CULTURA AS {nameof(PropertyEntity.Cultura)},
               UNIDADEMEDIDAID AS {nameof(PropertyEntity.UnidadeMedidaId)}
                    FROM PROPRIEDADE
                   WHERE ID = @Id
";

                PropertyEntity aeroporto = await con.QueryFirstAsync<PropertyEntity>(sql, new { id });
                return aeroporto;
            }
        }
        public async Task Update(PropertyEntity property)
        {
            Connection _connection = new Connection();
            string sql = @$"
                                        UPDATE   PROPRIEDADE
                                 SET NOME = @Nome,
                                       CIDADEID = @CidadeId,
                                      USUARIOID = @UsuarioId,
                                         STATUS = @Status,
                                       TAMANHO = @Tamanho,
                                        CULTURA = @Cultura,
                               UNIDADEMEDIDAID = @UnidadeMedidaId
                                     WHERE ID = @Id
";

            await _connection.Execute(sql, property);
        }
    }
}
