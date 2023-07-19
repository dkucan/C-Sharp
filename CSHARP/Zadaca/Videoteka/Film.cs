using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class Film : Entitet
    {
        public string Naziv { get; set; }

        public int Trajanje { get; set; }

        public decimal Cijena { get; set; }

    }
}
