using Microsoft.EntityFrameworkCore;
using VIdeoteka.Models;

namespace VIdeoteka.Data
{
    public class VideotekaContext : DbContext
    {
        public VideotekaContext(DbContextOptions<VideotekaContext> opcije) : base (opcije) 
        { 
        }
        public DbSet<Posudba> Posudba { get; set;}
    }
}
