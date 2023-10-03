using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacas.Models;

namespace Vacas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacasController : ControllerBase
    {
        private readonly VacaContext _context;

        public VacasController(VacaContext context)
        {
            _context = context;
        }

        // GET: api/Vacas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaca>>> GetVacas()
        {
          if (_context.Vacas == null)
          {
              return NotFound();
          }
            return await _context.Vacas.ToListAsync();
        }

        // GET: api/Vacas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaca>> GetVaca(long id)
        {
          if (_context.Vacas == null)
          {
              return NotFound();
          }
            var vaca = await _context.Vacas.FindAsync(id);

            if (vaca == null)
            {
                return NotFound();
            }

            return vaca;
        }

        // PUT: api/Vacas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaca(long id, Vaca vaca)
        {
            if (id != vaca.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacaExists(id))
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

        // POST: api/Vacas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vaca>> PostVaca(Vaca vaca)
        {
          if (_context.Vacas == null)
          {
              return Problem("Entity set 'VacaContext.Vacas'  is null.");
          }
            _context.Vacas.Add(vaca);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetVaca", new { id = vaca.Id }, vaca);
            return CreatedAtAction(nameof(GetVaca), new { id = vaca.Id }, vaca);
        }

        // DELETE: api/Vacas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaca(long id)
        {
            if (_context.Vacas == null)
            {
                return NotFound();
            }
            var vaca = await _context.Vacas.FindAsync(id);
            if (vaca == null)
            {
                return NotFound();
            }

            _context.Vacas.Remove(vaca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacaExists(long id)
        {
            return (_context.Vacas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
