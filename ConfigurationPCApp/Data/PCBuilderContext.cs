using Microsoft.EntityFrameworkCore;
using PcBuilderApp.Models;

namespace PcBuilderApp.Data
{
    public class PcBuilderContext : DbContext
    {
        public PcBuilderContext(DbContextOptions<PcBuilderContext> options)
            : base(options)
        {

        }

        public DbSet<Case> Case { get; set; }
        public DbSet<Cpu> Cpu { get; set; }
        public DbSet<Gpu> Gpu { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Psu> Psu { get; set; }
        public DbSet<Ram> Ram { get; set; }
        public DbSet<Ssd> Ssd { get; set; }
        public DbSet<Hdd> Hdd { get; set; }

    }
}
