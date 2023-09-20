// Domaća zadaća

// Za unesena dva cijela broj
// program ispisuje veći
// 3 i 5 -> 5
// 5 i 3 -> 5
// 5 i 5 ->


using System.ComponentModel.Design;

Console.WriteLine("Ovaj program uspoređuje dva cijela broja i prikazuje koji je veći");
Console.Write("Unesi prvi cijeli broj: ");
int pbroj = int.Parse(Console.ReadLine());

Console.Write("Unesi drugi cijeli broj: ");
int dbroj = int.Parse(Console.ReadLine());

Console.WriteLine("Veći broj je: " + (pbroj > dbroj ? pbroj : dbroj));

// Za upisana 3 cijela broja program ispisuje najveći

Console.WriteLine("Ovaj program uspoređuje tri cijela broja i prikazuje koji je najveći");
Console.Write("Unesi prvi cijeli broj: ");
int prvibroj = int.Parse(Console.ReadLine());

Console.Write("Unesi drugi cijeli broj: ");
int drugibroj = int.Parse(Console.ReadLine());

Console.Write("Unesi treći cijeli broj: ");
int trecibroj = int.Parse(Console.ReadLine());

if (prvibroj > drugibroj && prvibroj > trecibroj)
{
    Console.WriteLine("Najveći broj je: " + prvibroj);
}
else if (drugibroj > prvibroj && drugibroj > trecibroj)
{
    Console.WriteLine("Najveći broj je: " + drugibroj);
}
else
{
    Console.WriteLine("Najveći broj je: " + trecibroj); 
}

// program unosi broj između 
// 1 i 999
// U slučaju da je izvan tog raspona
// ispisati grešku i prekinuti program
// Program ispisuje 1. znamenku upisanog broja

// -5 greška
// 1067 greška
// 456 4
// 6 6
// 89 8

Console.Write("Unesi prirodan broj između 1 i 999)");
int broj = int.Parse(Console.ReadLine());
if (broj < 1 || broj > 999)
{
    Console.WriteLine("Dogodila se greška. Ispričavamo se no program se prekida!");
}
else if (broj < 10)
{
    Console.WriteLine("PRva znamenka navedenog broja je: " + broj);
}
else if (broj < 100)
{
    Console.WriteLine("Prva znamenka navedenog broja je: " + broj / 10);
}
else
{
    Console.WriteLine("Prva znamenka navedenog broja je: " + broj / 100);
}

// Program unosi 2 broja
// Ako su brojevi parni onda ispisuje njihov zbroj
// ako nisu parni onda ispisuje njihovu razliku

Console.Write("Unesi prvi prirodan broj: ");
int prbroj = int.Parse(Console.ReadLine());

Console.Write("Unesi drugi prirodan broj: ");
int drbroj = int.Parse(Console.ReadLine());

if (prbroj < 0 || drbroj < 0)
{
    Console.WriteLine("Oops! Ovo nije prirodan broj!");
}
else if (prbroj % 2 == 0 && drbroj % 2 == 0)
{
    Console.WriteLine("Zbroj ova dva broja je: " + (prbroj + drbroj));
}
else
{
    Console.WriteLine("Njihova razlika je: " + (prbroj + drbroj));
}
