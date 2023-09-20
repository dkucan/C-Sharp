
int i = 2;

if ( i==1)
{
    Console.WriteLine("Dobro");
} else if ( i==2)
{
    Console.WriteLine("OK");
} 
else
{
    Console.WriteLine("Ostalo");
}

//višestruko grananje

int ocjena = 3;

switch (ocjena)

{
    case 1:
        Console.WriteLine("nedovoljan");
        break;
        case 2:
        Console.WriteLine("dovoljan");
        break;
        case 3:
        Console.WriteLine("dobar");
        break;  
        case 4:
        Console.WriteLine("vrlo dobar");
        break;
        case 5:
        Console.WriteLine("izvrstan");
        break;
    default:
        Console.WriteLine("Nije ocjena");
        break;
}