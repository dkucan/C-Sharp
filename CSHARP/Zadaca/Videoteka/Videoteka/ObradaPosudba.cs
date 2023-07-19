using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Videoteka

  public class ObradaPosudba
{
    public List<Posudba> Posudbe { get; }

    private Izbornik Izbornik;

    public ObradaPosudba(Izbornik izbornik) : this()
    {
        this.Izbornik = izbornik;
    }

    public ObradaPosudba()
    {
        Posudba = new List<Posudba>();
    }

    public void PrikaziIzbornik()
    {
        Console.WriteLine("Izbornik za rad s posudbama");
        Console.WriteLine("1. Pregled postojećih posudbi");
        Console.WriteLine("2. Unos nove posudbe");
        Console.WriteLine("3. Promjena cijene posudbe");
        Console.WriteLine("5. Povratak na glavni izbornik");
        switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika grupa: ",
            "Odabir mora biti 1-4", 1, 4))
        {
            case 1:
                PrikaziPosudbe();
                PrikaziIzbornik();
                break;
            case 2:
                UnosNovePosudbe();
                PrikaziIzbornik();
                break;
            case 3:
                PromjenaPodataka();
                PrikaziIzbornik();
                break;
            case 4:
                BrisanjePosudbe();
                PrikaziIzbornik();
                break;
            case 5:
                Console.WriteLine("Gotov rad s grupama");
                break;
        }
    }

    private void PromjenaPosudbe()
    {
        PrikaziGrupe();
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Posudba.Count());
        var p = Posudbe[index - 1];
        p.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra posudbe (" + p.Sifra + "): ",
            "Unos mora biti pozitivni cijeli broj");
        p.Naziv = Pomocno.UcitajString("Unesite naziv posudbe (" + p.Naziv + "): ",
            "Unos obavezan");
        Console.WriteLine("Trenutna posudba: {0}", p.Posudba.Naziv);
        p.Posudba = PostaviPosudbu();
        Console.WriteLine("Trenutni clanovi:");
        Console.WriteLine("------------------");
        Console.WriteLine("---- Clanovi ----");
        Console.WriteLine("------------------");
        int b = 1;
        foreach (Clanovi polaznik in p.Clanovi)
        {
            Console.WriteLine("{0}. {1}", b++, clan);
        }
        Console.WriteLine("------------------");
        p.Clanovi = PostaviClanove();
    }

    private Posudba PostaviPosudbu()
    {
        Izbornik.ObradaPosudba.PrikaziSmjerove();
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Izbornik.ObradaPosudba.Posudba.Count());
        return Izbornik.ObradaPosudba.Posudbe[index - 1];
    }

    private void BrisanjePosudbe()
    {
        PrikaziGrupe();
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Posudbe.Count());
        Posudbe.RemoveAt(index - 1);
    }

    private void UnosNovogGrupe()
    {
        var g = new Posudba();
        g.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra grupe: ",
            "Unos mora biti pozitivni cijeli broj");
        g.Naziv = Pomocno.UcitajString("Unesite naziv grupe: ",
            "Unos obavezan");
        g.Posudba = PostaviPosudbu();
        g.Clanovi = PostaviClanove ();
        g.DatumPocetka = Pomocno.ucitajDatum("Unesi datum grupe u formatu dd.MM.yyyy.", "Greška");
        Posube.Add(g);

    }

    private List<clan> PostaviClanove()
    {
        List<Clan> clanovi= new List<clan>();
        while (Pomocno.ucitajBool("Želite li dodati clanove? (da ili bilo što drugo za ne): "))
        {
            clanovi.Add(PostaviClana());
        }

        return clanovi;
    }

    private clan PostaviClana()
    {
        Izbornik.ObradaClan.PregledClanova();
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj clana: ", "Nije dobar odabir", 1, Izbornik.ObradaClan.Clan.Count());
        return Izbornik.ObradaClan.Clanovi[index - 1];
    }

    public void PrikaziPosudbe()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("---- Posudbe ----");
        Console.WriteLine("------------------");
        int b = 1;
        foreach (Posudba posudba in Posudbe)
        {
            Console.WriteLine("{0}. {1}", b++, posudba.Naziv);
        }
        Console.WriteLine("------------------");
    }


}
}
