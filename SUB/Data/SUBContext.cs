using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SUB.Models;

namespace SUB.Data
{
    /// <summary>
    /// Kontekst bazy danych dla modelu danych
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
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

        public DbSet<SUB.Models.AspNetUsers> AspNetUsers { get; set; }

    }
}
