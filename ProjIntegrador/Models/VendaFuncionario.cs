using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class VendaFuncionario
    {
        public Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }

        public Venda Venda { get; set; }
        public int VendaId { get; set; }

        public decimal ValorComissao { get; set; }
    }
}