using VIdeoteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace VIdeoteka.Data
{
    public class videotekaContext : DbContext
    {
        public videotekaContext(DbContextOptions<videotekaContext> opcije) : base(opcije)
        {
        }

        public DbSet<KAZETA> Kazeta { get; set; }

        public DbSet<clan> Clan { get; set; }

        public DbSet<Posudba> posudba { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posudba>().HasOne(o => o.Clan);
            modelBuilder.Entity<Posudba>()
                .HasMany(p => p.Kazete)
                .WithMany(k => k.Posudbe)
                .UsingEntity<Dictionary<string, object>>("posudbakazeta",
                ps => ps.HasOne<KAZETA>().WithMany().HasForeignKey("kazeta"),
                ps => ps.HasOne<Posudba>().WithMany().HasForeignKey("posudba"),
                ps => ps.ToTable("posudbakazeta")
                );

    }
    }
}



