using System;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Aqui é o menu, o user pode escolher o que fazer e o 
    /// resultado é exposto aqui também.
    /// </summary>
    class Menu
    {
        public void MainMenu()
        {
            Facade facade = new Facade();
            facade.ReadFile();
            ConsoleKeyInfo choice;
            int filterIntMin, filterIntMax;
            double filterDoubleMin, filterDoubleMax;
            string file = "planetList.csv";
            string filterString;
            bool retry, back;
            Console.WriteLine("\nWelcome to the Interstelar sorter." +
                $"\nYou are currently reading {file}." +
                "\nWhat would you like to sort?\n\n\t1 = Planets;" +
                "\n\t2 = Stars;\n\tR = Read another File;\n\tEsc = Exit.");
            do
            {
                // Variável para manter a escolha do utilizador
                choice = Console.ReadKey();
                // Variável para se o utilizador escolhar uma opção inválida
                retry = false;
                // Switch para as variadas opções
                switch (choice.Key)
                {
                    // Caso o utilizador escolha a opção número 1
                    case ConsoleKey.D1:
                        // Variável para se o utilizador escolhar uma opção inválida
                        Console.WriteLine("\nYou have chosen Planets, choose a filter." +
                            "\n\n\t0 - No Filter;" +
                            "\n\t1 - Planet Name;" +
                            "\n\t2 - Planet Host Name;" +
                            "\n\t3 - Planet Discovery Method;" +
                            "\n\t4 - Planet Discovery Year" +
                            "\n\t5 - Planet Orbital Period;" +
                            "\n\t6 - Planet Radius;" +
                            "\n\t7 - Planet Host Radius;" +
                            "\n\t8 - Planet Temperature;" +
                            "\n\t9 - Planet Host Temperature;" +
                            "\n\tA - Planet Mass;" +
                            "\n\tB - Planet Host Mass;" +
                            "\n\tC - Planet Host Age;" +
                            "\n\tD - Planet Host Rotation Velocity;" +
                            "\n\tE - Planet Host Rotation Period;" +
                            "\n\tF - Planet Host Distance to the Sun;" +
                            "\n\tEsc - Back.");
                        System.Threading.Thread.Sleep(2000);
                        do
                        {
                            // Variável para manter a escolha do utilizador
                            choice = Console.ReadKey();
                            // Variável para se o utilizador escolhar uma opção inválida
                            retry = false;
                            back = false;
                            switch (choice.Key)
                            {
                                // Caso o utilizador escolha a opção número 0
                                case ConsoleKey.D0:
                                    Console.Write("\nYou have chosen no filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    // Mostrar planetas
                                    foreach (KeyValuePair<int, Planet> item in Facade.planetList)
                                    {
                                        Console.WriteLine(string.Format($"ID: " +
                                            $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-15}"));
                                    }
                                    MainMenu();
                                    break;
                                // Caso o utilizador escolha a opção número 1
                                case ConsoleKey.D1:
                                    Console.Write("\nYou have chosen Planet Name filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType... (case sensitive)");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem frase para filtrar
                                        filterString = Console.ReadLine();
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetName(
                                                filterString, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetName(
                                                filterString, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 2
                                case ConsoleKey.D2:
                                    Console.Write("\nYou have chosen Planet Host Name filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType... (case sensitive)");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem frase para filtrar
                                        filterString = Console.ReadLine();
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostName(
                                                filterString, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostName(
                                                filterString, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 3
                                case ConsoleKey.D3:
                                    Console.Write("\nYou have chosen Planet Discovery Method filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType... (case sensitive)");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem frase para filtrar
                                        filterString = Console.ReadLine();
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetDiscoveryMethod(
                                                filterString, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetDiscoveryMethod(
                                                filterString, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 4
                                case ConsoleKey.D4:
                                    Console.Write("\nYou have chosen Planet Discovery Year filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterIntMin = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterIntMax = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetDiscoveryYear(
                                                filterIntMin, filterIntMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetDiscoveryYear(
                                                filterIntMin, filterIntMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 5
                                case ConsoleKey.D5:
                                    Console.Write("\nYou have chosen Planet Orbital Period filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterIntMin = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterIntMax = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetOrbitalPeriod(
                                                filterIntMin, filterIntMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetOrbitalPeriod(
                                                filterIntMin, filterIntMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 6
                                case ConsoleKey.D6:
                                    Console.Write("\nYou have chosen Planet Radius filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterDoubleMin = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterDoubleMax = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetRadius(
                                                filterDoubleMin, filterDoubleMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetRadius(
                                                filterDoubleMin, filterDoubleMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 7
                                case ConsoleKey.D7:
                                    Console.Write("\nYou have chosen Planet Host Radius filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterDoubleMin = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterDoubleMax = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostRad(
                                                filterDoubleMin, filterDoubleMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostRad(
                                                filterDoubleMin, filterDoubleMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 8
                                case ConsoleKey.D8:
                                    Console.Write("\nYou have chosen Planet Temperature filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterIntMin = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterIntMax = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetEqt(
                                                filterIntMin, filterIntMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetEqt(
                                                filterIntMin, filterIntMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 9
                                case ConsoleKey.D9:
                                    Console.Write("\nYou have chosen Planet Host Temperature filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterIntMin = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterIntMax = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostTeff(
                                                filterIntMin, filterIntMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostTeff(
                                                filterIntMin, filterIntMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra A
                                case ConsoleKey.A:
                                    Console.Write("\nYou have chosen Planet Mass filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterDoubleMin = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterDoubleMax = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetMass(
                                                filterDoubleMin, filterDoubleMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetMass(
                                                filterDoubleMin, filterDoubleMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra B
                                case ConsoleKey.B:
                                    Console.Write("\nYou have chosen Planet Host Mass filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterDoubleMin = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterDoubleMax = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostMass(
                                                filterDoubleMin, filterDoubleMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostMass(
                                                filterDoubleMin, filterDoubleMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra C
                                case ConsoleKey.C:
                                    Console.Write("\nYou have chosen Planet Host Age filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterIntMin = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterIntMax = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostAge(
                                                filterIntMin, filterIntMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostAge(
                                                filterIntMin, filterIntMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra D
                                case ConsoleKey.D:
                                    Console.Write("\nYou have chosen Planet Host Rotation Velocity filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterDoubleMin = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterDoubleMax = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostVsin(
                                                filterDoubleMin, filterDoubleMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostVsin(
                                                filterDoubleMin, filterDoubleMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra E
                                case ConsoleKey.E:
                                    Console.Write("\nYou have chosen Planet Host Rotation Period filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterIntMin = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterIntMax = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostRotp(
                                                filterIntMin, filterIntMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostRotp(
                                                filterIntMin, filterIntMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra F
                                case ConsoleKey.F:
                                    Console.Write("\nYou have chosen Planet Host Distance to the Sun filter");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.Write(" .");
                                    System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                    System.Threading.Thread.Sleep(500);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem minimo para filtrar
                                        filterDoubleMin = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\nType a maximum range...");
                                        System.Threading.Thread.Sleep(500);
                                        // String que contem máximo para filtrar
                                        filterDoubleMax = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\n\tA - Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(500);
                                        // Variável para manter a escolha do utilizador
                                        choice = Console.ReadKey();
                                        // Variável para se o utilizador escolhar uma opção inválida
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostDist(
                                                filterDoubleMin, filterDoubleMax, true);
                                            MainMenu();
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.Write(" .");
                                            System.Threading.Thread.Sleep(500); Console.WriteLine(" .\n");
                                            System.Threading.Thread.Sleep(500);
                                            facade.SearchByPlanetHostDist(
                                                filterDoubleMin, filterDoubleMax, false);
                                            MainMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção Escape
                                case ConsoleKey.Escape:
                                    back = true;
                                    Console.Write("W");
                                    break;
                            }
                        } while (retry == true || back == false);
                        // Voltar ao menu
                        MainMenu();
                        break;
                    // Caso o utilizador escolha a opção número 2
                    case ConsoleKey.D2:
                        Console.Write("\nYou have chosen Stars, choose a filter");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(" .");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(" .");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(" .\n");
                        System.Threading.Thread.Sleep(1000);
                        // Mostrar estrelas (id, nome e nº de planetas só para testar)
                        foreach (KeyValuePair<int, Star> item in Facade.starList)
                        {
                            Console.WriteLine(string.Format($"ID: " +
                                $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                             $" | Planets: {item.Value.St_PlCount,-2}"));
                        }
                        // Voltar ao menu
                        MainMenu();
                        break;
                    // Caso o utilizador escolha a opção Escape
                    case ConsoleKey.R:
                        Console.WriteLine("\nPlease write the File you want to read\n" +
                            "(exclude extension)\n");
                        file = $"{Console.ReadLine()}.csv";
                        facade.ReadFile(file);
                        retry = true;
                        Console.WriteLine("\n\nWelcome to the Interstelar sorter." +
                            $"\nYou are currently reading {file}." +
                            "\nWhat would you like to sort?\n\n\t1 = Planets;" +
                            "\n\t2 = Stars;\n\tR = Read another File;\n\tEsc = Exit.");
                        break;
                    case ConsoleKey.Escape:
                        Console.Write("\n_Goodbye");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(" .");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(" .");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(" .\n");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    // Caso o utilizador escolha um comando desconhecido
                    default:
                        Console.WriteLine("\nUnknown Command, please try again.");
                        retry = true;
                        break;
                }
            } while (retry == true);
        }
    }
}