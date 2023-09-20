using System.Runtime.CompilerServices;

int i = 0;

bool uvjet = i > 0;

if (uvjet)
{
    Console.WriteLine("01: Veće od 0");
}

//koristiti ćemo ovu sintaksu

if (i>0)
{
    Console.WriteLine("O2: opet veće od 0");
}
// jedna od većih grešaka - NE KORISTITI!!!

if (uvjet == true)
{

}

// ako se if odnosi na jednu liniju tada ne trebaju {}

if (!uvjet)
    Console.WriteLine("03: Nije veće od 0");
Console.WriteLine("04: OVo isto ne bi trebalo biti veće od 0");

//koristiti ćemo uvijek {}

//opcionalna sintaksa;
string grad = "Osijek";

if (grad == "Osijek")
{
    if (grad == "Osijek")
    { 
        Console.WriteLine("05: Super");
    }
    else 
    {
        Console.WriteLine("06: OK");
    }

    int b = 0;
    if (grad !="ZAGREB")
    {
        b = b + 1; //broj b se uvećava za 1
    }
    else if (grad == "Split")
    {
        b += 1; //broj b se uvećava za 1
    }
    else if ( grad == "Osijek")
    {
        b += 2; // broj b se uvećava za 2
    }
    else
    {
        b++; // broj b se uvećava za 1
    }
    Console.WriteLine("07: " + b);

    // if možemo ugnijezditi

    i = 0; b = 2;

    if (i > 0)
    {
        if (b == 2)
        {
            Console.WriteLine("08: oba uvjeta su zadovoljena");
        }
    }
   

    // korištenje logičkih operatora
    if (i > 0 && b == 2)
    {
        Console.WriteLine("09: Oba uvjeta su zadovoljena");
    }
    if (i == 4 || b < 0)
    {

    }
    int g = 10;

    if (g % 2 == 0)
    {
        Console.WriteLine("10: Broj je paran");
    }
    else
    {
        Console.WriteLine("11: Broj je neparan");
    }

    //? operator - inline if
    //ovaj red je istovjetan linijama 85-92
    Console.WriteLine("12: Broj je " + (g % 2 == 0 ? "" : "ne") + "paran");


