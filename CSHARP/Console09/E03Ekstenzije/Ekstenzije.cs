using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03Ekstenzije
{
    public static class Ekstenzije
    {
        public static int brojPonavljanja(this string s, char z)
        {
            int u = 10;
            // domaća zadaća

            //na danom stringu s prebrojiti koliko ima znakova primljenog kroz parametar z
            // "Anamarija" a vraća 3 

            return u;
        }

        public static void OdradiPosao (this ISucelje sucelje)
        {
            sucelje.Posao();
        }
    }
}
