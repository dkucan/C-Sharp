using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class ObradaKazete
    {
        public List<Kazete> Kazete { get; }

        public ObradaKazete()
        {
            Kazete = new List<Kazete>();
            TestniPodaci();
            
        }
        public void PrikaziIzbornik ()
        {
            Console.WriteLine("Izbornik za rad sa kazetama");
            Console.WriteLine("1. Pregled postojećih kazeta");
            Console.WriteLine("2. Unos nove kazete");
            Console.WriteLine("3. Promjena postojeće kazete");
            Console.WriteLine("4. Brisanje kazete");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.ucitajBrojRaspon ("Odaberite stavku izbornika smjera: ",
                "Odabir mora biti 1-5", 1,5))
            {
                case 1:
                    PrikaziKazete();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnovNoveKazete();
                    PrikaziIzbornik ();
                    break;
                case 3:
                    PromjenaPostojeceKazete();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeKazete();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad sa kazetama");
                    break;


            }
        }

        private void BrisanjeKazete()
        {
            throw new NotImplementedException();
        }

        private void PromjenaPostojeceKazete()
        {
            throw new NotImplementedException();
        }

        private void UnovNoveKazete()
        {
            var s = new Kazete();
            s.sifra = Pomocno.ucitajCijeliBroj("Unesite naziv kazete", "Unos mora biti pozitivni cijeli broj");
            s.Naslov = Pomocno.ucitajString("Unesite naslov kazete (" + s.Naslov + "): ",
               "Unos obavezan");
            s.Zanr = Pomocno.ucitajString("Unesite žanr (" + s.Zanr + "): ",
                "Unos obavezan");
            Kazete.Add(s);
        }

        private void PrikaziKazete()
        {
            foreach (Kazete kazete in Kazete)
            {
                Console.WriteLine(kazete.Naslov);
            }
        }
        private void TestniPodaci ()
        {
            Kazete.Add(new Kazete { Naslov = "Armageddon" });
        }
    }
}
