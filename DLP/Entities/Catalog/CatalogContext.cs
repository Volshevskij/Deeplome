using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DLP.Entities.Catalog
{
    public class CatalogContext:DbContext
    {
        public DbSet<Corpus> Corpuses { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Processor> Processors { get; set; }     
        public DbSet<Ram> RAMs { get; set; }
        public DbSet<Cooling> Coolers { get; set; }
        public DbSet<Video> GPUs { get; set; }
        public IConfiguration Configuration { get; }


        public CatalogContext(DbContextOptions<CatalogContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }
    }
}
