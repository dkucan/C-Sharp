using System.ComponentModel.DataAnnotations;

namespace VIdeoteka.Models
{
    public abstract class Entitet
    {
        [Key]
        public int Sifra { get; set; }

    }
}
