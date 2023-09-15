using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace VIdeoteka.Models
{
    public class Clan : POSUDBAKAZETA
    {
        [Key]
        public int Sifra { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Adresa { get; set; }
        public string? Mobitel { get; set; }
        public string? OIB { get; set; }
        public DateTime Datum_Uclanjenja { get; set; }

    }
}
