using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class Izbornik
    {
        private ObradaKazete ObradaKazete;
        private ObradaClan ObradaClan;

        public Izbornik() 
        {
            ObradaKazete = new ObradaKazete();
            ObradaClan = new ObradaClan();
            PozdravnaPoruka();
            PrikaziIzbornik();
        }
        private void PozdravnaPoruka()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("******* Videoteka App v 1.0 ************");
            Console.WriteLine("****************************************");
        }
        private void PrikaziIzbornik()
        {
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("1. Kazete");
            Console.WriteLine("2. Članovi");
            Console.WriteLine("3. Posudba");
            Console.WriteLine("4. Izlaz iz programa");
            
            switch (Pomocno.ucitajBrojRaspon ("Odaberite stavku izbornika: ", 
                "Odabir mora biti 1-4", 1,4))
            {
                case 1:
                    ObradaKazete.PrikaziIzbornik ();
                    PrikaziIzbornik();
                    break;
                case 2:
                    ObradaClan.PrikaziIzbornik();
                    PrikaziIzbornik ();
                    break;
               case 3:
                    Console.WriteLine("Rad s posudbama");
                    PrikaziIzbornik ();
                    break;
                case 4:
                    Console.WriteLine("Hvala na korištenju, doviđenja");
                        break;

            }
        }
    }
}
