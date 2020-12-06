using System;

namespace projeto1LP2
{
    /// <summary>
    /// Aqui é o menu, o user pode escolher o que fazer e o 
    /// resultado é exposto aqui também.
    /// </summary>
    class Menu
    {
        /// <summary>
        /// Método do menu principal.
        /// </summary>
        public void MainMenu(string file)
        {
            Facade facade = new Facade();
            ConsoleKeyInfo choice;
            int filterIntMin, filterIntMax;
            double filterDoubleMin, filterDoubleMax;
            string filterString;
            bool retry;
            if (file == null)
            {
                do
                {
                    Console.WriteLine("\nWelcome to the Interstelar sorter." +
                    "\nPlease choose a file to read by typing the " +
                    "name of the file.");
                    file = Console.ReadLine();
                    if (!file.EndsWith(".csv"))
                        file += ".csv";
                    if (facade.TryRead(file) == true)
                    {
                        facade.ReadFile(file);
                        retry = false;
                    }
                    else
                    {
                        Console.WriteLine("\nPlease try again.\n");
                        retry = true;
                    }
                } while (retry == true);
            }
            else
            {
                facade.ReadFile(file);
            }
            Console.WriteLine($"\nYou are currently reading {file}." +
                "\nWhat would you like to sort?\n\n\t1 = Planets;" +
                "\n\t2 = Stars;\n\tR = Read another File;\n\tEsc = Exit.");
            do
            {
                // Variável para manter a escolha do utilizador.
                choice = Console.ReadKey();
                // Variável para se o utilizador escolhar uma opção inválida.
                retry = false;
                // Switch para as variadas opções.
                switch (choice.Key)
                {
                    // Caso o utilizador escolha a opção número 1.
                    case ConsoleKey.D1:
                        Console.WriteLine("\nYou have chosen Planets, choose" +
                            " a filter." +
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
                            "\n\tF - Planet Host Distance to the Sun;");
                        System.Threading.Thread.Sleep(1000);
                        do
                        {
                            // Variável para manter a escolha do utilizador.
                            choice = Console.ReadKey();
                            /* Variável para se o utilizador escolhar uma 
                             * opção inválida. */
                            retry = false;
                            switch (choice.Key)
                            {
                                // Caso o utilizador escolha a opção número 0.
                                case ConsoleKey.D0:
                                    Console.WriteLine("\nYou have chosen no" +
                                        " filter");
                                    System.Threading.Thread.Sleep(1000);
                                    // Mostrar planetas
                                    facade.PrintInfo(Facade.planetList);
                                    MainMenu(file);
                                    break;
                                // Caso o utilizador escolha a opção número 1
                                case ConsoleKey.D1:
                                    Console.Write("\nYou have chosen Planet " +
                                        "Name filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType... (case " +
                                            "sensitive)");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contêm frase para
                                         * filtrar. */
                                        filterString = Console.ReadLine();
                                        Console.WriteLine("\n\tA - Ascendant" +
                                            ";\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetName(
                                                filterString, true, facade.
                                                OrderByPlanets(choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetName(
                                                filterString, false, facade.
                                                OrderByPlanets(choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown" +
                                                " Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 2.
                                case ConsoleKey.D2:
                                    Console.Write("\nYou have chosen Planet" +
                                        " Host Name filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType..." +
                                            " (case sensitive)");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem frase para
                                         * filtrar. */
                                        filterString = Console.ReadLine();
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostName(
                                                filterString, true, facade.
                                                OrderByPlanets(choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostName(
                                                filterString, false, facade.
                                                OrderByPlanets(choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown" +
                                                " Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 3.
                                case ConsoleKey.D3:
                                    Console.Write("\nYou have chosen Planet " +
                                        "Discovery Method filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType..." +
                                            " (case sensitive)");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem frase para 
                                         * filtrar. */
                                        filterString = Console.ReadLine();
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.
                                                SearchByPlanetDiscoveryMethod
                                                (filterString, true, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.
                                                SearchByPlanetDiscoveryMethod
                                                (filterString, false, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown" +
                                                " Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 4.
                                case ConsoleKey.D4:
                                    Console.Write("\nYou have chosen Planet" +
                                        " Discovery Year filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a" +
                                            " minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para 
                                         * filtrar. */
                                        filterIntMin = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a maximum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para
                                         * filtrar. */
                                        filterIntMax = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA -" +
                                            " Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha 
                                         * do utilizador */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetDiscoveryYear(
                                                filterIntMin, filterIntMax, 
                                                true, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetDiscoveryYear(
                                                filterIntMin, filterIntMax,
                                                false, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 5.
                                case ConsoleKey.D5:
                                    Console.Write("\nYou have chosen Planet" +
                                        " Orbital Period filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a " +
                                            "minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterIntMin = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a maximum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para 
                                         * filtrar. */
                                        filterIntMax = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do 
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetOrbitalPeriod(
                                                filterIntMin, filterIntMax, 
                                                true, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetOrbitalPeriod(
                                                filterIntMin, filterIntMax, 
                                                false, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown" +
                                                " Command," +
                                                " please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 6.
                                case ConsoleKey.D6:
                                    Console.Write("\nYou have chosen" +
                                        " Planet Radius filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a" +
                                            " minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a" +
                                            " maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do 
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetRadius(
                                                filterDoubleMin,
                                                filterDoubleMax, true,
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetRadius(
                                                filterDoubleMin, 
                                                filterDoubleMax, false, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 7.
                                case ConsoleKey.D7:
                                    Console.Write("\nYou have chosen Planet" +
                                        " Host Radius filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a" +
                                            " minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a" +
                                            " maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostRad(
                                                filterDoubleMin, 
                                                filterDoubleMax, true, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostRad(
                                                filterDoubleMin, 
                                                filterDoubleMax, false, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 8.
                                case ConsoleKey.D8:
                                    Console.Write("\nYou have chosen" +
                                        " Planet Temperature filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a" +
                                            " minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para 
                                         * filtrar. */
                                        filterIntMin = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a " +
                                            "maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo 
                                         * para filtrar. */
                                        filterIntMax = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA -" +
                                            " Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do 
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetEqt(
                                                filterIntMin, filterIntMax, 
                                                true, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetEqt(
                                                filterIntMin, filterIntMax,
                                                false, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 9.
                                case ConsoleKey.D9:
                                    Console.Write("\nYou have chosen Planet" +
                                        " Host Temperature filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterIntMin = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a maximum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para
                                         * filtrar. */
                                        filterIntMax = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA -" +
                                            " Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha 
                                         * do utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador
                                        escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostTeff(
                                                filterIntMin, filterIntMax,
                                                true, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostTeff(
                                                filterIntMin, filterIntMax,
                                                false, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown" +
                                                " Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra A.
                                case ConsoleKey.A:
                                    Console.Write("\nYou have chosen Planet" +
                                        " Mass filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a " +
                                            "minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a maximum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetMass(
                                                filterDoubleMin, 
                                                filterDoubleMax, true, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetMass(
                                                filterDoubleMin, 
                                                filterDoubleMax, false, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown" +
                                                " Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra B.
                                case ConsoleKey.B:
                                    Console.Write("\nYou have chosen Planet" +
                                        " Host Mass filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a" +
                                            " minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a" +
                                            " maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostMass(
                                                filterDoubleMin, 
                                                filterDoubleMax, true, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostMass(
                                                filterDoubleMin,
                                                filterDoubleMax, false,
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown" +
                                                " Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra C.
                                case ConsoleKey.C:
                                    Console.Write("\nYou have chosen Planet" +
                                        " Host Age filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a" +
                                            " minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para 
                                         * filtrar. */
                                        filterIntMin = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a " +
                                            "maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para 
                                         * filtrar. */
                                        filterIntMax = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a 
                                         * escolha do utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostAge(
                                                filterIntMin, filterIntMax,
                                                true, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostAge(
                                                filterIntMin, filterIntMax, 
                                                false, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra D.
                                case ConsoleKey.D:
                                    Console.Write("\nYou have chosen Planet" +
                                        " Host Rotation Velocity filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a" +
                                            " minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /*String que contem minimo para 
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a maximum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para 
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA -" +
                                            " Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostVsin(
                                                filterDoubleMin, 
                                                filterDoubleMax, true, 
                                                facade.OrderByPlanets(choice, 
                                                retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostVsin(
                                                filterDoubleMin, 
                                                filterDoubleMax, false, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown" +
                                                " Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra E.
                                case ConsoleKey.E:
                                    Console.Write("\nYou have chosen" +
                                        " Planet Host Rotation Period filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterIntMin = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a " +
                                            "maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para
                                         * filtrar. */
                                        filterIntMax = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha
                                         * do utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostRotp(
                                                filterIntMin, filterIntMax,
                                                true, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostRotp(
                                                filterIntMin, filterIntMax, 
                                                false, facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra F.
                                case ConsoleKey.F:
                                    Console.Write("\nYou have chosen Planet" +
                                        " Host Distance to the Sun filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a" +
                                            " minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a " +
                                            "maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para 
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostDist(
                                                filterDoubleMin, 
                                                filterDoubleMax, true, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlanetHostDist(
                                                filterDoubleMin, 
                                                filterDoubleMax, false, 
                                                facade.OrderByPlanets
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                default:
                                    Console.WriteLine("Unknown command," +
                                        " try again.");
                                    retry = true;
                                    break;
                            }
                        } while (retry == true);
                        // Voltar ao menu.
                        MainMenu(file);
                        break;
                    // Caso o utilizador escolha a opção número 2.
                    case ConsoleKey.D2:
                        Console.WriteLine("\nYou have chosen Planets," +
                            " choose a filter." +
                            "\n\n\t0 - No Filter;" +
                            "\n\t1 - Star Name;" +
                            "\n\t2 - Discovery Method;" +
                            "\n\t3 - Discovery Year" +
                            "\n\t4 - Radius;" +
                            "\n\t5 - Temperature;" +
                            "\n\t6 - Mass;" +
                            "\n\t7 - Age;" +
                            "\n\t8 - Rotation Velocity;" +
                            "\n\t9 - Rotation Period;" +
                            "\n\tA - Distance to the Sun;" +
                            "\n\tB - Number of Planets;");
                        System.Threading.Thread.Sleep(1000);
                        do
                        {
                            // Variável para manter a escolha do utilizador.
                            choice = Console.ReadKey();
                            /* Variável para se o utilizador escolhar uma
                             * opção inválida. */
                            retry = false;
                            switch (choice.Key)
                            {
                                /* Caso o utilizador escolha a opção
                                número 0. */
                                case ConsoleKey.D0:
                                    Console.WriteLine("\nYou have chosen " +
                                        "no filter");
                                    System.Threading.Thread.Sleep(1000);
                                    // Mostrar estrelas
                                    facade.PrintInfo(Facade.starList);
                                    MainMenu(file);
                                    break;
                                // Caso o utilizador escolha a opção número 1.
                                case ConsoleKey.D1:
                                    Console.Write("\nYou have chosen Star" +
                                        " Name filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType... " +
                                            "(case sensitive)");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem frase para
                                         * filtrar. */
                                        filterString = Console.ReadLine();
                                        Console.WriteLine("\n\tA -" +
                                            " Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a 
                                         * escolha do utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarName(
                                                filterString, true, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarName(
                                                filterString, false, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 2.
                                case ConsoleKey.D2:
                                    Console.Write("\nYou have chosen " +
                                        "Discovery Method filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType..." +
                                            " (case sensitive)");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem frase para 
                                         * filtrar. */
                                        filterString = Console.ReadLine();
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha
                                         * do utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarDiscoveryMethod(
                                                filterString, true, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarDiscoveryMethod(
                                                filterString, false, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown" +
                                                " Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 3.
                                case ConsoleKey.D3:
                                    Console.Write("\nYou have chosen" +
                                        " Discovery Year filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para 
                                         * filtrar. */
                                        filterIntMin = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a " +
                                            "maximum range...");
                                        System.Threading.Thread.Sleep
                                            (1000);
                                        /* String que contem máximo
                                         * para filtrar. */
                                        filterIntMax = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a
                                         * escolha do utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarDiscoveryYear(
                                                filterIntMin, filterIntMax, 
                                                true, facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarDiscoveryYear(
                                                filterIntMin, filterIntMax, 
                                                false, facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 4.
                                case ConsoleKey.D4:
                                    Console.Write("\nYou have chosen" +
                                        " Radius filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a " +
                                            "minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a maximum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA -" +
                                            " Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha
                                         * do utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen" +
                                                " Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarRad(
                                                filterDoubleMin, 
                                                filterDoubleMax, true, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarRad(
                                                filterDoubleMin, 
                                                filterDoubleMax, false, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 5.
                                case ConsoleKey.D5:
                                    Console.Write("\nYou have chosen " +
                                        "Temperature filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para 
                                         * filtrar. */
                                        filterIntMin = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a maximum " +
                                            "range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para
                                         * filtrar. */
                                        filterIntMax = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a
                                        escolha do utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarTeff(
                                                filterIntMin, filterIntMax, 
                                                true, facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarTeff(
                                                filterIntMin, filterIntMax,
                                                false, facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 6.
                                case ConsoleKey.D6:
                                    Console.Write("\nYou have chosen " +
                                        "Mass filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a " +
                                            "minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para 
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a maximum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarMass(
                                                filterDoubleMin, 
                                                filterDoubleMax, true, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarMass(
                                                filterDoubleMin, 
                                                filterDoubleMax, false, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 7.
                                case ConsoleKey.D7:
                                    Console.Write("\nYou have chosen Age " +
                                        "filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum " +
                                            "range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterIntMin = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a " +
                                            "maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para 
                                         * filtrar. */
                                        filterIntMax = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha
                                         * do utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarAge(
                                                filterIntMin, filterIntMax, 
                                                true, facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep(
                                                1000);
                                            facade.SearchByStarAge(
                                                filterIntMin, filterIntMax, 
                                                false, facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 8.
                                case ConsoleKey.D8:
                                    Console.Write("\nYou have chosen" +
                                        " Rotation Velocity filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a " +
                                            "minimum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para 
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a " +
                                            "maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para 
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarVsin(
                                                filterDoubleMin, 
                                                filterDoubleMax, true, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarVsin(
                                                filterDoubleMin,
                                                filterDoubleMax, false, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção número 9.
                                case ConsoleKey.D9:
                                    Console.Write("\nYou have chosen " +
                                        "Rotation Period filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para 
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a maximum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para 
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarRtop(
                                                filterDoubleMin, 
                                                filterDoubleMax, true, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarRtop(
                                                filterDoubleMin, 
                                                filterDoubleMax, false, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra A.
                                case ConsoleKey.A:
                                    Console.Write("\nYou have chosen" +
                                        " Distance to the Sun filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum" +
                                            " range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para 
                                         * filtrar. */
                                        filterDoubleMin = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a" +
                                            " maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para 
                                         * filtrar. */
                                        filterDoubleMax = Convert.ToDouble
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarDist(
                                                filterDoubleMin, 
                                                filterDoubleMax, true, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByStarDist(
                                                filterDoubleMin, 
                                                filterDoubleMax, false, 
                                                facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine
                                                ("\nUnknown Command, please " +
                                                "try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                // Caso o utilizador escolha a opção letra B.
                                case ConsoleKey.B:
                                    Console.Write("\nYou have chosen" +
                                        " Age filter");
                                    System.Threading.Thread.Sleep(1000);
                                    do
                                    {
                                        Console.WriteLine("\nType a minimum " +
                                            "range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem minimo para
                                         * filtrar. */
                                        filterIntMin = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\nType a" +
                                            " maximum range...");
                                        System.Threading.Thread.Sleep(1000);
                                        /* String que contem máximo para 
                                         * filtrar. */
                                        filterIntMax = Convert.ToInt32
                                            (Console.ReadLine());
                                        Console.WriteLine("\n\tA - " +
                                            "Ascendant;\n\tD - Descendant.");
                                        System.Threading.Thread.Sleep(1000);
                                        /* Variável para manter a escolha do
                                         * utilizador. */
                                        choice = Console.ReadKey();
                                        /* Variável para se o utilizador 
                                         * escolhar uma opção inválida. */
                                        retry = false;
                                        if (choice.Key == ConsoleKey.A)
                                        {
                                            Console.Write("\nChosen " +
                                                "Ascendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlCount(
                                                filterIntMin, filterIntMax,
                                                true, facade.OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else if (choice.Key == ConsoleKey.D)
                                        {
                                            Console.Write("\nChosen " +
                                                "Descendent filter, stand by");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            facade.SearchByPlCount(
                                                filterIntMin, filterIntMax, 
                                                false, facade.
                                                OrderByStars
                                                (choice, retry));
                                            MainMenu(file);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nUnknown " +
                                                "Command, please try again.");
                                            System.Threading.Thread.Sleep
                                                (1000);
                                            retry = true;
                                        }
                                    } while (retry == true);
                                    break;
                                /* Caso o utilizador escolha um comando
                                 * desconhecido. */
                                default:
                                    Console.WriteLine("\nUnknown " +
                                        "Command, try again.");
                                    retry = true;
                                    break;
                            }
                        } while (retry == true);
                        // Voltar ao menu.
                        MainMenu(file);
                        break;
                    // Caso o utilizador escolha a opção letra R.
                    case ConsoleKey.R:
                        do
                        {
                            Console.WriteLine("\nPlease write the File you " +
                                "want to read.\n");
                            file = Console.ReadLine();
                            if (!file.EndsWith(".csv"))
                                file += ".csv";
                            if (facade.TryRead(file) == true)
                            {
                                facade.ReadFile(file);
                                retry = false;
                            }
                            else
                            {
                                Console.WriteLine("\nPlease try again.\n");
                                retry = true;
                            }
                        } while (retry == true);
                        MainMenu(file);
                        break;
                    // Caso o utilizador escolha a opção Escape.
                    case ConsoleKey.Escape:
                        Console.Write("\n_Goodbye...");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    // Caso o utilizador escolha um comando desconhecido.
                    default:
                        Console.WriteLine("\nUnknown Command, try again.");
                        retry = true;
                        break;
                }
            } while (retry == true);
        }
    }
}