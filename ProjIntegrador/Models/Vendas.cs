using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public decimal TotalVenda { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public decimal ValorDesconto { get; set; }
        public DateTime DataVenda { get; set; }

        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }

    }
}