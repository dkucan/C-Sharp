using System;
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
                    PregledČlanova();
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
            p.DatumUclanjenja = Pomocno.ucitajString("Unesi datum učlanjenja člana", "datum obavezno");
            Članovi.Add(p);
        }

        private void PregledČlanova()
        {
            throw new NotImplementedException();
        }

        private void TestniPodaci()
        {
            throw new NotImplementedException();
        }

        public List<Clan> Clanovi { get; private set; }
    }
}
