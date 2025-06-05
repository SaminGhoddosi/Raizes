using MeuPrimeiroCrud.DTO;
using MeuPrimeiroCrud.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroCrud.Contracts.Repository
{
    public interface ISoilHistoricRepository
    {
        Task<IEnumerable<SoilHistoricEntity>> GetAll();
        Task Insert(SoilHistoricDTO propriedade);
        Task Delete(int id);
        Task<SoilHistoricEntity> GetById(int Id);
        Task Update(SoilHistoricEntity propriedade);
    }
}
