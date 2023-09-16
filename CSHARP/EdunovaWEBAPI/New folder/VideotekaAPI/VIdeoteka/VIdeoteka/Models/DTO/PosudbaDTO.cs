namespace VIdeoteka.Models.DTO
{
    public class PosudbaDTO
    {
        
        public int Sifra { get; set; }
        public DateTime Datum_posudbe { get; set; }
        public DateTime Datum_vracanja { get; set; }
        public int Zakasnina { get; set; }

        public List<Clan> Članovi { get; set; }
    }
}
