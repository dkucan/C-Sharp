{
    Console.WriteLine(GetDay(80));


    Console.ReadLine();
}

static string GetDay (int dayNum)
{
    string dayName;

    switch (dayNum)
    {
        case 0:
            dayName = "Nedjelja";
            break;
        case 1:
            dayName = "Ponedjeljak";
            break;
        case 2:
            dayName = "Utorak";
            break;
        case 3:
            dayName = "Srijeda";
            break;
        case 4:
            dayName = "Četvrtak";
            break;
        case 5:
            dayName = "Petak";
            break;
        case 6:
            dayName = "Subota";
            break;
        default:
            dayName = "Krivi broj dana";
            break;
    }

    return dayName;
}