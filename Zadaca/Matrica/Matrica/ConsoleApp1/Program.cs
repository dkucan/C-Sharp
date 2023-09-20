
Console.Write("Unesi broj redaka: ");
int retci = int.Parse(Console.ReadLine());

Console.Write("Unesi broj stupaca: ");
int stupci = int.Parse(Console.ReadLine());

int[,] matrica = new int[retci, stupci];

int b = 1;
int k = 0;

while (b <= stupci * retci)
{
    for (int i = k; i < stupci - k; i++)
    {
        matrica[k, i] = b++;
    }
    for (int i = k + 1; i <retci-k; i++)
    {
        matrica[i, stupci-k-1] = b++;
    }
    for (int i = stupci - k - 2; i >=k; i--)
    {
        matrica [retci - k -1,i] = b++;
    }
    for (int i = retci - k - 2; i>k; i --)
    {
        matrica[i,k] = b++;
    }
    k++;
}
// Ispis matrice
for (int i = 0; i < retci; i++)
{
    for (int j = 0; j < stupci; j++)
    {
        Console.Write(matrica[i, j] + "\t");
    }
    Console.WriteLine();
}


