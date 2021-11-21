using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SUB.Models;

namespace SUB.Data
{
    public class SUBContext : DbContext
    {
        public SUBContext(DbContextOptions<SUBContext> options)
            : base(options)
        {
        }

        public DbSet<SUB.Models.Wydarzenie> Wydarzenie { get; set; }

        public DbSet<SUB.Models.Zgloszenie> Zgloszenie { get; set; }
        
        public DbSet<SUB.Models.Portfel> Portfel { get; set; }
        
        public DbSet<SUB.Models.Kupon> Kupon { get; set; }

    }
}
