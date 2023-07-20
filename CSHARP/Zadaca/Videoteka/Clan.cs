using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class Clan : Entitet
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string OIB { get; set; }

        public string Adresa { get; set; }

        public string Telefon { get; set; }

        public string DatumUclanjenja { get; set; }

    }
}
