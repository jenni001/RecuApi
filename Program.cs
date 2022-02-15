using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models;

namespace ApiRecu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //Crear();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

           /* static void Crear()
        {
            using (var db = new Context())
            {

                db.Pedido.RemoveRange(db.Pedido);
                db.Prendas.RemoveRange(db.Prendas);
                db.TiketDeCompra.RemoveRange(db.TiketDeCompra);
                db.SaveChanges();

                db.TiketDeCompra.AddRange(
                    new TiketDeCompra { ClienteId = 1, Cliente = "Edu" },
                    new TiketDeCompra { ClienteId = 2, Cliente = "Eva"  },
                    new TiketDeCompra { ClienteId = 3, Cliente = "Unai"  }
                );
                db.SaveChanges();

                db.Prendas.AddRange(
                    new Prendas { PrendaId = 1, Prenda = "Pantalon", Precio = 10 },
                    new Prendas { PrendaId = 2, Prenda = "Jersey", Precio = 20 }
                );
                db.SaveChanges();

                db.Pedido.AddRange(
                    new Pedido { PedidoId = 1, ClienteId = 1, PrendaId = 1, Cantidad=1 },
                    new Pedido { PedidoId = 2, ClienteId = 1, PrendaId = 1, Cantidad=2},
                    new Pedido { PedidoId = 3, ClienteId = 2, PrendaId = 2,Cantidad=1 },
                    new Pedido { PedidoId = 4, ClienteId = 2, PrendaId = 2, Cantidad=2 },
                    new Pedido { PedidoId = 5, ClienteId = 3, PrendaId = 2, Cantidad=1}
                );
                db.SaveChanges();
            }
        }*/
        
    }
    
}
