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
    public class ClientesController : ControllerBase
    {
        private readonly Context _context;

        public ClientesController(Context context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetClientes(int id)
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            var clientes = await _context.Clientes
                            .Where(c => c.ClienteId == id)
                            .FirstOrDefaultAsync();

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes(int id, Clientes clientes)
        {
            if (id != clientes.ClienteId)
            {
                return BadRequest();
            }

            _context.Entry(clientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesIDExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {
          if (!ClientesIDExists(clientes.ClienteId))
          {
              _context.Clientes.Add(clientes);
          }
          else
          {
            _context.Clientes.Update(clientes);
          }
            await _context.SaveChangesAsync();

            return Ok(clientes);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientesIDExists(int id)
        {
            return (_context.Clientes?.Any(e => e.ClienteId == id)).GetValueOrDefault();
        }

        public bool ExistenDatos(Clientes clientes)
        {
            var existenDatos = _context.Clientes.Any(c => c.ClienteId == clientes.ClienteId ||
                (c.Nombre == clientes.Nombre 
                || c.Rnc == clientes.Rnc)
            );

            return existenDatos;
        }
    }
}
