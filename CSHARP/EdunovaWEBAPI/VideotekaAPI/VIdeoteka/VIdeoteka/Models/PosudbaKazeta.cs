using System.ComponentModel.DataAnnotations;

namespace VIdeoteka.Models
{
    public abstract class POSUDBAKAZETA
    {
        [Key]
        public int Sifra { get; set;  }
    }
}
