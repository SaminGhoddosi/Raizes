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
    public class SupplierRepository : ISupplierRepository
    {
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM FORNECEDOR WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<SupplierEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT Id AS {nameof(SupplierEntity.Id)},
                            Nome AS {nameof(SupplierEntity.Nome)},
                            CNPJ AS {nameof(SupplierEntity.CNPJ)},
                            Telefone AS {nameof(SupplierEntity.Telefone)},
                            Email AS {nameof(SupplierEntity.Email)}
                    FROM FORNECEDOR
                ";
                IEnumerable<SupplierEntity> supplierlist = await con.QueryAsync<SupplierEntity>(sql);
                return supplierlist;
            }

        }

        public async Task<SupplierEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(SupplierEntity.Id)},
                            Nome AS {nameof(SupplierEntity.Nome)},
                            CNPJ AS {nameof(SupplierEntity.CNPJ)},
                            Telefone AS {nameof(SupplierEntity.Telefone)},
                            Email AS {nameof(SupplierEntity.Email)}
                    FROM FORNECEDOR
                    WHERE ID = @id
                ";

                SupplierEntity supplier = await con.QueryFirstAsync<SupplierEntity>(sql, new { id });
                return supplier;
            }

        }

        public async Task Insert(SupplierInsertDTO supplier)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO FORNECEDOR(NOME,CNPJ,TELEFONE,EMAIL)
                                    VALUES(@Nome,@CNPJ,@Telefone,@Email)
            ";
            await _connection.Execute(sql, supplier);
        }

        public async Task Update(SupplierEntity supplier)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE FORNECEDOR
                SET Nome = @Nome,
                    CNPJ = @CNPJ,
                    Telefone = @Telefone,
                    Email = @Email
                WHERE ID = @id
            ";
            await _connection.Execute(sql, supplier);
        }
    }
}