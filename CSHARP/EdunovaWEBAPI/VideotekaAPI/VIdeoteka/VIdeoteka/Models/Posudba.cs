namespace VIdeoteka.Models
{
    public class Posudba : Entitet 
    {
        public string? Naslov { get; set; }
        
        public string Kazete { get; set; }
        public DateTime DatumPosudbe { get; set; }
        public DateTime DatumPovrata { get; set; }
        public List<Clan> Članovi { get; set; }

        public int cijenaPosudbe { get; set; }
        public int cijenaZakasnine { get; set; }
    }
}
