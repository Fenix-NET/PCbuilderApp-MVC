using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConfigurationPCApp.Data;
using ConfigurationPCApp.Models;

namespace ConfigurationPCApp.View
{
    public class CPUListModel : PageModel
    {
        private readonly ConfigurationPCApp.Data.ConfigurationPCContext _context;

        public CPUListModel(ConfigurationPCApp.Data.ConfigurationPCContext context)
        {
            _context = context;
        }

        public IList<CPU> CPU { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CPUs != null)
            {
                CPU = await _context.CPUs.ToListAsync();
            }
        }
    }
}
