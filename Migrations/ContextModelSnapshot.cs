﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiRecu.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("PrendaId")
                        .HasColumnType("int");

                    b.Property<int?>("PrendasPrendaId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int?>("TiketDeCompraTicketId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.HasIndex("PrendasPrendaId");

                    b.HasIndex("TiketDeCompraTicketId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Models.Prendas", b =>
                {
                    b.Property<int>("PrendaId")
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<string>("Prenda")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrendaId");

                    b.ToTable("Prendas");
                });

            modelBuilder.Entity("Models.TicketDeCompra", b =>
                {
                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<string>("Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.ToTable("TiketDeCompra");
                });

            modelBuilder.Entity("Models.Pedido", b =>
                {
                    b.HasOne("Models.Prendas", "Prendas")
                        .WithMany("Pedido")
                        .HasForeignKey("PrendasPrendaId");

                    b.HasOne("Models.TicketDeCompra", "TiketDeCompra")
                        .WithMany("Pedido")
                        .HasForeignKey("TiketDeCompraTicketId");

                    b.Navigation("Prendas");

                    b.Navigation("TiketDeCompra");
                });

            modelBuilder.Entity("Models.Prendas", b =>
                {
                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Models.TicketDeCompra", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
