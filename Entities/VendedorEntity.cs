using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagamentoApi.Entities;

namespace PagamentoApi.Entities
{
    public class VendedorEntity : EntityBase

    {
       
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        //public int Id { get; set; }
        
        

        
    }
}