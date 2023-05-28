using Laroni_Travel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Data
{
    public class Laroni_TravelContext : DbContext
    {
        //public Laronu_TravelContext(DbContextOptions<Laronu_TravelContext> options) : base(options) { }

        public DbSet<Bestemming> Bestemmingen { get; set; }
        public DbSet<Deelnemer> Deelnemers { get; set; }
        public DbSet<DeelnemerGroepsreis> DeelnemerGroepsreisen { get; set; }
        public DbSet<DeelnemerOpleiding> DeelnemerOpleidingen { get; set; }
        public DbSet<Groepsreis> Groepsreisen { get; set; }
        public DbSet<LeeftijdsCategorie> LeeftijdsCategorieen { get; set; }
        public DbSet<Medisch> Medische { get; set; }
        public DbSet<Opleiding> Opleidingen { get; set; }
        public DbSet<OpleidingBestemming> OpleidingBestemmingen { get; set; }
        public DbSet<Rol> Rolen { get; set; }
        public DbSet<Thema> Themas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Laroni-Travel;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }
}
