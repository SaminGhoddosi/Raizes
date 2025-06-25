
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
    public class RawMaterialRepository : IRawMaterialRepository
    {
        public async Task<IEnumerable<RawMaterialEntity>> GetAll()
        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                        SELECT ID AS {nameof(RawMaterialEntity.Id)},
                                Nome AS {nameof(RawMaterialEntity.Nome)},
                                Descricao AS{nameof(RawMaterialEntity.Descricao)},
                                Tipo AS{nameof(RawMaterialEntity.Tipo)}
                                FROM INSUMO
                    ";


                var rawMateriallist = await con.QueryAsync<RawMaterialEntity>(sql);
                return rawMateriallist;
            }

        }
        public async Task Insert(RawMaterialInsertDTO rawMaterial)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO INSUMO (NOME)
                            VALUE (@Nome)
            ";

            await _connection.Execute(sql, rawMaterial);


        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM INSUMO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<RawMaterialEntity> GetById(int id)

        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {


                string sql = @$"
                        SELECT ID AS {nameof(RawMaterialEntity.Id)},
                                Nome AS {nameof(RawMaterialEntity.Nome)},
                                Descricao AS{nameof(RawMaterialEntity.Descricao)},
                                Tipo AS{nameof(RawMaterialEntity.Tipo)}
                                 FROM INSUMO
                                 WHERE ID = @id

            ";
                RawMaterialEntity rawMaterial = await con.QueryFirstAsync<RawMaterialEntity>(sql, new { id });
                return rawMaterial;

            }



        }
        public async Task Update(RawMaterialEntity rawMaterial)
        {
            Connection _connection = new Connection();

            string sql = @"
                UPDATE INSUMO
                   SET NOME = @Nome
                 WHERE ID = @Id
            ";

            await _connection.Execute(sql, rawMaterial);
        }

    }
}