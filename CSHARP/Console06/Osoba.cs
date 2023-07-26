namespace E01KlasaObjekt
{
    // Klasa je opisnik objekta
    internal class Osoba
    {
        //ovako se ne smiju deklarirati svojstva u klasi
        // zato što nije zadovoljen OOP princip učahurivanja
        /* 
         public string ime;
        internal string ime;
        int godine;
        */

        // zadnja vrsta metoda: konstruktor
        // poziva se u trenutku instanciranja novog objekta (ključna riječ new)
        // ona nije obavezna. Ako nije definirana poziva se konstruktor iz nadklase (nasljeđivanje)
        // Naziv konstuktora mora biti identičan  nazivu klase

        public Osoba()
        {
            Console.WriteLine("Konstruktor klase Osoba");
        }

        public Osoba (string ime)
        {
            Console.WriteLine(ime);
        }
    }
}
