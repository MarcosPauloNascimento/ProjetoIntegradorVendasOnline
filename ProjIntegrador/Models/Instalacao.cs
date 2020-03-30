using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Instalacao
    {
        public int InstalacaoId { get; set; }
        public DateTime DataInstalacao { get; set; }
        public string Observacao { get; set; }

        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        public Instalador Instalador { get; set; }
        public int InstaladorId { get; set; }
        
        public Venda Venda { get; set; }
        public int VendaId { get; set; }


    }
}