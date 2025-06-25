using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface ISoilHistoricRepository
    {
        Task<IEnumerable<SoilHistoricEntity>> GetAll();

        Task<SoilHistoricEntity> GetById(int id);

        Task Insert(SoilHistoricInsertDTO harvest);

        Task Delete(int id);

        Task Update(SoilHistoricEntity harvest);
    }
}