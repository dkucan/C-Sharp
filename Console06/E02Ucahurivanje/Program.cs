
using E02Ucahurivanje;

Osoba osoba = new Osoba();
osoba.setIme("Pero");
osoba.Prezime = "Perić"; //Ovako ćemo u nastavku koristiti

Console.WriteLine("{0}, {1} ", osoba.Prezime, osoba.getIme());

Smjer smjer = new Smjer();
smjer.sifra = 1;
smjer.Naziv = "Web programiranje";
smjer.Trajanje = 250;
//.. ostala svojstva

// brža sintaksa

smjer = new Smjer
{
    sifra = 1,
    Naziv = "Java programiranje",
    // i ostale vrijednosti
};

Zupanija zupanija = new Zupanija
{
    Naziv = "Osječko-baranjska",
    Zupan = "Anusic"
};

Grad grad = new Grad()
{
    Naziv = "Osijek",
    zupanija = zupanija
};

//ispis svojstava kada jedna klasa sadrži instancu druge klase

Console.WriteLine("Grad je {0}, Županija je {1}", grad.Naziv, grad.zupanija.Naziv);


