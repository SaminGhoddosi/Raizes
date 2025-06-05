using MeuPrimeiroCrud.DTO;
using MeuPrimeiroCrud.Entity;


namespace MeuPrimeiroCrud.Contracts.Repository
{
    public interface ICidadeRepository
    {
        Task<IEnumerable<cidadeEntity>> GetAll();
        Task Insert(CidadeInsertDTO cidade);
        Task Delete(int id);
        Task <cidadeEntity>GetById(int Id);
        Task Update(cidadeEntity cidade);
    }
}  
