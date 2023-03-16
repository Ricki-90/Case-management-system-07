﻿using Real_estate_Nyckelpigan.Services;
using static System.Net.Mime.MediaTypeNames;

var menu = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Skapa ett nytt ärende");
    Console.WriteLine("2. Visa alla aktuella ärenden");
    Console.WriteLine("3. Visa ett specifikt ärende");
    Console.WriteLine("4. Uppdatera status på ett specifikt ärende samt skriv kommentar");
    Console.WriteLine("5. Ta bort ett ärende och hyresgäst kopplat till ärendet");
    Console.WriteLine("6. Avsluta programmet");
    Console.Write("Välj ett av följande alternativ (1-6): ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await MenuService.CreateCaseAsync();
            break;

        case "2":
            Console.Clear();
            await MenuService.ListAllCasesAsync();
            break;

        case "3":
            Console.Clear();
            await MenuService.ListSpecificCaseAsync();
            break;

        case "4":
            Console.Clear();
            await MenuService.UpdateSpecificCaseAsync();
            break;

        case "5":
            Console.Clear();
            await MenuService.DeleteSpecificCaseAsync();
            break;

        case "6":
            Console.Clear();
            Environment.Exit(0);
            break;
    }

    Console.WriteLine("\nTryck på valfri knapp för att försätta...");
    Console.ReadKey();

}
