using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRaizes.DTO;
using ApiRaizes.Entity;


namespace ApiRaizes.Contracts.Repository
{
     interface IMeasureUnitRepository
    {
        Task<IEnumerable<MeasureUnitEntity>> GetAll();

        Task<MeasureUnitEntity> GetById(int id);

        Task Insert(MeasureUnitInsertDTO measureUnit);

        Task Delete(int id);

        Task Update(MeasureUnitEntity measureUnit);


    }
}