using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{

        internal class ObradaFilm
        {
            public List<Film> Film{ get; }

            public ObradaFilm()
            {
                Film = new List<Film>();
                if (Pomocno.dev)
                {
                    TestniPodaci();
                }


            }

            public void PrikaziIzbornik()
            {
                Console.WriteLine("Izbornik za rad s filmovima");
                Console.WriteLine("1. Pregled postojećih filmova");
                Console.WriteLine("2. Unos novog filma");
                Console.WriteLine("3. Promjena postojećeg filma");
                Console.WriteLine("4. Brisanje filma"); 
                Console.WriteLine("5. Povratak na glavni izbornik");
                switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika smjera: ",
                    "Odabir mora biti 1-5", 1, 5))
                {
                    case 1:
                        PregledFilmova();
                        PrikaziIzbornik();
                        break;
                    case 2:
                        UnosNovogSmjera();
                        PrikaziIzbornik();
                        break;
                    case 3:
                        PromjenaFilma();
                        PrikaziIzbornik();
                        break;
                    case 4:
                        BrisanjeSmjera();
                        PrikaziIzbornik();
                        break;
                    case 5:
                        Console.WriteLine("Gotov rad s smjerovima");
                        break;
                }
            }

            private void PromjenaFilma()
            {
                PrikaziFilmove();
                int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj smjera: ", "Nije dobar odabir", 1, Film.Count());
                var s = Film[index - 1];
                s.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra smjera (" + s.Sifra + "): ",
                    "Unos mora biti pozitivni cijeli broj");
                s.Naziv = Pomocno.UcitajString("Unesite naziv smjera (" + s.Naziv + "): ",
                    "Unos obavezan");
                s.Trajanje = Pomocno.ucitajCijeliBroj("Unesite trajanje smjera u satima (" + s.Trajanje + "): ",
                    "Unos mora biti cijeli pozitivni broj");
                s.Cijena = Pomocno.ucitajDecimalniBroj("Unesite cijenu (. za decimalni dio) (" + s.Cijena + "): ", "Unos mora biti pozitivan broj");
                s.DobrnoOgranicenje = Pomocno.ucitajBool("DobnoOgranicenje? Da ili bilo što drugo za ne (" + (s.DobnoOgranicenje ? "da" : "ne") + "): ");
            }

            private void BrisanjeSmjera()
            {
                PrikaziFilmove();
                int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj smjera: ", "Nije dobar odabir", 1, Film.Count());
                Film.RemoveAt(index - 1);
            }

            private void UnosNovogSmjera()
            {
                var s = new Film();
                s.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra filma: ",
                    "Unos mora biti pozitivni cijeli broj");
                s.Naziv = Pomocno.UcitajString("Unesite naziv filma: ",
                    "Unos obavezan");
                s.Trajanje = Pomocno.ucitajCijeliBroj("Unesite trajanje filma u satima: ",
                    "Unos mora biti cijeli pozitivni broj");
                s.Cijena = Pomocno.ucitajDecimalniBroj("Unesite cijenu (. za decimalni dio): ", "Unos mora biti pozitivan broj");
                s.DobnoOgranicenje = Pomocno.ucitajBool("Smjer verificiran? Da ili bilo što drugo za ne: ");
                Film.Add(s);

            }

            public void PrikaziFilmove()
            {
                Console.WriteLine("------------------");
                Console.WriteLine("---- Filmovi ----");
                Console.WriteLine("------------------");
                int b = 1;
                foreach (ObradaFilm film in Film)
                {
                    Console.WriteLine("{0}. {1}", b++, ObradaFilm.Naziv);
                }
                Console.WriteLine("------------------");
            }

            private void TestniPodaci()
            {
                Film.Add(new Film
                {
                    Sifra = 1,
                    Naziv = "Titanic",
                    Trajanje = 250,
                    Cijena = 10,
                    DobnoOgranicenje = true
                });

                Film.Add(new Film
                {
                    Sifra = 2,
                    Naziv = "Armageddon",
                    Trajanje = 130,
                    Cijena = 10,
                    DobnoOgranicenje = true
                });
            }
        }
    }