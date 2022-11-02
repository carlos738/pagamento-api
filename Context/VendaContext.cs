using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagamentoApi.Entities;


namespace PagamentoApi.Context
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options) : base(options)
        {

        }

        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<VendaEntity> Vendas { get; set; }
        public DbSet<VendaItemEntity> VendaItens { get; set;}
        public DbSet<VendaEntity> Vendedores { get; set;}
    }
}