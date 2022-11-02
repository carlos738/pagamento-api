using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagamentoApi.Context;
using PagamentoApi.Controllers;
using PagamentoApi.Entities;
using PagamentoApi.Models;
using Microsoft.EntityFrameworkCore;
namespace PagamentoApi.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly VendaContext _context;
        public VendaController(VendaContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var venda = _context.Vendas.Include(v => v.Itens).FirstOrDefault(v => v.Id == id);
            if (venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusVenda status)
        {
            var venda = _context.Vendas.Where(x => x.Status == status);
            return Ok(venda);
        }

        [HttpPost]
        public IActionResult Criar(VendaEntity venda)
        {
            if (venda.DataVenda == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da venda não pode ser vazia" });

            if (venda.Itens != null && venda.Itens.Any() == false)
                return BadRequest(new { Erro = "A venda deve conter ao menos um item" });

            venda.Status = EnumStatusVenda.Aguardando_Pagamento;
            _context.Vendas.Add(venda);
            foreach (var item in venda.Itens)
            {
                item.IdVenda = venda.Id;
                _context.VendaItens.Add(item);
            }
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = venda.Id }, venda);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarVenda(int id, VendaEntity venda)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if (vendaBanco == null)
                return NotFound();

            vendaBanco.Status = venda.Status;

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();

            return Ok(vendaBanco);
        }

        [HttpPut("{id}/avancar-status")]
        public IActionResult AvancarStatusVenda(int id, bool cancelar)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if (vendaBanco == null)
                return NotFound();

            switch (vendaBanco.Status)
            {
                case EnumStatusVenda.Aguardando_Pagamento:
                    if (cancelar)
                        vendaBanco.Status = EnumStatusVenda.Venda_Cancelada;
                    else
                        vendaBanco.Status = EnumStatusVenda.Pagamento_Aprovado;
                    break;

                case EnumStatusVenda.Pagamento_Aprovado:
                    if (cancelar)
                        vendaBanco.Status = EnumStatusVenda.Venda_Cancelada;
                    else
                        vendaBanco.Status = EnumStatusVenda.Enviado_Para_Transportadora;
                    break;

                case EnumStatusVenda.Enviado_Para_Transportadora:
                    if (cancelar)
                        return BadRequest(new { Erro = "A venda NÃO pode ser cancelada nesse status" });
                    else
                        vendaBanco.Status = EnumStatusVenda.Item_Entregue;
                    break;

                case EnumStatusVenda.Item_Entregue:
                    return BadRequest(new { Erro = "A mercadoria já foi entregue" });

                default:
                    return BadRequest(new { Erro = "Não é possível avançar" });
            }

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();

            return Ok(vendaBanco);
        }
    }
}
