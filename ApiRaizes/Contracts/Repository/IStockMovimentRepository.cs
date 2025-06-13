using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Contracts.Repository
{
    interface IStockMovimentRepository
    {
        Task<IEnumerable<StockMovimentEntity>> GetAll();

        Task<StockMovimentEntity> GetById(int id);

        Task Insert(StockMovimentInsertDTO stockMoviment);

        Task Delete(int id);

        Task Update(StockMovimentEntity stockMoviment);
    }
}
