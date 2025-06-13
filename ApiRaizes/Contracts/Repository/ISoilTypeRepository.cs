using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    interface ISoitTypeRepository
    {
        Task<IEnumerable<SoilTypeEntity>> GetAll();

        Task<SoilTypeEntity> GetById(int id);

        Task Insert(SoilTypeInsertDTO soilType);

        Task Delete(int id);

        Task Update(SoilTypeEntity soilType);
    }
}
