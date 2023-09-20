namespace EdunovaAPP.Models
{
    public class Smjer : Entitet
    {
        public string? Naziv{ get; set; }
        public  int trajanje { get; set; }

        public decimal cijena{ get; set; }

        public decimal upisnina { get; set; }

        public bool Verificiran { get; set; }

    }
}
