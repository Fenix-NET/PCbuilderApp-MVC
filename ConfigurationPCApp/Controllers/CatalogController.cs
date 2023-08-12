using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcBuilderApp.Data;
using PcBuilderApp.Models;
using PcBuilderApp.Services.CatalogService;

namespace PcBuilderApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        // GET: Cpu

        public async Task<IActionResult> GetAllCpu()
        { 
            return View(await _catalogService.GetAllCpuProducts());         
        }
        public async Task<IActionResult> GetCpu(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var dto = await _catalogService.GetProductCartCpu(id);
            if (dto == null)
            {
                return NotFound();
            }
                
            return View(dto);
        }
        public async Task<IActionResult> MinSort()
        {
            var list = await _catalogService.GetAllCpuProducts();
            return View(list.OrderBy(p => p.Price));
        }

		public async Task<IActionResult> MaxSort()
        {
            var list = await _catalogService.GetAllCpuProducts();
            return View(list.OrderByDescending(p => p.Price));
        }
        public async Task<IActionResult> GetAllGpu()
        {
            return View(await _catalogService.GetAllGpuProducts());
        }
        public async Task<IActionResult> GetGpu(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var dto = await _catalogService.GetProductCartGpu(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }
        public async Task<IActionResult> GetAllMotherboard()
        {

            return View(await _catalogService.GetAllMotherboardProducts());

        }
        public async Task<IActionResult> GetMotherboard(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var dto = await _catalogService.GetProductCartMother(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }
        public async Task<IActionResult> GetAllRam()
        {

            return View(await _catalogService.GetAllRamProducts());

        }
        public async Task<IActionResult> GetRam(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var dto = await _catalogService.GetProductCartRam(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }
        public async Task<IActionResult> GetAllHdd()
        {

            return View(await _catalogService.GetAllHddProducts());

        }
        public async Task<IActionResult> GetHdd(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var dto = await _catalogService.GetProductCartHdd(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }
        public async Task<IActionResult> GetAllSsd()
        {

            return View(await _catalogService.GetAllSsdProducts());

        }
        public async Task<IActionResult> GetSsd(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var dto = await _catalogService.GetProductCartSsd(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }
        public async Task<IActionResult> GetAllPsu()
        {

            return View(await _catalogService.GetAllPsuProducts());

        }
        public async Task<IActionResult> GetPsu(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var dto = await _catalogService.GetProductCartPsu(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }
        public async Task<IActionResult> GetAllCase()
        {

            return View(await _catalogService.GetAllCaseProducts());

        }
        public async Task<IActionResult> GetCase(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var dto = await _catalogService.GetProductCartCase(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
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
