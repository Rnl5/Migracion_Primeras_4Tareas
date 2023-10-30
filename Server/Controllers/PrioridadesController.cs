using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Migracion_Tarea1_Hasta_Tarea4.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadesController : ControllerBase
    {
        private readonly Context _context;

        public PrioridadesController(Context context)
        {
            _context = context;
        }

        // GET: api/Prioridades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prioridades>>> GetPrioridades()
        {
          if (_context.Prioridades == null)
          {
              return NotFound();
          }
            return await _context.Prioridades.ToListAsync();
        }

        // GET: api/Prioridades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prioridades>> GetPrioridades(int id)
        {
          if (_context.Prioridades == null)
          {
              return NotFound();
          }
            var prioridades = await _context.Prioridades
                            .Where(p => p.PrioridadId == id)
                            .FirstOrDefaultAsync();

            if (prioridades == null)
            {
                return NotFound();
            }

            return prioridades;
        }

        // PUT: api/Prioridades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrioridades(int id, Prioridades prioridades)
        {
            if (id != prioridades.PrioridadId)
            {
                return BadRequest();
            }

            _context.Entry(prioridades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrioridadesIDExists(id))
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

        // POST: api/Prioridades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prioridades>> PostPrioridades(Prioridades prioridades)
        {
          if (!PrioridadesIDExists(prioridades.PrioridadId))
          {
              _context.Prioridades.Add(prioridades);
          }

          else if(ExisteDescripcion(prioridades.Descripcion))
          {
            return BadRequest();
          }

          else
          {
            _context.Prioridades.Update(prioridades);
          }
            await _context.SaveChangesAsync();

            return Ok(prioridades);
        }

        // DELETE: api/Prioridades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrioridades(int id)
        {
            if (_context.Prioridades == null)
            {
                return NotFound();
            }
            var prioridades = await _context.Prioridades.FindAsync(id);
            if (prioridades == null)
            {
                return NotFound();
            }

            _context.Prioridades.Remove(prioridades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrioridadesIDExists(int id)
        {
            return (_context.Prioridades?.Any(e => e.PrioridadId == id)).GetValueOrDefault();
        }

        public bool ExisteDescripcion(string descripcion)
        {
            var mismosDatos = _context.Prioridades.Any(p => (p.Descripcion == descripcion));

            return mismosDatos;
        }
    }
}
