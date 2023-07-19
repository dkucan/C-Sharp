using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Videoteka
{

        internal class ObradaCijena
        {
            public List<Cijena> Cijena { get; }

            private Izbornik Izbornik;

            public ObradaCijena(Izbornik izbornik) : this()
            {
                this.Izbornik = izbornik;
            }

            public ObradaCijena()
            {
                Cijena = new List<Cijena>();
            }

            public void PrikaziIzbornik()
            {
                Console.WriteLine("Izbornik za rad s cijenama");
                Console.WriteLine("1. Pregled postojećih cijena");
                Console.WriteLine("2. Unos nove cijene");
                Console.WriteLine("3. Promjena postojeće cijene");
                Console.WriteLine("4. Brisanje cijena");
                Console.WriteLine("5. Povratak na glavni izbornik");
                switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika cijena: ",
                    "Odabir mora biti 1-5", 1, 5))
                {
                    case 1:
                        PrikaziGrupe();
                        PrikaziIzbornik();
                        break;
                    case 2:
                        UnosNoveCijene();
                        PrikaziIzbornik();
                        break;
                    case 3:
                        PromjenaCijene();
                        PrikaziIzbornik();
                        break;
                    case 4:
                        BrisanjeGrupe();
                        PrikaziIzbornik();
                        break;
                    case 5:
                        Console.WriteLine("Gotov rad s cijenama");
                        break;
                }
            }

            private void PromjenaCijene()
            {
                PrikaziGrupe();
                int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Cijena.Count());
                var p = Cijena[index - 1];
                p.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra grupe (" + p.Sifra + "): ",
                    "Unos mora biti pozitivni cijeli broj");
                p.Naziv = Pomocno.UcitajString("Unesite naziv grupe (" + p.Naziv + "): ",
                    "Unos obavezan");
                Console.WriteLine("Trenutni smjer: {0}", p.Film.Naziv);
                p.Film = PostaviFilm();
                Console.WriteLine("Trenutni clanovi:");
                Console.WriteLine("------------------");
                Console.WriteLine("---- Clanovi ----");
                Console.WriteLine("------------------");
                int b = 1;
                foreach (Clan clan in p.Clanovi)
                {
                    Console.WriteLine("{0}. {1}", b++, clan);
                }
                Console.WriteLine("------------------");
                p.Clanovi = PostaviClanove();
            }

            private Film PostaviFilm()
            {
                Izbornik.ObradaFilm.PrikaziFilmove();
                int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Izbornik.ObradaFilm.Film.Count());
                return Izbornik.ObradaFilm.Film[index - 1];
            }

            private void BrisanjeGrupe()
            {
                PrikaziGrupe();
                int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Cijena.Count());
                Cijena.RemoveAt(index - 1);
            }

            private void UnosNoveCijene()
            {
                var g = new Cijena ();
                g.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra grupe: ",
                    "Unos mora biti pozitivni cijeli broj");
                g.Naziv = Pomocno.UcitajString("Unesite naziv grupe: ",
                    "Unos obavezan");
                g.Film = PostaviFilm();
                g.Clanovi = PostaviClanove();
                g.DatumPocetka = Pomocno.ucitajDatum("Unesi datum cijene u formatu dd.MM.yyyy.", "Greška");
                Cijena.Add(g);

            }

            private List<Clan> PostaviClanove()
            {
                List<Clan> polaznici = new List<Clan>();
                while (Pomocno.ucitajBool("Želite li dodati polaznike? (da ili bilo što drugo za ne): "))
                {
                    polaznici.Add(PostaviClana());
                }

                return polaznici;
            }

            private Clan PostaviClana()
            {
                Izbornik.ObradaClan.PregledClanova();
                int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1, Izbornik.ObradaClan.Clan.Count());
                return Izbornik.ObradaClan.Clan[index - 1];
            }

            public void PrikaziGrupe()
            {
                Console.WriteLine("------------------");
                Console.WriteLine("---- Filmovi ----");
                Console.WriteLine("------------------");
                int b = 1;
                foreach (ObradaFilm film in Film)
                {
                    Console.WriteLine("{0}. {1}", b++, film.Naziv);
                }
                Console.WriteLine("------------------");
            }


        }
    }
}
}
