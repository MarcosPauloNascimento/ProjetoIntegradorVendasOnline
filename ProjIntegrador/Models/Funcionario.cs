using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataContratacao { get; set; }
        public StatusEnum Status { get; set; }

        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

    }
}