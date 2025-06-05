using Dapper;
using MeuPrimeiroCrud.Contracts.Repository;
using MeuPrimeiroCrud.DTO;
using MeuPrimeiroCrud.Entity;
using MeuPrimeiroCrud.InfraEstructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroCrud.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM CIDADE WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<FornecedorEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT Id AS {nameof(FornecedorEntity.Id)},
                            Nome AS{nameof(FornecedorEntity.Nome)},
                            CNPJ AS{nameof(FornecedorEntity.CNPJ)},
                            Telefone{nameof(FornecedorEntity.Telefone)}
                            Email{nameof(FornecedorEntity.Email)},
                            CriadoEm{nameof(FornecedorEntity.CriadoEm)}
                    FROM FORNECEDOR
                ";
                IEnumerable<FornecedorEntity> fornecedoreslist = await con.QueryAsync<FornecedorEntity>(sql);
                return fornecedoreslist;
            }

        }

        public async Task<FornecedorEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(FornecedorEntity.Id)},
                            Nome AS{nameof(FornecedorEntity.Nome)},
                            CNPJ AS{nameof(FornecedorEntity.CNPJ)},
                            Telefone{nameof(FornecedorEntity.Telefone)}
                            Email{nameof(FornecedorEntity.Email)},
                            CriadoEm{nameof(FornecedorEntity.CriadoEm)}
                    FROM cidade
                    WHERE ID = @id
                ";

                FornecedorEntity cidade = await con.QueryFirstAsync<FornecedorEntity>(sql, new { id });
                return cidade;
            }

        }

        public async Task Insert(FornecedorInsertDTO fornecedor)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO FORNECEDOR(NOME,CNPJ,TELEFONE,EMAIL)
                                    VALUE(@Nome,@CNPJ,@Telefone,@Email
            ";
            await _connection.Execute(sql, fornecedor);
        }

        public async Task Update(FornecedorEntity fornecedor)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE FORNECEDOR
                    SET Nome = @Nome
                WHERE ID = @id
            ";
            await _connection.Execute(sql, fornecedor);
        }
    }
}