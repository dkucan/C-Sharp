
Console.Write("Unesi broj redaka: ");
int retci = int.Parse(Console.ReadLine());

Console.Write("Unesi broj stupaca: ");
int stupci = int.Parse(Console.ReadLine());

int[,] matrica = new int[retci, stupci];


int b = 1;
int k = 0; 


while (b < stupci * retci)
{
    for (int i = k+1; i <= stupci-k; i++)

    {
        matrica[retci - 1, stupci - i] = b++;
        
    }

    // // i = 1 - matrica [5,5]
    // // i = 2 - matrica [5,4]
    // // i = 3 - matrica [5,3]
    // // i = 4 - matrica [5,2]
    // // i = 5 - matrica [5,1]
    // // i = 6 - matrica [5,0]

    for (int i = 0; i < retci-k; i++)
    {
        for (int j = 0; j < stupci; j++)
        {
            Console.Write(matrica[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine("******************************");

    for (int i = retci - k; i >= 0; i--)
    {
        matrica[i, 0] = b++;

        // i = 4 - matrica [4,0]
        // i = 3 - matrica [3,0]
        // i = 2 - matrica [2,0]
        // i = 1 - matrica [1,0]
        // i = 0 - matrica [0,0]
    }

    for (int i = 0; i < retci-k; i++)
    {
        for (int j = 0; j < stupci; j++)
        {
            Console.Write(matrica[i, j] + "");
        }
        Console.WriteLine();
    }

    Console.WriteLine("******************************");
    for (int i = 1; i < stupci-k; i++)
    {
        matrica[0, i] = b++;
       
    }

    for (int i = 0; i < retci-k; i++)
    {
        for (int j = 0; j < stupci; j++)
        {
            Console.Write(matrica[i, j] + "");
        }
        Console.WriteLine();
    }

    Console.WriteLine("******************************");
    for (int i = 1; i <= retci -k; i++)
    {
        matrica[i, stupci - 1] = b++;

    }
    for (int i = 0; i < retci; i++)
    {
        for (int j = 0; j < stupci; j++)
        {
            Console.Write(matrica[i, j] + " ");
        }
        Console.WriteLine();
    }

}

