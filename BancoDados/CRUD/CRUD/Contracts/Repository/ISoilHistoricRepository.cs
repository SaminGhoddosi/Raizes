using CRUD.DTO;
using CRUD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Contracts.Repository
{
    public interface ISoilHistoricRepository
    {
        Task<IEnumerable<SoilHistoricEntity>> GetAll();
        Task Insert(SoilHistoricInsertDTO propriedade);
        Task Delete(int id);
        Task<SoilHistoricEntity> GetById(int Id);
        Task Update(SoilHistoricEntity propriedade);
    }
}
