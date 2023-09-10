using VIdeoteka.Models;
using Microsoft.EntityFrameworkCore;


namespace VIdeoteka.Data
{
    public class videotekaContext : DbContext
    {
        public videotekaContext(DbContextOptions<videotekaContext> opcije) : base(opcije)
        {
        }

        public DbSet<Kazeta> Kazeta { get; set; }
    }
}
