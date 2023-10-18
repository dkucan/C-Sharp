namespace VIdeoteka.Models.DTO
{
    public class kazetaDTO
    {
        public string? Naslov { get; set; }
        public int? Godina_izdanja { get; set; }
        public string? Zanr { get; set; }
        public int Cijena_posudbe { get; set; }
        public int Cijena_zakasnine { get; set; }
    }
}
