using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dunca_Tarau_Proiect.Models;

namespace Dunca_Tarau_Proiect.Data
{
    public class Dunca_Tarau_ProiectContext : DbContext
    {
        public Dunca_Tarau_ProiectContext (DbContextOptions<Dunca_Tarau_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Dunca_Tarau_Proiect.Models.Tour> Tour { get; set; } = default!;

        public DbSet<Dunca_Tarau_Proiect.Models.Country> Country { get; set; }

        public DbSet<Dunca_Tarau_Proiect.Models.Category> Category { get; set; }
    }
}
