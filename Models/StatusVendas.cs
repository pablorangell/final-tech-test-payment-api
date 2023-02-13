using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public enum StatusVendas
    {
        AguardandoPagamento,
        PagamentoAprovado,
        Cancelado,
        EnviadoParaTransportadora,
        EnviadoParaTransportador,
        Entregue
    }
}