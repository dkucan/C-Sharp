
Console.Write("Unesite broj: ");
int broj = int.Parse(Console.ReadLine());

//algoritam
broj = broj + 7;

//izlaz
Console.WriteLine(broj);

//Program unosi dva decimalna broja
//Program ispisuje njihov zbroj

Console.WriteLine("Unesi prvi broj (.za decimalni dio): ");
double b1=double.Parse(Console.ReadLine());

Console.WriteLine("Unesi drugi broj (.za decimalni dio): ");
double b2=double.Parse(Console.ReadLine());

double rez = b1 + b2;
Console.WriteLine(rez);