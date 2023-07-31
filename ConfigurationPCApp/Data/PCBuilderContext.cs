using Microsoft.EntityFrameworkCore;
using PCBuilderApp.Models;

namespace PCBuilderApp.Data
{
    public class PCBuilderContext : DbContext
    {
        public PCBuilderContext(DbContextOptions<PCBuilderContext> options)
            : base(options)
        {

        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PSU> PSUs { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<ImageCase> ImageCases { get; set; }
        public DbSet<ImageCPU> ImageCPUs { get; set; }
        public DbSet<ImageGPU> ImageGPUs { get; set; }
        public DbSet<ImageMotherboard> ImageMotherboards { get; set; }
        public DbSet<ImagePSU> ImagePSUs { get; set; }
        public DbSet<ImageRAM> ImageRAMs { get; set; }

    }
}
