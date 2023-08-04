using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcBuilderApp.Data;
using PcBuilderApp.Models;
using PcBuilderApp.Models.DTOs;
using PcBuilderApp.Services.CatalogService;

namespace PcBuilderApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly PcBuilderContext _context;

        public CatalogController(PcBuilderContext context)
        {
            _context = context;
        }

        // GET: CPU
        
        public async Task<IActionResult> GetCpu([FromServices]ICatalogService _catalogService)
        {

            return View(await _catalogService.GetAllCpu());
                        
        }

        // GET: CPU/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cpus == null)
            {
                return NotFound();
            }

            var cPU = await _context.Cpus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cPU == null)
            {
                return NotFound();
            }

            return View(cPU);
        }

        private bool CPUExists(int id)
        {
          return (_context.Cpus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
