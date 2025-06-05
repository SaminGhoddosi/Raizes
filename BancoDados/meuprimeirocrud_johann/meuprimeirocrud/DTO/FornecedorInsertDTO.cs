using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroCrud.DTO
{
    public class FornecedorInsertDTO
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int telefone { get; set; }
        public string Email { get; set; }
        public int CriadoEm {get; set; }

    }
}
