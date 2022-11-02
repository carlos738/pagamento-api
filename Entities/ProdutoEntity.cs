using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagamentoApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace PagamentoApi.Entities
{
    public class  ProdutoEntity : EntityBase
    {
        public string Descricao {get; set;}
        public decimal Preco { get; set; }
             
      
        
    }
}