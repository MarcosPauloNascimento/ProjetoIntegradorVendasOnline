using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class ItensVenda
    {
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public int IdVenda { get; set; }

        public Venda Venda { get; set; }
        public int VendaId { get; set; }

        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
    }
}