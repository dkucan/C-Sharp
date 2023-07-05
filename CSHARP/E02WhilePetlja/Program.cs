

//while radi s bool tipom podataka

//beskonačna petlja
while(true)
{
    break;
}

//u for se ne mora ući
for(int i = 0; i < 0; i++)
{
    Console.WriteLine("01 Nisam ušao");
}

// u while se ne mora ući

while(false)
{
    Console.WriteLine("02 Nisam ušao");
}


int b = 0;

while (b<10)
{
    Console.WriteLine(++b);
}

int t = 2;
b = 0;
while (t==2 && b<10)
{
    Console.WriteLine(++b);
}
Console.WriteLine("*******************");
b = 0;
while (true)
{
    if (b == 2)
    {
        b++;
        continue;
    }
    if (b == 5) {
        break;
    }
    Console.WriteLine(b++);
}

