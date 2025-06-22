using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Entity
{
    public class PropertyEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string UsuarioId { get; set; }
        public int Status { get; set; }
        public int Tamanho { get; set; }
        public int Cultura { get; set; }
        public int UnidadeMedidaId { get; set; }
        public string CidadeId { get; set; }
    }
}
