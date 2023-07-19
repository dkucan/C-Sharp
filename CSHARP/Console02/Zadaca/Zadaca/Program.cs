// Zadaća
// Za uneseni dvoznamenkasti broj
// ispišite jediničnu vrijednost
// Unos 22, ispis 2
// Unos 88, ispis 8

Console.WriteLine("Unesi jedan dvoznamenkasti prirodan broj: ");
int dvoznamenkastibroj = int.Parse(Console.ReadLine());
int ostatak = dvoznamenkastibroj % 10;
Console.WriteLine("Jedinična vrijednost je: {0}", ostatak);