using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Ovo je prvi dio rješenja Z01
namespace E01KlasaObjekt
{
    internal class Dokument
    {
        public Dokument() {
            Console.WriteLine("Prazan");
        }

        public Dokument(string ime)
        { Console.WriteLine("puni s {0}, ime"); }
    }
}
