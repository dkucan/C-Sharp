using System;
using System.Security.Cryptography.X509Certificates;

namespace zajednickeMetode
{
    public class Metode
    {
        //Ova metoda se može povati na instanci klase

        public void ispis()
        {
            Console.WriteLine("Hello");
        }

        public void ispis(string poruka)
        {
            Console.WriteLine(poruka);
        }

        public void ispis(int poruka)
        {
            Console.WriteLine(poruka);
        }

        // ova metoda se može povati s same klase

        // <summary>
        // MEtoda zbraja dva primljena broja
        // </summary>
        // <param name="a"> prvi primljeni broj</param>
        //<param name="b"> Drugi primljeni broj </param>
        //<returns> zbroj dvaju primljenih brojeva </returns>

        public static int izracunaj(int a, int b)
        {
            return a + b;
        }

        public static void ispisiMatricu(int[,] matrica)
        {
            for (int i = 0; i < matrica.GetLength(0); i++)
            {
                for (int j = 0; j < matrica.GetLength(1); j++)
                {
                    Console.Write(matrica[i, j] + " ");
                }
                Console.WriteLine();
            }

            string s = "";
            for (int i = 0; i < (matrica.GetLength(1) * 2) - 1; i++)
            {
                s += "*";
            }

            Console.WriteLine(s);

            // rekurzija je kada metoda poziva samu sebe uz
            // uvjet prekida rekurzije

            public static int faktorijel(int broj)
            {
                if (broj == 1)
                {
                    return broj;
                }
                return broj * faktorijel(broj - 1);
            }
        }

    }

