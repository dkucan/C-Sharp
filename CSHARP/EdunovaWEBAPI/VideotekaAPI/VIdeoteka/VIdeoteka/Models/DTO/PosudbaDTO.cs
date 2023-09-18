using System.ComponentModel.DataAnnotations.Schema;

namespace VIdeoteka.Models.DTO
{
    public class PosudbaDTO
    {
        public string Clan { get; set; }
        public List<KAZETA> Kazete { get; set; } = new();
        public DateTime? Datum_posudbe { get; set; }
        public DateTime? Datum_vracanja { get; set; }
        public int Zakasnina { get; set; }

        public int Sifra { get; set; }
    }
}
