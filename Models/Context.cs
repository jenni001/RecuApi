#define SQL_NO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

public class Context : DbContext
{

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }
    public DbSet<TicketDeCompra> TiketDeCompra { get; set; }

    public DbSet<Pedido> Pedido { get; set; }

    public DbSet<Prendas> Prendas { get; set; }
}
