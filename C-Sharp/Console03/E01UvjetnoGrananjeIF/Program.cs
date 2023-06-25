int i = 0;

bool uvjet = i >  0;

if (uvjet) 
{
    Console.WriteLine("Veće od 0"); 
        
        }

//koristit ćemo ovu sintaksu
    if (i > 0)
{
    Console.WriteLine("Opet veće od 0");

}

//jedna od većih grešaka - NE KORISTITI!
if (uvjet == true)
{ {
    }

    //ako se if odnosi na jednu liniju ne trebaju {}
    if (!uvjet)
        Console.WriteLine("Nije veće od 0");
    Console.WriteLine("Ovo isto ne bi trebalo biti veće od 0");


    // koristiti ćemo uvijek vitičaste zagrade {}

    //OPCIONALNA SINTAKSA

    string grad = "Osijek";
    if (grad == "Osijek")
    {
        Console.WriteLine("SUPER");

    }
    else
    {
        Console.WriteLine("OK")
        }
    int b = 0;
    if (grad != "Zagreb")
    {
        b = b + 1;//broj b se uvećava za 1

    } else if (grad == "Split")
    {
        b += 1;//broj se uvećava za 1
    } else if (grad == "Osijek")
    {
        b += 2; //broj b se uvećava za 2
    }
    else
    {
        b++;//broj b se uvećava za 1
    }
    Console.WriteLine(b);

    i = 5; b = 2;

    if (i > 0)

    {
        if (b == 2)
        {
            Console.WriteLine("Oba uvjeta su zadovoljena")
        }
    }

}

i = 0; b = 2;

if (i > 0)
{
    if(b==2)
    { Console.WriteLine("Oba uvjeta su zadovoljena");
    }
}

//korištenje logičkih operatora
if(i > 0 & b==2)
{
    Console.WriteLine("Oba uvjeta su zadovoljena");

}

if(i==4 || b 