using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Interessado
    {
        public int InteressadoId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataVisita { get; set; }
        public StatusEnum Status { get; set; }

        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}