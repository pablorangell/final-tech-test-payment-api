using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Context;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly PagamentosContext _vendaContext;

        public VendasController(PagamentosContext vendaContext)
        {
            _vendaContext = vendaContext;
        }

        [HttpPost("Registrar Venda")]
        public IActionResult Create(int id, Vendas vendas)
        {
            var vendedor = _vendaContext.Vendedor.Find(vendas.IdVendedor);

            if(vendedor == null)
            {
                return NotFound();
            }
            
            if(string.IsNullOrEmpty(vendas.Itens))
            {
                return BadRequest(new { Erro = "Não pode estar vazio!"});
            }
            vendas.Status = StatusVendas.AguardandoPagamento;
            _vendaContext.Add(vendas);
            _vendaContext.SaveChanges();

            return CreatedAtAction(nameof(ObterVendaPorId), new { id = vendas.Id }, vendas);
        }

        [HttpGet("Buscar Venda por ID{id}")]
        public IActionResult ObterVendaPorId(int id)
        {
            var venda = _vendaContext.Venda.Find(id);

            if(venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpPut("Atualizar Venda")]
        public IActionResult AlterarStatusVenda(int id, Vendas vendas  , StatusVendas statusVendas)
        {
            var vendaBanco = _vendaContext.Venda.Find(id);

            if(vendaBanco == null)
                return NotFound();

            if(vendas.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "Data inválida!"});

            vendaBanco.Data = vendas.Data;
            vendaBanco.IdVendedor = vendas.IdVendedor;
            vendaBanco.Itens = vendas.Itens;

            if (vendas.Status == StatusVendas.AguardandoPagamento)
            {
                if (statusVendas == StatusVendas.PagamentoAprovado && statusVendas != StatusVendas.Cancelado)
                {
                    return BadRequest(new { Erro = "Pagamento aprovado, a venda não pode ser cancelada!" });
                }
            }

            if(vendas.Status == StatusVendas.PagamentoAprovado)
            {
                if(statusVendas != StatusVendas.EnviadoParaTransportadora && statusVendas != StatusVendas.Cancelado)
                {
                    return BadRequest(new { Erro = "Verifique o status da venda!"});
                }
            }

            if(vendas.Status == StatusVendas.EnviadoParaTransportador)
            {
                if(statusVendas == StatusVendas.Entregue)
                {
                    return BadRequest(new { Erro = "Verifique o status da venda!" });
                }
            }

            vendaBanco.Status = statusVendas;
            _vendaContext.Venda.Update(vendaBanco);
            _vendaContext.SaveChanges();

            return Ok(vendaBanco);
        }

        [HttpDelete("Deletar Venda")]
        public IActionResult Delete(int id)
        {
            var venda = _vendaContext.Venda.Find(id);

            if(venda == null)
                return NotFound();

            _vendaContext.Venda.Remove(venda);
            _vendaContext.SaveChanges();

            return NoContent();
        }

    }
}