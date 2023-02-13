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
    public class VendedoresController : ControllerBase
    {
        private readonly PagamentosContext _vendedorContext;

        public VendedoresController(PagamentosContext vendedorContext)
        {
            _vendedorContext = vendedorContext;
        }

        [HttpPost("Criar Vendedor")]
        public IActionResult Create(Vendedores vendedores)
        {
            _vendedorContext.Add(vendedores);
            _vendedorContext.SaveChanges();

            return CreatedAtAction(nameof(ObterVendedorPorId), new { id = vendedores.Id }, vendedores);
        }

        [HttpGet("Buscar Vendedor por ID{id}")]
        public IActionResult ObterVendedorPorId(int id)
        {
            var vendedor = _vendedorContext.Vendedor.Find(id);

            if(vendedor == null)
                return NotFound();

            return Ok(vendedor);
        }

        [HttpPut("Atualizar Vendedor")]
        public IActionResult Update(Vendedores vendedores)
        {
            var vendedor = _vendedorContext.Vendedor.Find(vendedores.Id);

            if(vendedor == null)
                return NotFound();

            vendedor.Cpf = vendedores.Cpf;
            vendedor.Nome = vendedores.Nome;
            vendedor.Email = vendedores.Email;
            vendedor.Telefone = vendedores.Telefone;

            _vendedorContext.SaveChanges();

            return Ok(vendedor);
        }
    }
}