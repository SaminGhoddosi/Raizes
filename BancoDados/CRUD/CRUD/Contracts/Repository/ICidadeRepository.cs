using Dapper;
using CRUD.DTO;
using CRUD.Entity;
using CRUD.InfraEstructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Contracts.Repository
{
    public interface ICidadeRepository
    {
        Task<IEnumerable<cidadeEntity>> GetAll();
        Task Insert(CidadeInsertDTO cidade);
        Task Delete(int id);
        Task <cidadeEntity>GetById(int Id);
        Task Update(cidadeEntity cidade);
    }
}
