Console.Write("Kako se zoves?: ");
string ime = Console.ReadLine();
string s;
string t;

for (int i = 0; i < 10; i++)
{
    if (i == 0 | i == 2 | i == 4 | i == 6 | i == 8)
    {
        Console.WriteLine("---------------------------------");
    }
    else if (i == 1)
    {
        Console.WriteLine(": : :  TABLICA  MNOZENJA  : : :");
    }
    else if (i == 3)
    {
        Console.Write(" * |");
        for (int k = 1; k < 10; k++)
        {
            Console.Write("  " + k);
        }
        Console.WriteLine();
    }

    else if (i == 5)
    {

        for (int l = 1; l < 10; l++)
        {
            Console.Write("   " + l + " |");
            for (int m = 1; m < 10; m++)
            {
                s = "   " + l * m;
                Console.Write(s[^3..]);
            }
            Console.WriteLine();
        }
    }

    else if (i == 7)
    {
        t = ":  :  :  : : :  : : : : : : : : : : : : : : :  "  +  "by "  + ime;
        Console.WriteLine(t[^33..]);

    }

}