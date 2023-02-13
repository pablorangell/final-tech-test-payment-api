﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tech_test_payment_api.Context;

#nullable disable

namespace techtestpaymentapi.Migrations
{
    [DbContext(typeof(PagamentosContext))]
    [Migration("20230210144646_CriacaoTabelaPayment")]
    partial class CriacaoTabelaPayment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("tech_test_payment_api.Models.Compras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdVenda")
                        .HasColumnType("int");

                    b.Property<int>("IdVendedor")
                        .HasColumnType("int");

                    b.Property<int?>("VendaId")
                        .HasColumnType("int");

                    b.Property<int?>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VendaId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("tech_test_payment_api.Models.Vendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdVendedor")
                        .HasColumnType("int");

                    b.Property<string>("Itens")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("tech_test_payment_api.Models.Vendedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("tech_test_payment_api.Models.Compras", b =>
                {
                    b.HasOne("tech_test_payment_api.Models.Vendas", "Venda")
                        .WithMany()
                        .HasForeignKey("VendaId");

                    b.HasOne("tech_test_payment_api.Models.Vendedores", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId");

                    b.Navigation("Venda");

                    b.Navigation("Vendedor");
                });
#pragma warning restore 612, 618
        }
    }
}