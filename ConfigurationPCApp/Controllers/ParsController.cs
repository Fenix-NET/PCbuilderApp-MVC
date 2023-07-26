using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConfigurationPCApp.Data;
using ConfigurationPCApp.Parser.DTOs;
using ConfigurationPCApp.Models;

namespace ConfigurationPCApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParsController : ControllerBase
    {
        private readonly ConfigurationPCContext _context;

        public ParsController(ConfigurationPCContext context)
        {
            _context = context;
        }

        // GET: api/Pars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CPU>>> GetCPUparse()  // [Fromservices]
        {
          if (_context.CPUs == null)
          {
              return NotFound();
          }
            return await _context.CPUs.ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GPU>>> GetGPUparse()
        {
            if (_context.GPUs == null)
            {
                return NotFound();
            }
            return await _context.GPUs.ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotherBoard>>> GetMotherBoardparse()
        {
            if (_context.GPUs == null)
            {
                return NotFound();
            }
            return await _context.MotherBoards.ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RAM>>> GetRAMparse()
        {
            if (_context.GPUs == null)
            {
                return NotFound();
            }
            return await _context.RAMs.ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PSU>>> GetPSUparse()
        {
            if (_context.GPUs == null)
            {
                return NotFound();
            }
            return await _context.PSUs.ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Case>>> GetCaseparse()
        {
            if (_context.GPUs == null)
            {
                return NotFound();
            }
            return await _context.Cases.ToListAsync();
        }




        // GET: api/Pars/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CPUparse>> GetCPUparse(int id)
        //{
        //  if (_context.CPUparses == null)
        //  {
        //      return NotFound();
        //  }
        //    var cPUparse = await _context.CPUparses.FindAsync(id);

        //    if (cPUparse == null)
        //    {
        //        return NotFound();
        //    }

        //    return cPUparse;
        //}

        // PUT: api/Pars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCPUparse(int id, CPUparse cPUparse)
        //{
        //    if (id != cPUparse.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cPUparse).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CPUparseExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Pars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CPUparse>> PostCPUparse(CPUparse cPUparse)
        //{
        //  if (_context.CPUparses == null)
        //  {
        //      return Problem("Entity set 'ConfigurationPCContext.CPUparse'  is null.");
        //  }
        //    _context.CPUparses.Add(cPUparse);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCPUparse", new { id = cPUparse.Id }, cPUparse);
        //}

        // DELETE: api/Pars/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCPUparse(int id)
        //{
        //    if (_context.CPUparses == null)
        //    {
        //        return NotFound();
        //    }
        //    var cPUparse = await _context.CPUparses.FindAsync(id);
        //    if (cPUparse == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CPUparses.Remove(cPUparse);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CPUparseExists(int id)
        //{
        //    return (_context.CPUparses?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
