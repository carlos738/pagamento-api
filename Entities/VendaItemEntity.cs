using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagamentoApi.Entities
{
    public class VendaItemEntity : EntityBase
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public int IdVenda { get; set; }
        
        
        
        
        
    }
}