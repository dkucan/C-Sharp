{
    string secretword = "Slon";
    string guess = "";
    int guessCount = 0;
    int GuessLimit = 3;
    bool nomoreguesses = false;

    while (guess!= secretword && !nomoreguesses)
    {
        if (guessCount < GuessLimit)
        {
            Console.Write("Pogodi riječ: ");
            guess = Console.ReadLine();
            guessCount++;
        }
        else
        {
            nomoreguesses = true;
        }
        if (nomoreguesses)
        {
            Console.Write("Nažalost, niste uspjeli pogoditi tajnu riječ!");
        }
        else
        {
            Console.Write("Čestitam! Uspješno ste pronašli tajnu riječ!");
        }
    }
}
