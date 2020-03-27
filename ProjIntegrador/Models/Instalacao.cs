using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Instalacao
    {
        public int Id { get; set; }
        public DateTime DataInstalacao { get; set; }
        public string Observacao { get; set; }
        public int IdEndereco { get; set; }
        public Endereco EnderecoInstalacao { get; set; }
        public int IdVenda { get; set; }
        public Venda Venda { get; set; }
        public int IdInstalador { get; set; }
        public Instalador Instalador { get; set; }
    }
}