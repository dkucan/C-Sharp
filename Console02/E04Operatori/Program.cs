

// operatori uspoređivanja -> bool

bool razlicito = 3 != 4;

bool vece = 8>6;

Console.WriteLine("{0}, {1}", razlicito, vece);


// logicki operatori -> ucimo kod if naredbe

bool rez = razlicito & vece;

// operator + ima dvojaku ulogu

string s = "Edunova" + "Osijek"; //nadolijepiti

int x = 6 + 2; //zbrojiti

string s1 = "Broj" + 5;


//operator modulo ostatak nakon cjelobrojnog djeljenja
// školski primjer je parni i neparni broj

// Za uneseni broj ispiši True ako je parni ili False ako je neparni

Console.Write("Unesi broj: ");
x=Int16.Parse(Console.ReadLine());
Console.WriteLine(x % 2 == 0);
