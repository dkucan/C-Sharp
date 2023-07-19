{
    string tajnarijec = "Slon";
    string pogodi ="";
    int pogodiCount = 0;
    int pogodiLimit = 3;
    bool nemavisepokusaja = false;

    while (pogodi != tajnarijec && !nemavisepokusaja)
    {
        if (pogodiCount < pogodiLimit)
        {
            Console.Write("Unesi riječ: ");
            pogodi = Console.ReadLine();
            pogodiCount++;
        }
        else
        {
            nemavisepokusaja = true;
        }
        if (nemavisepokusaja)
        {
            Console.Write("Nažalost, niste uspjeli pogoditi tajnu riječ!");
        }
        else
        {
            Console.Write("Čestitam! Uspješno ste pronašli tajnu riječ!");
        }
    }
}
