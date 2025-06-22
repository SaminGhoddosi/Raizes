using CRUD.DTO;
using CRUD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Contracts.Repository
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<PropertyEntity>> GetAll();
        Task Insert(PropertyInsertDTO propriedade);
        Task Delete(int id);
        Task<PropertyEntity> GetById(int Id);
        Task Update(PropertyEntity propriedade);
    }
}
