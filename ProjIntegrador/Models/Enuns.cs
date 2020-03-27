using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjIntegrador.Models
{
    public enum StatusEnum
    {
        Inativo = 0,
        Ativo
    }

    public enum FormaPagamentoEnum
    {
        Credito = 0,
        Debito,
        Dinheiro,
        PayPal,
        PicPay,
        Transferencia
    }

    public enum StatusInteressadoEnum
    {
        AguardandoAtendimento = 0,
        Agendaddo,
        Visitado,
        AnalisandoProposta,
        VendaEfetivada,
        VendaNaoEfetivada
    }
}