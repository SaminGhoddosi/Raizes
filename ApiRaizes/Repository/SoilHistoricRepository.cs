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
    public class SoilHistoricRepository : ISoilHistoricRepository
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SoilHistoricEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SoilHistoricEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(SoilHistoricInsertDTO harvest)
        {
            throw new NotImplementedException();
        }

        public Task Update(SoilHistoricEntity harvest)
        {
            throw new NotImplementedException();
        }
    }
}