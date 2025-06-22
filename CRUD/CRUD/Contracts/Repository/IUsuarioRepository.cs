using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.DTO;
using CRUD.Entity;

namespace CRUD.Contracts.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioEntity>> GetAll();
        Task Insert(UsuarioInsertDTO usuario);
        Task Delete(int id);
        Task<UsuarioEntity> GetById(int Id);
        Task Update(UsuarioEntity usuario);
    }
}
