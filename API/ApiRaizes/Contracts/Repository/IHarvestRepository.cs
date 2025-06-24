using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    interface IHarvestRepository
    {
        Task<IEnumerable<HarvestEntity>> GetAll();

        Task<HarvestEntity> GetById(int id);

        Task Insert(HarvestInsertDTO harvest);

        Task Delete(int id);

        Task Update(HarvestEntity harvest);
    }
}
