using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiRecu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly Context _context;

        public TicketController(Context context)
        {
            _context = context;
        }

        // GET: api/Ticket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDeCompra>>> GetTiketDeCompra()
        {
            return await _context.TiketDeCompra.ToListAsync();
        }

        // GET: api/Ticket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDeCompra>> GetTicketDeCompra(int id)
        {
            var ticketDeCompra = await _context.TiketDeCompra.FindAsync(id);

            if (ticketDeCompra == null)
            {
                return NotFound();
            }

            return ticketDeCompra;
        }

        // PUT: api/Ticket/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketDeCompra(int id, TicketDeCompra ticketDeCompra)
        {
            if (id != ticketDeCompra.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(ticketDeCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketDeCompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ticket
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketDeCompra>> PostTicketDeCompra(TicketDeCompra ticketDeCompra)
        {
            _context.TiketDeCompra.Add(ticketDeCompra);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TicketDeCompraExists(ticketDeCompra.TicketId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTicketDeCompra", new { id = ticketDeCompra.TicketId }, ticketDeCompra);
        }

        // DELETE: api/Ticket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketDeCompra(int id)
        {
            var ticketDeCompra = await _context.TiketDeCompra.FindAsync(id);
            if (ticketDeCompra == null)
            {
                return NotFound();
            }

            _context.TiketDeCompra.Remove(ticketDeCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketDeCompraExists(int id)
        {
            return _context.TiketDeCompra.Any(e => e.TicketId == id);
        }
    }
}
