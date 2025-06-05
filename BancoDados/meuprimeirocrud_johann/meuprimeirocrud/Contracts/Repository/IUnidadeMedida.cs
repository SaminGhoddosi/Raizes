using MeuPrimeiroCrud.Entity;

namespace MeuPrimeiroCrud.Contracts.Repository
{
    public interface IUnidadeMedida
    {
        Task<IEnumerable<UnidadeMedidaEntity>> GetAll();
        Task Insert(UnidadeMedidaEntity UnidadeMedida);
        Task Delete(int id);
        Task<UnidadeMedidaEntity> GetById(int id);
        Task Update(UnidadeMedidaEntity UnidadeMedida);
    

    }
}
