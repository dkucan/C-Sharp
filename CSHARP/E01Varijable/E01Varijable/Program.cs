int i;
i = 4;
Console.WriteLine(i);

string nizznakova = "Edunova";

bool logickaVrijednost=true;
Console.WriteLine(logickaVrijednost);
float decimalniBrojVeci = 3.14f;
double decimalniBroj = 3.14;
decimal db = 3.14m;

Console.WriteLine("decimalni broj: {0}\ndb: {1}", 
    decimalniBroj, db);

Console.WriteLine(int.MinValue);
Console.WriteLine(int.MaxValue);

int b = int.MaxValue;
b = b + 1;

Console.WriteLine(b);


// Zadatak 1

//Deklarirajte 4 varijable različitih tipova podataka
//Svakom od njih dodijeliti vrijednosti po želji
//Sve ih odjednom ispišite jedno pored drugog

int t = 1; bool bo = false; string s = "Osijek"; char c = 'A';
Console.WriteLine("{0},{1},{2},{3}", t, bo, s, c);
Console.WriteLine("{0},{1},{2},{3}", t, bo,s, decimalniBrojVeci);
