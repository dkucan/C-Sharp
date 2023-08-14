using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class ObradaPosudba
    {
        public List<Posudba> Posudba { get; }
        
        public Izbornik Izbornik;
        
        public ObradaPosudba (Izbornik izbornik):this()
        {
            this.Izbornik = izbornik;
        }
     
        public ObradaPosudba()
        {
            Posudba = new List<Posudba>();
        }

        public void PrikaziIZbornik()
        {
            Console.WriteLine("Izbornik za rad sa posudbama");
            Console.WriteLine("1. Pregled postojećih posudbi");
            Console.WriteLine("2. Unos nove posudbe");
            Console.WriteLine("3. Promjena postojeće posudbe");
            Console.WriteLine("4. Povratak na glavni izbornik");
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika Posudba: ",
                "Odabir mora biti 1-4", 1,4))
            {
                case 1:
                    PregledPosudbi();
                    PrikaziIZbornik();
                    break;
                case 2:
                    UnosNovePosudbe();
                    PrikaziIZbornik();
                    break;
                case 3:
                    PromjenaPostojećePosudbe();
                    PrikaziIZbornik();
                    break;
                case 4:
                    Console.WriteLine("Gotov rad s posudbama");
                    break;
            }
        }

        private void PromjenaPostojećePosudbe()
        {
            
        }

        private void UnosNovePosudbe()
        {
            var g = new Posudba();
            g.Sifra = Pomocno.ucitajCijeliBroj("Unesite sifru posudbe: ",
                "Unos mora biti pozitivni cijeli broj");
            g.Naslov = Pomocno.ucitajString("Unesite naslov posudbe: ",
                "Unos obavezan");
            DateTime datumPosudbe;
            if (!DateTime.TryParseExact(Pomocno.ucitajString("Unesite datum posudbe (dd.MM.yyyy): ", "Datum obavezan"),
                "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out datumPosudbe))
            {
                Console.WriteLine("Neispravan format datuma posudbe. Upotrijebite format dd.MM.yyyy.");
                return;
            }
            g.DatumPosudbe = datumPosudbe;

            DateTime datumPovrata;
            if (!DateTime.TryParseExact(Pomocno.ucitajString("Unesite datum povrata (dd.MM.yyyy): ", "Datum obavezan"),
                "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out datumPovrata))
            {
                Console.WriteLine("Neispravan format datuma povrata. Upotrijebite format dd.MM.yyyy.");
                return;
            }
            g.DatumPosudbe = Pomocno.ucitajDatum("Unesite datum posudbe: ",
                "Unos obavezan");
            g.DatumPovrata = Pomocno.ucitajDatum("Unesite datum povrata: ",
                "Unos obavezan");
            g.cijenaPosudbe = Pomocno.ucitajCijeliBroj("Unesite cijenu posudbe: ",
                "Unos obavezan");
            g.cijenaZakasnine = Pomocno.ucitajCijeliBroj("Unesite cijenu zakasnine: ",
                "Unos obavezan");
            g.Članovi = ucitajClanove();

            Posudba.Add(g);

        }

        private List<Clan> ucitajClanove()
        {
            List<Clan> Clan = new List<Clan>();
           while (Pomocno.ucitajCijeliBroj("1 za dodavanje članova", "Greška") ==1)
            {
                var p = new Clan();
                p.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifru člana: ",
                    "Unos mora biti pozitivni cijeli broj");
                p.Ime = Pomocno.ucitajString("Unesi ime člana: ", "Ime obavezno");
                p.Prezime = Pomocno.ucitajString("Unesi prezime člana: ", "Prezime obavezno");
                p.Adresa = Pomocno.ucitajString("Unesi adresu člana: ", "Adresa obavezno");
                p.Telefon = Pomocno.ucitajString("Unesi kontakt telefon člana: ", "telefon obavezno");
                p.OIB = Pomocno.ucitajString("Unesi OIB člana: ", "OIB obavezno");
                p.DatumUclanjenja = Pomocno.ucitajString("Unesi datum učlanjenja člana", "datum obavezno");
                Clan.Add(p);
            }



            return Clan;
        }

        public void PregledPosudbi()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("---- Pregled i evidencija posudbi ----");
            Console.WriteLine("--------------------------------------");
            int b = 1;
            foreach (Posudba posudba in Posudba)
            {
                Console.WriteLine("{0}. {1}", b++, posudba.Naslov);
            }
            Console.WriteLine("---------------------------------------");
        }
    }
}
