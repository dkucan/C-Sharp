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
            if (Pomocno.dev)
            {
                TestniPodaci();
            }
            
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
                    UnosNoveKazete();
                    PrikaziIzbornik ();
                    break;
                case 3:
                    PromjenaPostojeceKazete();
                    PrikaziIzbornik();
                    break;
                case 4:
                    if (Kazete.Count == 0)
                    {
                        Console.WriteLine("Nema dostupnih kazeta za brisanje");
                    }
                    else
                    {
                        BrisanjeKazete();
                    }
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad sa kazetama");
                    break;


            }
        }

        private void BrisanjeKazete()
        {
            PrikaziKazete();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj kazete: ", "Nije dobar odabir", 1, Kazete.Count());
            Kazete.RemoveAt(index - 1);
        }

        private void PromjenaPostojeceKazete()
        {
            PrikaziKazete ();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj kazete: ", "Nije dobar odabir", 1,Kazete.Count());
            var s = Kazete[index - 1];
            s.sifra = Pomocno.ucitajCijeliBroj("Unesite šifru kazete (" + s.Sifra + "): ",
                "Unos mora biti pozitivan cijeli broj");
            s.Naslov = Pomocno.ucitajString("Unesite naslov kazete (" + s.Naslov + "): ",
                "Unos obavezan");
            s.Zanr = Pomocno.ucitajString("Unesite žanr (" + s.Zanr + "): ",
                "Unos mora biti pozitivan cijeli broj");
            int godinaIzdanja;
            do
            {
                godinaIzdanja = Pomocno.ucitajCijeliBroj("Unesite godinu izdanja filma (" + s.GodinaIzdanja + "): ",
                "Unos obavezan");

                if (godinaIzdanja < 1920 || godinaIzdanja > 2010)
                {
                    Console.WriteLine("Pogrešno unesena godina. Molimo unesite godinu između 1920. i 2010.");
                }
            } while (godinaIzdanja < 1920 || godinaIzdanja > 2010);

            s.GodinaIzdanja = godinaIzdanja.ToString();
            s.datumUlaskauInventar = Pomocno.ucitajString("Ucitaj datum ulaska u inventar (" + s.datumUlaskauInventar + "): ",
                "Unos obavezan");
            s.cijenaPosudbe = Pomocno.ucitajCijeliBroj("Cijena posudbe (" + s.cijenaPosudbe + "): ",
                "Unos mora biti pozitivan cijeli broj");
            s.cijenaZakasnine = Pomocno.ucitajString("Cijena zakasnine (" + s.cijenaZakasnine + "): ",
                "Unos mora biti pozitivan cijeli broj");

        }

        private void UnosNoveKazete()
        {
            var s = new Kazete();
            s.sifra = Pomocno.ucitajCijeliBroj("Unesite šifru kazete: ", "Unos mora biti pozitivni cijeli broj");
            s.Naslov = Pomocno.ucitajString("Unesite naslov kazete (" + s.Naslov + "): ",
               "Unos obavezan");
            s.Zanr = Pomocno.ucitajString("Unesite žanr (" + s.Zanr + "): ",
                 "Unos obavezan");

            int godinaIzdanja;
            do
            {
                godinaIzdanja = Pomocno.ucitajCijeliBroj("Unesite godinu izdanja filma (" + s.GodinaIzdanja + "): ",
                "Unos obavezan");

                if (godinaIzdanja < 1920 || godinaIzdanja > 2010)
                {
                    Console.WriteLine("Pogrešno unesena godina. Molimo unesite godinu između 1920. i 2010.");
                }
            } while (godinaIzdanja < 1920 || godinaIzdanja > 2010);

            s.GodinaIzdanja = godinaIzdanja.ToString();

            s.cijenaPosudbe = Pomocno.ucitajCijeliBroj("Unesite cijenu posudbe (" + s.cijenaPosudbe + "): ",
                "Iznos mora biti pozitivan cijeli broj");
            s.cijenaZakasnine = Pomocno.ucitajString("Unesite cijenu zakasnine (" + s.cijenaZakasnine + "): ",
                "Iznos mora biti pozitivan cijeli broj");
            Kazete.Add(s);
        }


        private void PrikaziKazete()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("----- Dostupne kazete -----");
            Console.WriteLine("---------------------------");
            int b = 1;
            foreach (Kazete kazete in Kazete)
            {
                Console.WriteLine("\t {0}, {1}",b++, kazete.Naslov);
            }
            Console.WriteLine("---------------------------");
        }
        private void TestniPodaci ()
        {
            Kazete.Add(new Kazete { Naslov = "Armageddon" });
            Kazete.Add(new Kazete { Naslov = "24 Redemption" });
            Kazete.Add(new Kazete { Naslov = "Titanic" });
        }
    }
}
