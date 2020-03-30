using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Venda
    {
        public int VendaId { get; set; }
        public decimal TotalVenda { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public decimal ValorDesconto { get; set; }
        public DateTime DataVenda { get; set; }

        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}