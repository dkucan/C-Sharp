using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{ 
  public class ObradaClan
{
    public List<clan> Clan { get; }

    public ObradaClan()
    {
        Clan = new List<clan>();
        if (Pomocno.dev)
        {
            TestniPodaci();
        }
    }

    public void PrikaziIzbornik()
    {
        Console.WriteLine("Izbornik za rad s clanovima");
        Console.WriteLine("1. Pregled postojećih clanova");
        Console.WriteLine("2. Unos novog clana");
        Console.WriteLine("3. Promjena postojećeg clana");
        Console.WriteLine("4. Brisanje clana");
        Console.WriteLine("5. Povratak na glavni izbornik");
        switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika clanovi: ",
            "Odabir mora biti 1-5", 1, 5))
        {

            case 1:
                PregledClanova();
                PrikaziIzbornik();
                break;
            case 2:
                UcitajClana();
                PrikaziIzbornik();
                break;
            case 3:
                PromjenaClana();
                PrikaziIzbornik();
                break;
            case 4:
                BrisanjeClana();
                PrikaziIzbornik();
                break;
            case 5:
                Console.WriteLine("Gotov rad s clanovima");
                break;


        }
    }

    private void PromjenaClanova()
    {
        PregledClana();
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj clana: ", "Nije dobar odabir", 1, Clanovi.Count());
        var p = Clanovi[index - 1];
        p.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifru clana (" + p.Sifra + "): ",
            "Unos mora biti pozitivni cijeli broj");
        p.Ime = Pomocno.UcitajString("Unesi ime clana (" + p.Ime + "): ", "Ime obavezno");
        p.Prezime = Pomocno.UcitajString("Unesi Prezime clana (" + p.Prezime + "): ", "Prezime obavezno");
        p.Email = Pomocno.UcitajString("Unesi Email clana (" + p.Email + "): ", "Email obavezno");
        p.Oib = Pomocno.UcitajString("Unesi OIB clana (" + p.Oib + "): ", "OIB obavezno");
    }

    private void BrisanjeClana()
    {
        PregledClanova();
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj clana: ", "Nije dobar odabir", 1, Clanovi.Count());
        Clanovi.RemoveAt(index - 1);
    }

    public void PregledClanova()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("---- Clanovi ----");
        Console.WriteLine("------------------");
        int b = 1;
        foreach (clan clan in Clanovi)
        {
            Console.WriteLine("{0}. {1}", b++, clan);
        }
        Console.WriteLine("------------------");
    }

    private void UcitajClana()
    {
        var p = new clan();
        p.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra clana: ",
            "Unos mora biti pozitivni cijeli broj");
        p.Ime = Pomocno.UcitajString("Unesi ime clana: ", "Ime obavezno");
        p.Prezime = Pomocno.UcitajString("Unesi Prezime clana: ", "Prezime obavezno");
        p.Email = Pomocno.UcitajString("Unesi Email clana: ", "Email obavezno");
        p.Oib = Pomocno.UcitajString("Unesi OIB clana: ", "OIB obavezno");
        Clanovi.Add(p);

    }

    private void TestniPodaci()
    {
        Clanovi.Add(new Clan
        {
            Sifra = 1,
            Ime = "Ana",
            Prezime = "Gal",
            Email = "agal@gmail.com",
            Oib = "33736472822"
        });

        Clanovi.Add(new Clan
        {
            Sifra = 2,
            Ime = "Marija",
            Prezime = "Zimska",
            Email = "mzimska@gmail.com",
            Oib = "33736472821"
        });
    }
}
}