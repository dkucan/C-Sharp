using System;
    
        Console.WriteLine("Dobrodošli u Ljubavni Kalkulator!");
        Console.Write("Unesite prvo ime: ");
        string ime1 = Console.ReadLine();

        Console.Write("Unesite drugo ime: ");
        string ime2 = Console.ReadLine();

        // Generiranje nasumičnog postotka kompatibilnosti
        Random random = new Random();
        int postotak = random.Next(0, 101);

        Console.WriteLine();
        Console.WriteLine($"Kompatibilnost između {ime1} i {ime2} je: {postotak}%");

        if (postotak > 90)
        {
            Console.WriteLine("Vi ste idealan par!");
        }
        else if (postotak > 70)
        {
            Console.WriteLine("Imate natprosječnu kompatibilnost.");
        }
        else if (postotak > 50)
        {
            Console.WriteLine("Vaša kompatibilnost je OK. Mogla bi biti i bolja ali OK!");
        }
        else
        {
            Console.WriteLine("Ukratko, bolje ne!");
        }
//Ovaj program će vas zamoliti da unesete imena dvije osobe, generirati nasumičan postotak kompatibilnosti između 0% i 100%, te ispisati odgovarajuću poruku na temelju tog postotka. Molim vas imajte na umu da je ovo samo zabavni primjer i nema stvarnu znanstvenu osnovu.





