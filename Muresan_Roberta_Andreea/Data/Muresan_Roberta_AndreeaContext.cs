using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Muresan_Roberta_Andreea.Models;

namespace Muresan_Roberta_Andreea.Data
{
    public class Muresan_Roberta_AndreeaContext : DbContext
    {
        public Muresan_Roberta_AndreeaContext (DbContextOptions<Muresan_Roberta_AndreeaContext> options)
            : base(options)
        {
        }

        public DbSet<Muresan_Roberta_Andreea.Models.Meniu> Meniu { get; set; }

        public DbSet<Muresan_Roberta_Andreea.Models.Categorie> Categorie { get; set; }

        public DbSet<Muresan_Roberta_Andreea.Models.Category> Category { get; set; }

    }
}
