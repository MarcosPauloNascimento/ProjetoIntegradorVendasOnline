﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public String Descricao { get; set; }
        public String DetalheProduto { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public StatusEnum Status { get; set; }
        public string ImagemProdudo { get; set; }

        public virtual ICollection<Interessado> Interessados { get; set; }
        public virtual ICollection<Venda> Vendas{ get; set; }
    }
}