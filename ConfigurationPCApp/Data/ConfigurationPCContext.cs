using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConfigurationPCApp.Parser.DTOs;

namespace ConfigurationPCApp.Data
{
    public class ConfigurationPCContext : DbContext
    {
        public ConfigurationPCContext (DbContextOptions<ConfigurationPCContext> options)
            : base(options)
        {

        }

        public DbSet<ConfigurationPCApp.Models.CPU> CPUs { get; set; } = default!;
        public DbSet<ConfigurationPCApp.Models.Case> Cases { get; set; } = default!;
        public DbSet<ConfigurationPCApp.Models.GPU> GPUs { get; set; } = default!;
        public DbSet<ConfigurationPCApp.Models.MotherBoard> MotherBoards { get; set; } = default!;
        public DbSet<ConfigurationPCApp.Models.PSU> PSUs { get; set; } = default!;
        public DbSet<ConfigurationPCApp.Models.RAM> RAMs { get; set; } = default!;

    }
}
