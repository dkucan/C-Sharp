using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class Izbornik
    {
        public ObradaFilm ObradaFilm { get; set; }

        public ObradaClan ObradaClan { get; }

        public ObradaCijena ObradaCijena { get; }

        public Izbornik ()
        {
            ObradaFilm = new ObradaFilm();
            ObradaClan = new ObradaClan();
            ObradaCijena = new ObradaCijena();
            PozdravnaPoruka();
            PrikaziIzbornik();
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("***** Videoteka Mursa APP v1.0 ******");
            Console.WriteLine("**************************************");
        }
        
        private void PrikaziIzbornik ()
        {
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("1. Filmovi");
            Console.WriteLine("2. Clanovi");
            Console.WriteLine("3. Cijena");
            Console.WriteLine("4. Izlaz iz programa");

            switch (Pomocno.ucitajBrojRaspon ("Odaberite stavku izbornika: ",
                "Odabir mora biti 1-4", 1, 4))
            {
                case 1:
                    ObradaFilm.PrikaziIzbornik();
                    PrikaziIzbornik ();
                    break;
                    case 2:
                    ObradaClan.PrikaziIzbornik ();
                    PrikaziIzbornik();
                    break;
                    case 3:
                    ObradaCijena.PrikaziIzbornik ();
                    PrikaziIzbornik();
                    break;
                    case 4:
                    Console.WriteLine("Hvala na korištenju, dovidjenja");
                    break;

            }
        }
    }
}
