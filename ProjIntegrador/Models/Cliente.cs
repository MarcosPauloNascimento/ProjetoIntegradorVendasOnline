using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }
    }
}