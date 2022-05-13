using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevOpsServiceAPI.Data;
using DevOpsServiceAPI.Models;

namespace DevOpsServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionsController : ControllerBase
    {
        private readonly DevOpsServiceAPIContext _context;

        public PensionsController(DevOpsServiceAPIContext context)
        {
            _context = context;
        }

        // GET: api/Pensions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pension>>> GetPension()
        {
          if (_context.Pension == null)
          {
              return NotFound();
          }
            return await _context.Pension.ToListAsync();
        }

        // GET: api/Pensions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pension>> GetPension(int id)
        {
          if (_context.Pension == null)
          {
              return NotFound();
          }
            var pension = await _context.Pension.FindAsync(id);

            if (pension == null)
            {
                return NotFound();
            }

            return pension;
        }

        // PUT: api/Pensions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPension(int id, Pension pension)
        {
            if (id != pension.Id)
            {
                return BadRequest();
            }

            _context.Entry(pension).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PensionExists(id))
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

        // POST: api/Pensions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pension>> PostPension(Pension pension)
        {
          if (_context.Pension == null)
          {
              return Problem("Entity set 'DevOpsServiceAPIContext.Pension'  is null.");
          }
            _context.Pension.Add(pension);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPension", new { id = pension.Id }, pension);
        }

        // DELETE: api/Pensions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePension(int id)
        {
            if (_context.Pension == null)
            {
                return NotFound();
            }
            var pension = await _context.Pension.FindAsync(id);
            if (pension == null)
            {
                return NotFound();
            }

            _context.Pension.Remove(pension);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PensionExists(int id)
        {
            return (_context.Pension?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
