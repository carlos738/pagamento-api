using System;
using PagamentoApi.Context;
using Microsoft.EntityFrameworkCore;
using PagamentoApi.Models;
using PagamentoApi.Entities;
using PagamentoApi.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace PagamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly VendaContext _context;
        public VendedorController(VendaContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var vendedor = _context.Vendedores.Find(id);
            if (vendedor == null)
                return NotFound();

            return Ok(vendedor);
        }
        private readonly VendedorEntity vendedor;
        public VendedorEntity Vendedor { get; }

        [HttpPost]
        public IActionResult Criar(VendedorEntity vendedorEntity)
        {
            //_context.Vendedores.AddAsync();
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = vendedor.Id }, vendedor);
           
          
        }
    }
}
