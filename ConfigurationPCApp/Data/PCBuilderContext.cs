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

        public DbSet<Case> Cases { get; set; }
        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<Gpu> Gpus { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Psu> Psus { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<ImageCase> ImageCases { get; set; }
        public DbSet<ImageCpu> ImageCpus { get; set; }
        public DbSet<ImageGpu> ImageGpus { get; set; }
        public DbSet<ImageMotherboard> ImageMotherboards { get; set; }
        public DbSet<ImagePsu> ImagePsus { get; set; }
        public DbSet<ImageRam> ImageRams { get; set; }

    }
}
