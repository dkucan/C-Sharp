// ZADAĆA
//		Kreiraj program koji će koristeći for petlje
//		automatizirati ispis tablice množenja u ovom obliku:
//		-------------------------------
//		: : :  TABLICA  MNOZENJA  : : :
//		-------------------------------
//		 * |  1  2  3  4  5  6  7  8  9
//		-------------------------------
//		 1 |  1  2  3  4  5  6  7  8  9
//		 2 |  2  4  6  8 10 12 14 16 18
//		 3 |  3  6  9 12 15 18 21 24 27
//		 4 |  4  8 12 16 20 24 28 32 36
//		 5 |  5 10 15 20 25 30 35 40 45
//		 6 |  6 12 18 24 30 36 42 48 54
//		 7 |  7 14 21 28 35 42 49 56 63
//		 8 |  8 16 24 32 40 48 56 64 72
//		 9 |  9 18 27 36 45 54 63 72 81 
//		-------------------------------
//		:  :  :  :  :  :   :by Tomislav
//		-------------------------------
//		Umjesto "Ime" treba ispisati ime uneseno s
//		konzole i pri tome pripaziti da zadnje slovo
//		imena bude poravnato s desnim rubom tablice.

//ZAGLAVLJE


internal class Program
{
    private static void Main(string[] args)
    {
        string razdjelnik = "------------------------------";
        string razdjelnik_dvotocka = " : : : : : : : ";
        string zaglavlje = " : : : TABLICA MNOZENJA : : : ";
        string razmak = "  ";
        string umnozak;

        // TABLICA
        Console.WriteLine(razdjelnik);
        Console.WriteLine(zaglavlje);
        Console.WriteLine(razdjelnik);

        for (int i = 0; i < 10; i++)
        {

            if (i == 0)
            {
                Console.Write("*| ");
            }
            else
            {
                Console.Write(i);
                Console.Write(" |");
            }
            for (int j = 1; j < 10; j++)
            {
                if (i == 0)
                {
                    Console.Write(j);
                    Console.Write(razmak[^2..]);
                }
                else
                {
                    umnozak = "   " + i * j;
                    Console.Write(umnozak[^3..]);
                }
            }
            Console.WriteLine();

            if (i == 0)
            {
                Console.WriteLine(razdjelnik);
            }
        }

        //PODNOŽJE

        Console.WriteLine(razdjelnik);
        Console.Write(razdjelnik_dvotocka[^18..]);
        Console.WriteLine(" :by Darko");
        Console.WriteLine(razdjelnik);

        
    }
};