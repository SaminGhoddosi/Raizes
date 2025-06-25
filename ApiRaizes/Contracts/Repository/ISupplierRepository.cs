using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<SupplierEntity>> GetAll();
        Task Insert(SupplierInsertDTO supplier);
        Task Delete(int id);
        Task<SupplierEntity> GetById(int Id);
        Task Update(SupplierEntity supplier);
    }
}