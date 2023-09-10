using System.ComponentModel.DataAnnotations;

namespace VIdeoteka.Models
{
    public abstract class PosudbaKazeta
    {
        [Key]
     public int Sifra { get; set; }
    }
}
