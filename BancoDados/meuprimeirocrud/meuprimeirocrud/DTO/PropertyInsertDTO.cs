using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroCrud.DTO
{
    public class PropertyInsertDTO
    {
        public string Nome { get; set; }
        public string Endereco{ get; set; }
        public string UsuarioId { get; set; }
        public string Status { get; set; }
        //public string CidadeId { get; set; }
    }
}
