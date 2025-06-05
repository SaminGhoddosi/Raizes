using Dapper;
using MeuPrimeiroCrud.DTO;
using MeuPrimeiroCrud.Entity;
using MeuPrimeiroCrud.InfraEstructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroCrud.Contracts.Repository
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<FornecedorEntity>> GetAll();
        Task Insert(FornecedorInsertDTO fornecedor);
        Task Delete(int id);
        Task<FornecedorEntity> GetById(int Id);
        Task Update(FornecedorEntity fornecedor);
    }
}
