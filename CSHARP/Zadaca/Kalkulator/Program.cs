{

    Console.Write(" Unesi broj: ");
    double num1 = Convert.ToDouble(Console.ReadLine());

    Console.Write("Unesi operator: ");
    string op = Console.ReadLine();

    Console.Write(" Unesi broj: ");
    double num2 = Convert.ToDouble(Console.ReadLine());

    if (op == "+")
    {
        Console.WriteLine(num1 + num2);
    }
    else if (op == "-")
    {
        Console.WriteLine(num1 - num2);
    }
    else if (op == "/")
    {
        Console.WriteLine(num1 / num2);
    }
    else if (op == "*")
    {
        Console.WriteLine(num1 * num2);
    }
    else
    {
        Console.WriteLine("Krivo upotrijebljeni operator");
    }
}
Console.ReadLine();