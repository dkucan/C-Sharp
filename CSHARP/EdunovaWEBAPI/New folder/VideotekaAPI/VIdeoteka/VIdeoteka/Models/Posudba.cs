using System.ComponentModel.DataAnnotations;

namespace VIdeoteka.Models
{
    public class Posudba : Entitet
    {
       
        public DateTime Datum_posudbe { get; set; }
        public DateTime Datum_vracanja { get; set; }
        public int Zakasnina { get; set; }

        public List<Clan> Članovi { get; set; }

     
    }
}
