using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.DTO
{
    public class SupplierInsertDTO
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }

    }
}