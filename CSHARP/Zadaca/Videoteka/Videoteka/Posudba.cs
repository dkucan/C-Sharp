using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class Posudba : Entitet
    {
        public string Naziv { get; set; }

        public Posudba Posudba { get; set; }

        public DateTime DatumPocetka { get; set; }

        public List<clan> Clanovi { get; set; }
    }
}
