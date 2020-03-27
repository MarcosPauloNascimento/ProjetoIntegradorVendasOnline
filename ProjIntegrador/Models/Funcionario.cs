using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public long CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataContratacao { get; set; }
        public int Comissao { get; set; }
        public StatusEnum Status { get; set; }

    }
}