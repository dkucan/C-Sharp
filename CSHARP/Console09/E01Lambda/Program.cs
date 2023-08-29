

// napiši metodu tipa int naziva KlasičnaMetoda
// koja prima parametar tipa int 
// i vraća primljeni broj na kvadrat

using E01Lambda;

int KlasičnaMetoda( int b )
{
    return b * b;
}

// U konzolu ispište poziv definirane metode s parametrom 5

Console.WriteLine(KlasičnaMetoda(5));

//lambda expression
var kvadrat = (int b) => b * b;


Console.WriteLine(kvadrat(5));

// lambda statement

var algoritam = (int x, int y) =>
{
    var t = x++ + --y;
    return x + y - t;
};

Console.WriteLine(algoritam(1,2));

int[] brojevi = { 2, 3, 4, 3, 2, 3, 4, 4 };

// prebrojite koliko ima brojeva s vrijednošću 3 u nizu
// 4

int ukupno = 0;
foreach (int k in brojevi)
{
    if (k==3)
    {
        ukupno++;
    }
}
Console.WriteLine(ukupno);
Console.WriteLine(brojevi.Count(b=>b>3));

for (int i = 0; i< brojevi.Length; i++)
{
    Console.WriteLine(brojevi[i]);
}
Console.WriteLine("-----------------------------");

foreach (int k in brojevi)
{
    Console.WriteLine(k);
}
Console.WriteLine("-----------------------------");

Array.ForEach(brojevi, b=>Console.WriteLine(b));

Console.WriteLine("---------------------------");

// ispisati svaki broj uvećan za 1

Array.ForEach(brojevi, b =>
{
    Console.WriteLine(b + 1);
});


//deklarirajte listu sa slijedećim elementima: 2, 3, 4, 5, 4

var lista = new List<int>() { 2, 3, 4, 5, 4 };
lista.ForEach(Console.WriteLine);

var smjerovi = new List<Smjer>()
{
    new () {Naziv = "Prvi", Sifra = 1},
    new () {Naziv = "Drugi", Sifra = 2 }
};

smjerovi.ForEach(Console.WriteLine);

smjerovi.ForEach(s =>
{
    int b = s.Sifra + new Random().Next();
    Console.WriteLine(s.Naziv + " " + b);

});

string s = "Edunova";

Console.WriteLine(s?.Replace("a", "b"));


