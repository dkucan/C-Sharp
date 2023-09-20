using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIdeoteka.Models
{
    public class Posudba : Entitet
    {

        [ForeignKey("clan")]
        public clan? Clan { get; set; }
        public List<KAZETA> Kazete { get; set; } = new();
        public DateTime? Datum_posudbe { get; set; }
        public DateTime? Datum_vracanja { get; set; }
        public int Zakasnina { get; set; }  

      

    }


}

