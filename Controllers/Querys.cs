using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly Context db;

        public QueryController(Context context)
        {
            db = context;
        }

        [HttpGet("0")]
        public async Task<ActionResult> Query0()
        {

            var list = await db.Pedido.Join(db.Prendas,  pedido => pedido.PrendaId, prendas=> prendas.PrendaId, (pedido, prenda) => new {
                    Ticket = pedido.TicketId,
                    TotalImporte = pedido.Cantidad * prenda.Precio
                }).GroupBy(g=>g.Ticket).Select(g=>new{
                    TiketDeCompra = g.Key,
                    TotalImporte = g.Sum(g => g.TotalImporte),
                }).ToListAsync();
 
            return Ok(new
            {
                ValorActual = "0",
                Descripcion = "0 todos",
                Valores = list,
            });
        }

        [HttpGet("1")]
        public async Task<ActionResult> Query1(int TicketId)
        {

           var list = await db.Pedido.Join(db.Prendas, pedido => pedido.PrendaId, prendas=> prendas.PrendaId, (pedido, prenda) => new {
                    TiketDeCompra = pedido.TicketId,
                    TotalImporte = pedido.Cantidad * prenda.Precio
                }).GroupBy(g=>g.TiketDeCompra).Select(g=>new{
                    TiketDeCompra = g.Key,
                    TotalImporte = g.Sum(g => g.TotalImporte),
                }).ToListAsync();

            var resultado = list.Find(e=>e.TiketDeCompra== TicketId);
            return Ok(new
            {
                ValorActual = "0",
                Descripcion = "0 uno",
                Valores = resultado,
            });
        }


        [HttpGet("2")]
        public async Task<ActionResult> Query3()
        {

                var list = await db.Pedido.Join(db.Prendas, pedido => pedido.PrendaId, prendas=> prendas.PrendaId, (pedido, prenda) => new {
                    Ticket = pedido.TicketId,
                    TotalImporte = pedido.Cantidad * prenda.Precio
                }).Join(db.TiketDeCompra, pedido => pedido.Ticket, ticket=> ticket.TicketId, (pedido, tiket) => new {
                    Cliente = tiket.Cliente,
                    TotalImporte = pedido.TotalImporte
                }).GroupBy(g=>g.Cliente).Select(g=>new{
                    Cliente = g.Key,
                    Total = g.Sum(g=>g.TotalImporte),
                    CantidadCompras = g.Count()
                }).ToListAsync();

 
            return Ok(new
            {
                ValorActual = "1",
                Descripcion = "1 todos",
                Valores = list,
            });
        
        }
         [HttpGet("3")]
        public async Task<ActionResult> Query3(string Cliente)
        {
var list = await db.Pedido.Join(db.Prendas, pedido => pedido.PrendaId, prendas=> prendas.PrendaId, (pedido, prenda) => new {
                    Ticket = pedido.TicketId,
                    TotalImporte = pedido.Cantidad * prenda.Precio
                }).Join(db.TiketDeCompra, pedido => pedido.Ticket, ticket=> ticket.TicketId, (pedido, tiket) => new {
                    Cliente = tiket.Cliente,
                    TotalImporte = pedido.TotalImporte
                }).GroupBy(g=>g.Cliente).Select(g=>new{
                    Cliente = g.Key,
                    Total = g.Sum(g=>g.TotalImporte),
                    CantidadCompras = g.Count()
                }).ToListAsync();

            var resultado = list.Find(e=>e.Cliente== Cliente);
 
            return Ok(new
            {
                ValorActual = "1",
                Descripcion = "1 uno",
                Valores = resultado,
            });

        }


    }
}
