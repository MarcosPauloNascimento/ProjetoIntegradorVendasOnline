using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public int Comissao { get; set; }

        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }
    }
}