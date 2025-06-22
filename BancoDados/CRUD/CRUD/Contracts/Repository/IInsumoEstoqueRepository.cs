using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.DTO;
using CRUD.Entity;

namespace CRUD.Contracts.Repository
{
    public interface IInsumoEstoqueRepository
    {
        Task<IEnumerable<InsumoEstoqueEntity>> GetAll();
        Task Insert(InsumoEstoqueInsertDTO insumoEstoque);
        Task Delete(int id);
        Task<InsumoEstoqueEntity> GetById(int Id);
        Task Update(InsumoEstoqueEntity insumoEstoque);
    }
}
