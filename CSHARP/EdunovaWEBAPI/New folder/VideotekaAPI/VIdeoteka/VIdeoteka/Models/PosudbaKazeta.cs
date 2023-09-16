using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIdeoteka.Models
{
    public class POSUDBAKAZETA : Entitet
    {
        [Key]
        public int Sifra { get; set;  }
        [ForeignKey("Kazeta")]
        public int Kazeta { get; set; }
        [ForeignKey("Posudba")]
        public int Posudba { get; set; }

        public int Cijena_posudbe { get; set; }

        public int Cijena_zakasnine { get; set;}




    }
}
