using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka

{
    public ObradaKazeta ObradaKazeta { get; }
    public ObradaClan ObradaClan { get; }

    private ObradaPosudba ObradaPosudba;

    public Izbornik()
    {
        ObradaKazeta = new ObradaKazeta();
        ObradaClan = new ObradaClan();
        ObradaPosudba = new ObradaPosudba(this);
        PozdravnaPoruka();
        PrikaziIzbornik();
    }

    private void PozdravnaPoruka()
    {
        Console.WriteLine("*************************************");
        Console.WriteLine("***** Videoteka Console APP v 1.0 *****");
        Console.WriteLine("*************************************");
    }

    private void PrikaziIzbornik()
    {
        Console.WriteLine("Glavni izbornik");
        Console.WriteLine("1. Kazete");
        Console.WriteLine("2. Clanovi");
        Console.WriteLine("3. Posudbe");
        Console.WriteLine("4. Izlaz iz programa");

        switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika: ",
            "Odabir mora biti 1 - 4.", 1, 4))
        {
            case 1:
                ObradaKazeta.PrikaziIzbornik();
                PrikaziIzbornik();
                break;
            case 2:
                ObradaClan.PrikaziIzbornik();
                PrikaziIzbornik();
                break;
            case 3:
                ObradaPosudba.PrikaziIzbornik();
                PrikaziIzbornik();
                break;
            case 4:
                Console.WriteLine("Hvala na korištenju, doviđenja");
                break;

        }


    }

}