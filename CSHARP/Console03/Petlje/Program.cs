//10 puta ispiši OSijek
//najgore rješenje

//Console.WriteLine("Osijek");
//Console.WriteLine("Osijek");
//Console.WriteLine("Osijek");
//Console.WriteLine("Osijek");
//Console.WriteLine("Osijek");
//Console.WriteLine("Osijek");
//Console.WriteLine("Osijek");
//Console.WriteLine("Osijek");
//Console.WriteLine("Osijek");
//Console.WriteLine("Osijek");
//Console.WriteLine("Osijek");

// for (od kuda; do kuda; korak)

Console.WriteLine("1. ***********");

for (int i = 0; i < 10; i = i + 1) ;

{
    Console.WriteLine("Zagreb");
}

Console.WriteLine("2.**********");
int j = 0;
for (j = 10; j > 0; j--);
{
    Console.WriteLine("cevapi s lukom");
}

Console.WriteLine("3**********");
for (int i=0; i < 18; i=i+2)
{
    Console.WriteLine("CSHARP");

}

//varijabla u petlji mijenja vrijednosti!!!

//Console.WriteLine("4. **********");
//for(int i=0; i < 10; i=i++)
//{
//    Console.WriteLine(i);
//}
//Console.WriteLine("5.**********");
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(i + 1);// i+1 ne mijenja vrijednost varijable i
//}

Console.WriteLine("6.***********");
//ne koristiti 
for(int i=1; i<=10;  i++)
{
    Console.WriteLine(i);
}
Console.WriteLine("7.**********");
//zbroj prvih 100 brojeva
int zbroj = 0;
for (int i = 1; i <= 100; i++)
{
    Console.WriteLine(i);
    zbroj += i; //zbroj=zbroj+i
    //Console.WriteLine(zbroj);
}
Console.WriteLine(zbroj);

Console.WriteLine("8.**********");
//ispisati sve parne brojeve od 1 do 57
for (int i=1; i<=57; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }

}

Console.WriteLine("9.**********");
//ispiši zbroj svih parnih brojeva 2 do 18
zbroj= 0; ;
for (int i=2; i<=18;  i++)
{
    if(i % 2 == 0)
    {
        zbroj += i; 
    }
}
Console.WriteLine(zbroj);
int[] niz= {2,2,34,54,5,6,76,7,8,7,8};

Console.WriteLine("10.**********");
//jedno ispod drugog ispisati svaki element niza
for(int i=0; i < niz.Length; i++)
{
    Console.WriteLine(niz[i]);
}

// Program učitava koliko će se brojeva unijeti
// Program učitava brojeve za provjeru
// Program ispisuje najveći uneseni broj

Console.WriteLine("11. *****************");
Console.Write("Unesi koliko brojeva provjeravaš: ");
int brojeva = int.Parse(Console.ReadLine());
int broj; //unutar petlje nikada ne deklarirati varijablu, uvije izvan petlje
int najveci = int.MinValue;
for (int i = 0; i < brojeva; i++)
{
    Console.Write("Unesi {0}. broj: ", i + 1);
    broj = int.Parse(Console.ReadLine());
    if (broj > najveci)
    {
        najveci = broj;
    }
}
Console.WriteLine("Najveći broj je {0}", najveci);
