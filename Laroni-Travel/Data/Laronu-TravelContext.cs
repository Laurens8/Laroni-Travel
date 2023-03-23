using Laroni_Travel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Data
{
    public class Laronu_TravelContext : DbContext
    {
        public Laronu_TravelContext(DbContextOptions<Laronu_TravelContext> options) : base(options) { }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Laroni-Travel");

            //Tabellen aanmaken
            modelBuilder.Entity<Bestemming>().ToTable("Bestemming");
            modelBuilder.Entity<Deelnemer>().ToTable("Deelnemer");
            modelBuilder.Entity<DeelnemerGroepsreis>().ToTable("DeelnemerGroepsreis");
            modelBuilder.Entity<DeelnemerOpleiding>().ToTable("DeelnemerOpleiding");
            modelBuilder.Entity<Groepsreis>().ToTable("Groepsreis");
            modelBuilder.Entity<LeeftijdsCategorie>().ToTable("LeeftijdsCategorie");
            modelBuilder.Entity<Medisch>().ToTable("Medisch");
            modelBuilder.Entity<Opleiding>().ToTable("Opleiding");
            modelBuilder.Entity<OpleidingBestemming>().ToTable("OpleidingBestemming");
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<Thema>().ToTable("Thema");

            //Relaties
            //Een op een relaties
            modelBuilder.Entity<DeelnemerGroepsreis>().HasKey(dg => new { dg.DeelnemerId, dg.GroepsreisId, dg.RolId });
            modelBuilder.Entity<DeelnemerOpleiding>().HasKey(od => new { od.DeelnemerId, od.OpleidingId});
            modelBuilder.Entity<Opleiding>().HasKey(op => new { op.BestemmingId, op.RolId, op.DeelnemerId });
            modelBuilder.Entity<Medisch>().HasKey(m => new { m.DeelnemerId});
            modelBuilder.Entity<Groepsreis>().HasKey(g => new { g.LeeftijdsCategorieId, g.BestemmingId, g.ThemaId });


            //Een op veel relaties
            modelBuilder.Entity<OpleidingBestemming>().HasOne(ob => ob.Bestemming).WithMany(o => o.opleidingBestemming).HasForeignKey(ob => ob.BestemmingId).IsRequired();
            modelBuilder.Entity<Opleiding>().HasOne(ob => ob.Bestemming).WithMany(b => b.opleidingen).HasForeignKey(ob => ob.BestemmingId).IsRequired();
            modelBuilder.Entity<DeelnemerOpleiding>().HasOne(ob => ob.deelnemer).WithMany(d => d.deelnemerOpleiding).HasForeignKey(ob => ob.DeelnemerId).IsRequired();
        }
    }
}
