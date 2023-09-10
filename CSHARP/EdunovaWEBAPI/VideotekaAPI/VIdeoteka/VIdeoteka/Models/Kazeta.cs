using System.ComponentModel.DataAnnotations;


namespace VIdeoteka.Models
{
    public class KAZETA : POSUDBAKAZETA
    {
        [Required]
        public string Naslov { get; set; } 

        public DateTime Godina_izdanja { get; set; }

        public string Zanr { get; set; } 

        public int Cijena_posudbe { get; set; }
        public int Cijena_zakasnine { get; set; }
    }
}