using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLP.Entities.PC
{
    public class PCContext:DbContext
    {
        public DbSet<PC> PCs { get; set; }
        public IConfiguration Configuration { get; }


        public PCContext(DbContextOptions<PCContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }
    }
}
