using Microsoft.AspNetCore.Mvc;
using PagamentoApi.Models;

namespace PagamentoApi.Entities
{
    public class VendaEntity : EntityBase
    { 
        public int NumeroPedido { get; set; }
        public int IdVendedor { get; set; }
        public virtual VendedorEntity Vendedor { get; set; }
        public DateTime DataVenda { get; set; }
        public virtual List<VendaItemEntity> Itens { get; set; }
        public EnumStatusVenda Status { get; set; } = EnumStatusVenda.Aguardando_Pagamento;
    }
}
