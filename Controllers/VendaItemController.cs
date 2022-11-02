using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagamentoApi.Context;
using PagamentoApi.Models;
using PagamentoApi.Entities;
using Microsoft.EntityFrameworkCore;



namespace PagamentoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaItemController : ControllerBase
    {
        private readonly VendaContext _context;
        public VendaItemController(VendaContext context)
        {
            _context = context;
        }
        [HttpGet("id")]
        public IActionResult ObterPorId(int id)
        {
            var vendaItem = _context.VendaItens.Find(id);
            if(vendaItem == null)
            return NotFound();

            return Ok(vendaItem);
        }
    }
}