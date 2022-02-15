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
    public class PrendasController : ControllerBase
    {
        private readonly Context _context;

        public PrendasController(Context context)
        {
            _context = context;
        }

        // GET: api/Prendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prendas>>> GetPrendas()
        {
            return await _context.Prendas.ToListAsync();
        }

        // GET: api/Prendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prendas>> GetPrendas(int id)
        {
            var prendas = await _context.Prendas.FindAsync(id);

            if (prendas == null)
            {
                return NotFound();
            }

            return prendas;
        }

        // PUT: api/Prendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrendas(int id, Prendas prendas)
        {
            if (id != prendas.PrendaId)
            {
                return BadRequest();
            }

            _context.Entry(prendas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrendasExists(id))
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

        // POST: api/Prendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prendas>> PostPrendas(Prendas prendas)
        {
            _context.Prendas.Add(prendas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrendasExists(prendas.PrendaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrendas", new { id = prendas.PrendaId }, prendas);
        }

        // DELETE: api/Prendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrendas(int id)
        {
            var prendas = await _context.Prendas.FindAsync(id);
            if (prendas == null)
            {
                return NotFound();
            }

            _context.Prendas.Remove(prendas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrendasExists(int id)
        {
            return _context.Prendas.Any(e => e.PrendaId == id);
        }
    }
}
