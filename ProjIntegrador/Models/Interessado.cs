using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Interessado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataVisita { get; set; }
        public StatusEnum Status { get; set; }

        public int IdProduto { get; set; }
        public Produto Produto { get; set; }

    }
}