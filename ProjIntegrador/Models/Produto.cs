using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public String Descricao { get; set; }
        public decimal Valor { get; set; }
        public StatusEnum Status { get; set; }
    }
}