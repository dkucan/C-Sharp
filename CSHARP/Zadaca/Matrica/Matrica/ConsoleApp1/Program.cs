

int redaka = 6, stupaca = 6;

Console.Write("Unesi broj redaka: ");
redaka = int.Parse(Console.ReadLine());

Console.Write("Unesi broj stupaca: ");
stupaca = int.Parse(Console.ReadLine());

int[,] matrica = new int[redaka, stupaca];

int b = 1;

for (int i = 1; i <= stupaca; i++)

{
    matrica[redaka - 1, stupaca - i] = b++;
}

// // i = 1 - matrica [5,5]
// // i = 2 - matrica [5,4]
// // i = 3 - matrica [5,3]
// // i = 4 - matrica [5,2]
// // i = 5 - matrica [5,1]
// // i = 6 - matrica [5,0]

for (int i = 0; i < redaka; i++)
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine("***************");

for (int i = redaka - 2; i >=0; i--)
{
    matrica[i, 0] = b++;

    // i = 4 - matrica [4,0]
    // i = 3 - matrica [3,0]
    // i = 2 - matrica [2,0]
    // i = 1 - matrica [1,0]
    // i = 0 - matrica [0,0]
}

for (int i = 0; i < redaka; i++)
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + "");
    }
    Console.WriteLine();
}

Console.WriteLine("*************");
for (int i = 1; i < stupaca; i++)
{
    matrica[0, i] = b++;
}

for (int i = 0; i < redaka; i++)
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] +"");
    }
    Console.WriteLine();
}

Console.WriteLine("*************");
for (int i = 1; i <= redaka - 2; i++)
{
    matrica[i,4] = b++;
}
for (int i = 0; i <redaka; i++)
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("*************");
for (int i = 4; i >=stupaca - 5; i--)
{
    matrica[4,i] = b++;
}

for (int i = 0; i < redaka; i++)
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine("*********");
for (int i = 2; i >= redaka - 4; i--)
{
    matrica[i, 1] = b++;

}

for (int i = 0; i < redaka; i++)
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("*********");
for (int i = 3; i <= stupaca - 3; i++)
{
    matrica[1, i] = b++;

}

for (int i = 0; i < redaka; i++)
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("*********");
for (int i = 3; i >= stupaca - 3; i--)
{
    matrica[2, i] = b++;

}

string ispis;
for (int i = 0; i < redaka; i++)
{
    for (int j = 0; j < stupaca; j++)
    {
        ispis = "  " + matrica[i, j];
        Console.Write(ispis[^3..]);
    }
    Console.WriteLine();
}
