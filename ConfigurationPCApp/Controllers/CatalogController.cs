using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcBuilderApp.Data;
using PcBuilderApp.Models;
using PcBuilderApp.Models;
using PcBuilderApp.Services.CatalogService;

namespace PcBuilderApp.Controllers
{
    public class CatalogController : Controller
    {
        //private readonly PcBuilderContext _context;

        public CatalogController()
        {
            //_context = context;
        }

        // GET: Cpu
        
        public async Task<IActionResult> GetCpu([FromServices]ICatalogService _catalogService)
        { 
            return View(await _catalogService.GetAllCpuProducts());         
        }
        public async Task<IActionResult> GetGpu([FromServices] ICatalogService _catalogService)
        {

            return View(await _catalogService.GetAllGpuProducts());

        }
        public async Task<IActionResult> GetMotherboard([FromServices] ICatalogService _catalogService)
        {

            return View(await _catalogService.GetAllMotherboardProducts());

        }
        public async Task<IActionResult> GetRam([FromServices] ICatalogService _catalogService)
        {

            return View(await _catalogService.GetAllRamProducts());

        }
        public async Task<IActionResult> GetHdd([FromServices] ICatalogService _catalogService)
        {

            return View(await _catalogService.GetAllHddProducts());

        }
        public async Task<IActionResult> GetSsd([FromServices] ICatalogService _catalogService)
        {

            return View(await _catalogService.GetAllSsdProducts());

        }
        public async Task<IActionResult> GetPsu([FromServices] ICatalogService _catalogService)
        {

            return View(await _catalogService.GetAllPsuProducts());

        }
        public async Task<IActionResult> GetCase([FromServices] ICatalogService _catalogService)
        {

            return View(await _catalogService.GetAllCaseProducts());

        }
        // GET: CPU/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Cpus == null)
        //    {
        //        return NotFound();
        //    }

        //    var cPU = await _context.Cpus
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cPU == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cPU);
        //}

        //private bool CPUExists(int id)
        //{
        //  return (_context.Cpus?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
