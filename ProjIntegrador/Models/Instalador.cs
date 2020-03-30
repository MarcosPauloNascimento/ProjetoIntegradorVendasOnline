using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Instalador
    {
        public int InstaladorId { get; set; }
        
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

        public virtual ICollection<Instalacao> Instalacoes { get; set; }
    }
}