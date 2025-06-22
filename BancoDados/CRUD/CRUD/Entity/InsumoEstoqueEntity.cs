using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Entity
{
    public class InsumoEstoqueEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CidadeId { get; set; }
        public int UsuarioId { get; set; }
        public int Status { get; set; }
        public int Tamanho { get; set; }
        public string Cultura { get; set; }
        public int UnidadeMedidaId { get; set; }
    }
}
