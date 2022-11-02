using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagamentoApi.Context;
using PagamentoApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PagamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly VendaContext _context;

        public ProdutoController(VendaContext context)
        {
            _context = context;
        }

        [HttpGet("id")]
        public IActionResult ObterPorId(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Criar(ProdutoEntity produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = produto.Descricao }, produto);
        }

    }
}
