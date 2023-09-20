{
    string tajnarijec = "slon"; 
    string pogodi = "";
    int brojpokusaja = 0;
    int limitpokusaja = 3;
    bool nemavisepokusaja = false;

    while (pogodi != tajnarijec && !nemavisepokusaja)
    {
        if (brojpokusaja < limitpokusaja)
        {
            Console.Write("Pogodi riječ: ");
            pogodi = Console.ReadLine();
            brojpokusaja++;
        }
        else
        {
            nemavisepokusaja = true;
        }
    }
    {
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
