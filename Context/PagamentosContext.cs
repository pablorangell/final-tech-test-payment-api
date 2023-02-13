using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Context
{
    public class PagamentosContext : DbContext
    {
        public PagamentosContext(DbContextOptions<PagamentosContext> options) : base(options)
        {

        }

        public DbSet<Compras> Compra { get; set; }
        public DbSet<Vendas> Venda { get; set; }
        public DbSet<Vendedores> Vendedor { get; set; }
    }
}