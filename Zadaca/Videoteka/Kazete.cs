using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class Kazete : Entitet
    {
        internal int sifra;

        public int Sifra { get; set; }
        public string Naslov { get; set; }
        public string GodinaIzdanja { get; set; }

        public string Zanr { get; set; }

        public string datumUlaskauInventar { get; set; }

        public int cijenaPosudbe { get; set; }

        public string cijenaZakasnine { get; set; }
    }
}
