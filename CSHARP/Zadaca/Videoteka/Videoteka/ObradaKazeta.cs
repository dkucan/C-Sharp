using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka

 public class ObradaKazeta
{
    public List<Kazeta> Kazete{ get; }

    public ObradaKazeta()
    {
        Kazete = new List<Kazeta>();
        if (Pomocno.dev)
        {
            TestniPodaci();
        }


    }

    public void PrikaziIzbornik()
    {
        Console.WriteLine("Izbornik za rad s kazetama");
        Console.WriteLine("1. Pregled postojećih kazeta");
        Console.WriteLine("2. Unos nove kazete");
        Console.WriteLine("3. Promjena postojećih podataka o kazeti");
        Console.WriteLine("4. Brisanje kazete");
        Console.WriteLine("5. Povratak na glavni izbornik");
        switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika Kazete: ",
            "Odabir mora biti 1-5", 1, 5))
        {
            case 1:
                PrikaziKazete();
                PrikaziIzbornik();
                break;
            case 2:
                UnosNoveKazete();
                PrikaziIzbornik();
                break;
            case 3:
                PromjenaKazete();
                PrikaziIzbornik();
                break;
            case 4:
                BrisanjeKazete();
                PrikaziIzbornik();
                break;
            case 5:
                Console.WriteLine("Gotov rad s kazetama");
                break;
        }
    }

    private void PromjenaKazete()
    {
        PrikaziSmjerove();
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj smjera: ", "Nije dobar odabir", 1, Kazeta.Count());
        var s = Kazete[index - 1];
        s.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifru kazete (" + s.Sifra + "): ",
            "Unos mora biti pozitivni cijeli broj");
        s.Naziv = Pomocno.UcitajString("Unesite naziv kazete (" + s.Naziv + "): ",
            "Unos obavezan");
        s.Trajanje = Pomocno.ucitajCijeliBroj("Unesite trajanje kazete u satima (" + s.Trajanje + "): ",
            "Unos mora biti cijeli pozitivni broj");
        s.Cijena = Pomocno.ucitajDecimalniBroj("Unesite cijenu (. za decimalni dio) (" + s.Cijena + "): ", "Unos mora biti pozitivan broj");
    }

    private void BrisanjeKazete()
    {
        PrikaziSmjerove();
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj smjera: ", "Nije dobar odabir", 1, Kazeta.Count());
        Kazeta.RemoveAt(index - 1);
    }

    private void UnosNovogSmjera()
    {
        var s = new Kazeta();
        s.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra kazete: ",
            "Unos mora biti pozitivni cijeli broj");
        s.Naziv = Pomocno.UcitajString("Unesite naziv kazete: ",
            "Unos obavezan");
        s.Trajanje = Pomocno.ucitajCijeliBroj("Unesite trajanje kazete u satima: ",
            "Unos mora biti cijeli pozitivni broj");
        s.Cijena = Pomocno.ucitajDecimalniBroj("Unesite cijenu (. za decimalni dio): ", "Unos mora biti pozitivan broj");
        Kazeta.Add(s);

    }

    public void PrikaziKazete()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("---- Kazete ----");
        Console.WriteLine("------------------");
        int b = 1;
        foreach (Kazeta Kazeta in Kazete)
        {
            Console.WriteLine("{0}. {1}", b++, Kazeta.Naziv);
        }
        Console.WriteLine("------------------");
    }

    private void TestniPodaci()
    {
        Kazeta.Add(new Kazeta
        {
            Sifra = 1,
            Naziv = "Web programiranje",
            Trajanje = 250,
            Cijena = 1000,
        });

        Kazeta.Add(new Kazeta
        {
            Sifra = 2,
            Naziv = "Java programiranje",
            Trajanje = 130,
            Cijena = 1000,
        });
    }
}
}
