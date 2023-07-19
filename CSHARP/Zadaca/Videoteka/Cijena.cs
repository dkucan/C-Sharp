using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class Cijena : Entitet
    {
        public string Naziv { get; set; }
        public Film Film{ get; set; }
        public DateTime DatumPosudbe { get; set; }
        public List<Clan> Clanovi { get; set; }
    }
}