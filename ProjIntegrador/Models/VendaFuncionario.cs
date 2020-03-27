using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class VendaFuncionario
    {
        public int IdFuncionario { get; set; }
        public int IdVenda { get; set; }
        public decimal ValorComissao { get; set; }
        public Funcionario Funcionario { get; set; }
        public Venda Venda { get; set; }
    }
}