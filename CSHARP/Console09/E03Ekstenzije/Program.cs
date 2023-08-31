

using E03Ekstenzije;
using System.Windows.Markup;

Console.Write("Upiši ime: ");
string ime = Console.ReadLine() ?? "";

Console.WriteLine(ime?.brojPonavljanja('a'));

var s = new Smjer();

s.OdradiPosao();

Grupa g = new();
g.OdradiPosao();

