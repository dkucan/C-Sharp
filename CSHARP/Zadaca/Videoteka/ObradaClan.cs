using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class ObradaClan
    {
        public List<Clan> Članovi { get; }
        public ObradaClan() 
        {
            Članovi = new List<Clan>();
            if (Pomocno.dev)
            {
                TestniPodaci();
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s članovima");
            Console.WriteLine("1. Pregled postojećih članova");
            Console.WriteLine("2. Unos novog člana");
            Console.WriteLine("3. Promjena postojećeg člana");
            Console.WriteLine("4. Brisanje člana");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika član: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    PregledClanova();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UcitajČlana();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaČlana();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeČlana();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s članovima");
                    break;

            }

        }

        private void BrisanjeČlana()
        {
            throw new NotImplementedException();
        }

        private void PromjenaČlana()
        {
            throw new NotImplementedException();
        }

        private void UcitajČlana()
        {
            var p = new Clan();
            p.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifru člana: ",
                "Unos mora biti pozitivni cijeli broj");
            p.Ime = Pomocno.ucitajString("Unesi ime člana: ", "Ime obavezno");
            p.Prezime = Pomocno.ucitajString("Unesi prezime člana: ", "Prezime obavezno");
            p.Adresa = Pomocno.ucitajString("Unesi adresu člana: ", "Adresa obavezno");
            p.Telefon = Pomocno.ucitajString("Unesi kontakt telefon člana: ", "telefon obavezno");
            p.OIB = Pomocno.ucitajString("Unesi OIB člana: ", "OIB obavezno");
            string datumUclanjenjaInput = Pomocno.ucitajString("Unesi datum učlanjenja člana (dd.MM.yyyy): ", "Datum obavezan");

            DateTime datumUclanjenja;
            if (!DateTime.TryParseExact(datumUclanjenjaInput, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out datumUclanjenja))
            {
                Console.WriteLine("Neispravan format datuma. Upotrijebite format dd.MM.yyyy.");
                return;
            }
            if (datumUclanjenja.Year < 1975 || datumUclanjenja.Year > 2010)
            {
                Console.WriteLine("Pogrešno unesena godina! Dopušteni raspon godina je između 1975. i 2010.");
                return;
            }
            p.DatumUclanjenja = datumUclanjenja.ToString("dd.MM.yyyy");
            Članovi.Add(p);

}


public void PregledClanova()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("----- Članovi --------");
            Console.WriteLine("----------------------");
            int b = 1;
            foreach (Clan Clan in Članovi)
            {
                Console.WriteLine("\t {0}, {1}", b++, Clan);
            }
            Console.WriteLine("----------------------");
        }

        private void TestniPodaci()
        {
            Članovi.Add(new Clan
            {
                Sifra = 1,
                Ime = "Pero",
                Prezime = "Zimski",
                Adresa = "Huttlerova 27",
                Telefon = "123-456",
                OIB = "12345678910",
                DatumUclanjenja = "22.07.2000"
            });

            Članovi.Add(new Clan
            {
                Sifra = 2,
                Ime = "Marko",
                Prezime = "Marković",
                Adresa = "Huttlerova 27",
                Telefon = "234-567",
                OIB = "12345678911",
                DatumUclanjenja = "22.07.2000"
            });
        }

        public List<Clan> Clanovi { get; set; }
    }
}

  


