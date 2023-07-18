using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class Kazeta : Entitet

    { 
        public string Naziv { get; set; }
        public int Trjanje { get; set; }
        public decimal cijena { get; set; }

        public decimal Upisnina { get; set; }
    }
}
