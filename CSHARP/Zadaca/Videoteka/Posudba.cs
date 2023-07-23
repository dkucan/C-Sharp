using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoteka
{
    internal class Posudba : Entitet
    {
        public string Naslov { get; set; }
        public Kazete Kazete { get; set; }
        public DateTime DatumPosudbe { get; set; }
        public DateTime DatumPovrata { get; set; }
        public List<Clan> Članovi { get; set; }

        public int cijenaPosudbe { get; set; }
        public int cijenaZakasnine { get; set; }    


    }
}
