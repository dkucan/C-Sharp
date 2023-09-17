using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIdeoteka.Models
{
    public class Posudba : Entitet
    {

       
        [Key]
        public clan? Clan { get; set; }
        [ForeignKey("clan")]
        public List <KAZETA> Kazete { get; set; }
        public DateTime? Datum_Posudbe { get; set; }
        public DateTime? Datum_Vracanja { get; set; }
        public int Zakasnina { get; set; }  
      

    }


}

