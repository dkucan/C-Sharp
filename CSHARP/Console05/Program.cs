

//1. tipa void, ne prima parametre

// deklaracija metode

using zajednickeMetode; 

void tip1()
{
    Console.WriteLine("Dobrodosli u program");
}

// poziv metode
// tip1();

// 2. tipa void, prima parametre

void Tip2 (string poruka)
{
    Console.WriteLine(poruka);
}

Tip2("Ovo je vrijednost koju proslijeđujem");

string s = "Vrijednost varijable s";

Tip2(s);

// 3. određenog tipa, ne prima vrijednost

int Tip3 ()
{
    return new Random().Next();
}

Tip3(); //on će vratiti slučajni broj ali kod s tim brojem ništa ne radi

Console.WriteLine(Tip3());

int sb = Tip3();

Console.WriteLine(sb);

// Najbitnija 4. određenog tipa i prima parametre

int tip4 (int min, int max)

{
    int manji = min<max ? min : max;
    int veci = max>min ? max : min;
    sb = 3; // vidimo varijablu izvan metode (razina klase)
    //poruka = ""; ne vidimo varijablu iz neke druge metode
    return new Random().Next(manji, veci);
}
