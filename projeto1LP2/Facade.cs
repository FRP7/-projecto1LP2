using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace projeto1LP2
{
    /// <summary>
    /// Classe "Facade" onde se pode aceder ao conteúdo das outras classes.
    /// É a classe "mãe" ou núcleo do programa. É tudo guardado aqui,
    /// incluído o conteúdo do ficheiro.
    /// Sempre que for necessário aceder a alguma classe, acedemos por aqui.
    /// </summary>
    class Facade
    {
        // Dictionary de planetas.
        public static Dictionary<int, Planet> planetList;
        // Dictionary de estrelas.
        public static Dictionary<int, Star> starList;

        // Inicializar variáveis.
        public Facade()
        {
            // Inicializar os dictionaries.
            planetList = new Dictionary<int, Planet>();
            starList = new Dictionary<int, Star>();
        }

        /// <summary>
        /// Método para ler um ficheiro diferente atrávez de uma string.
        /// </summary>
        /// <param name="file"> Nome do ficheiro. </param>
        public void ReadFile(string file)
        {
            FileReader newFile = new FileReader(file);
            newFile.ReadFile();
        }

        public bool TryRead(string file)
        {
            // Indicar se existe a coluna do planeta.
            bool planetName = false;
            // Indicar se existe a coluna da estrela.
            bool starName = false;

            int lineCount;

            // Tentar ler o ficheiro.
            try
            {
                // Conteúdo do ficheiro.
                string content = "";
                // Linhas do ficheiro.
                string[] lines;

                // Ler ficheiro.
                using (StreamReader sr = File.OpenText(file))
                {
                    lineCount = File.ReadLines(file).Count();

                    // Passar à frente as linhas que têem #.
                    do
                    {
                        content = sr.ReadLine();
                    } while (content.StartsWith("#"));

                    // Dividir a linha e colocar cada campo na array.
                    lines = new string[content.Length];
                    lines = content.Split(',');

                    // Verificar se os campos obrigatórios existem na array.
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains("pl_name"))
                        {
                            planetName = true;
                        }
                        if (lines[i].Contains("hostname"))
                        {
                            starName = true;
                        }
                    }

                    // Verificar se os campos obrigatórios existem.
                    if (planetName == true && starName == true)
                    {
                        return true;
                    }
                    else
                    {
                        /* Atirar exceção caso não tenha as colunas 
                         * obrigatórias. */
                        throw new Exception();
                    }

                }
            }
            // Caso não  tenhas as colunas obrigatórias.
            catch (Exception)
            {
                Console.WriteLine("Could not read file.");
                return false;
            }
        }

        /// <summary>
        /// Método para ordenar parâmetros para planetas.
        /// </summary>
        /// <param name="choice"> Input do user. </param>
        /// <param name="retry"> Verificar se pode parar o loop. </param>
        /// <returns> Retorna o enum Pl_Name. </returns>
        public PlanetField OrderByPlanets(ConsoleKeyInfo choice, bool retry)
        {
            do
            {
                Console.WriteLine("\nChoose an order." +
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
                // Variável para manter a escolha do utilizador.
                choice = Console.ReadKey();
                // Variável para se o utilizador escolhar uma opção inválida.
                retry = false;
                switch (choice.Key)
                {
                    // Caso o utilizador escolha a opção número 1.
                    case ConsoleKey.D1:
                        return PlanetField.Pl_Name;
                    // Caso o utilizador escolha a opção número 2.
                    case ConsoleKey.D2:
                        return PlanetField.HostName;
                    // Caso o utilizador escolha a opção número 3.
                    case ConsoleKey.D3:
                        return PlanetField.DiscoveryMethod;
                    // Caso o utilizador escolha a opção número 4.
                    case ConsoleKey.D4:
                        return PlanetField.Disc_Year;
                    // Caso o utilizador escolha a opção número 5.
                    case ConsoleKey.D5:
                        return PlanetField.Pl_Orbper;
                    // Caso o utilizador escolha a opção número 6.
                    case ConsoleKey.D6:
                        return PlanetField.Pl_Rade;
                    // Caso o utilizador escolha a opção número 7.
                    case ConsoleKey.D7:
                        return PlanetField.St_Rad;
                    // Caso o utilizador escolha a opção número 8.
                    case ConsoleKey.D8:
                        return PlanetField.Pl_Eqt;
                    // Caso o utilizador escolha a opção número 9.
                    case ConsoleKey.D9:
                        return PlanetField.St_Teff;
                    // Caso o utilizador escolha a opção letra A.
                    case ConsoleKey.A:
                        return PlanetField.Pl_Masse;
                    // Caso o utilizador escolha a opção letra B.
                    case ConsoleKey.B:
                        return PlanetField.St_Mass;
                    // Caso o utilizador escolha a opção letra C.
                    case ConsoleKey.C:
                        return PlanetField.St_Age;
                    // Caso o utilizador escolha a opção letra D.
                    case ConsoleKey.D:
                        return PlanetField.St_Vsin;
                    // Caso o utilizador escolha a opção letra E.
                    case ConsoleKey.E:
                        return PlanetField.St_Rotp;
                    // Caso o utilizador escolha a opção letra F.
                    case ConsoleKey.F:
                        return PlanetField.Sy_Dist;
                    default:
                        Console.WriteLine("Unknown command, try again.");
                        retry = true;
                        break;
                }
            } while (retry == true);
            return PlanetField.Pl_Name;
        }

        /// <summary>
        /// Método para ordenar parametros para estrelas.
        /// </summary>
        /// <param name="choice"> Input do user. </param>
        /// <param name="retry"> Verificar se pode parar o loop. </param>
        /// <returns> Retorna o enum HostName. </returns>
        public StarFields OrderByStars(ConsoleKeyInfo choice, bool retry)
        {
            do
            {
                Console.WriteLine("\nChoose an order." +
                    "\n\t1 - Star Name;" +
                    "\n\t2 - Discovery Method;" +
                    "\n\t3 - Discovery Year" +
                    "\n\t4 - Radius;" +
                    "\n\t5 - Temperature;" +
                    "\n\t6 - Mass;" +
                    "\n\t7 - Age;" +
                    "\n\t8 - Rotation Velocity;" +
                    "\n\t9 - Rotation Period;" +
                    "\n\tA - Host Distance to the Sun;" +
                    "\n\tB - Number of Planets;");
                System.Threading.Thread.Sleep(1000);
                // Variável para manter a escolha do utilizador.
                choice = Console.ReadKey();
                // Variável para se o utilizador escolhar uma opção inválida.
                retry = false;
                switch (choice.Key)
                {
                    // Caso o utilizador escolha a opção número 1.
                    case ConsoleKey.D1:
                        return StarFields.HostName;
                    // Caso o utilizador escolha a opção número 2.
                    case ConsoleKey.D2:
                        return StarFields.DiscoveryMethod;
                    // Caso o utilizador escolha a opção número 3.
                    case ConsoleKey.D3:
                        return StarFields.Disc_Year;
                    // Caso o utilizador escolha a opção número 4.
                    case ConsoleKey.D4:
                        return StarFields.St_Rad;
                    // Caso o utilizador escolha a opção número 5.
                    case ConsoleKey.D5:
                        return StarFields.St_Teff;
                    // Caso o utilizador escolha a opção número 6.
                    case ConsoleKey.D6:
                        return StarFields.St_Mass;
                    // Caso o utilizador escolha a opção número 7.
                    case ConsoleKey.D7:
                        return StarFields.St_Age;
                    // Caso o utilizador escolha a opção número 8.
                    case ConsoleKey.D8:
                        return StarFields.St_Vsin;
                    // Caso o utilizador escolha a opção número 9.
                    case ConsoleKey.D9:
                        return StarFields.St_Rotp;
                    // Caso o utilizador escolha a opção letra A.
                    case ConsoleKey.A:
                        return StarFields.Sy_Dist;
                    // Caso o utilizador escolha a opção letra B.
                    case ConsoleKey.B:
                        return StarFields.St_PlCount;
                    default:
                        Console.WriteLine("Unknown command, try again.");
                        retry = true;
                        break;
                }
            } while (retry == true);
            return StarFields.HostName;
        }

        /// <summary>
        /// Método para imprimir informação na consola Planetas.
        /// </summary>
        /// <param name="filter"> Dados filtrados. </param>
        public void PrintInfo(Dictionary<int, Planet> filter)
        {
            Dictionary<int, Planet> showInfo = filter;

            bool isDone = false;

            int skip = 0;
            int take = 0;

            ConsoleKeyInfo choice;

            // Imprimir
            while (isDone == false)
            {
                Console.WriteLine("Right arrow key: See more results.");
                Console.WriteLine("Up arrow key: Return to Menu.");
                choice = Console.ReadKey();
                if (choice.Key == ConsoleKey.RightArrow)
                {
                    take += 10;
                    showInfo = filter.Take(take).Skip(skip).ToDictionary(x =>
                    x.Key, x => x.Value);
                    Console.WriteLine(" ID |" +
                        "                                             Planet" +
                        "                                              |" +
                        "            Star            |" +
                        "         Disc Method          |" +
                        " Disc Year|" +
                        "   Orb Per  |" +
                        "Pl Radius |" +
                        " St Radius|" +
                        " Pl Temp  |" +
                        " St Temp  |" +
                        " Pl Mass  |" +
                        " St Mass  |" +
                        "  St Age  |" +
                        "St Rot Vel|" +
                        "St Rot Per|" +
                        "St Dist Sun");
                    foreach (KeyValuePair<int, Planet> item in showInfo)
                    {
                        Console.WriteLine($"{ item.Key,-5}" +
                            $"|{item.Value.Pl_Name}|" +
                            $"{item.Value.HostName}" +
                            $"|{item.Value.DiscoveryMethod}|" +
                            $"{item.Value.Disc_Year,-10}" +
                            $"|{item.Value.Pl_Orbper,-12}|" +
                            $"{item.Value.Pl_Rade,-10}" +
                            $"|{item.Value.St_Rad,-10}|" +
                            $"{item.Value.Pl_Eqt,-10}" +
                            $"|{item.Value.St_Teff,-10}|" +
                            $"{item.Value.Pl_Masse,-10}" +
                            $"|{item.Value.St_Mass,-10}|" +
                            $"{item.Value.St_Age,-10}" +
                            $"|{item.Value.St_Vsin,-10}|" +
                            $"{item.Value.St_Rotp,-10}" +
                            $"|{item.Value.Sy_Dist,-10}");
                    }
                    skip += 10;
                }
                else if (choice.Key == ConsoleKey.UpArrow)
                {
                    isDone = true;
                }
            }
        }

        /// <summary>
        /// Método para imprimir informação na consola Estrelas.
        /// </summary>
        /// <param name="filter"> Dados filtrados. </param>
        public void PrintInfo(Dictionary<int, Star> filter)
        {
            Dictionary<int, Star> showInfo = filter;

            bool isDone = false;

            int skip = 0;
            int take = 0;

            ConsoleKeyInfo choice;

            // Imprimir
            while (isDone == false)
            {
                Console.WriteLine("Right arrow key: See more results.");
                Console.WriteLine("Up arrow key: Return to Menu.");
                choice = Console.ReadKey();
                if (choice.Key == ConsoleKey.RightArrow)
                {
                    take += 10;
                    showInfo = filter.Take(take).Skip(skip).ToDictionary(x =>
                    x.Key, x => x.Value);
                    Console.WriteLine("Results: ");

                    Console.WriteLine("  ID |" +
                        "            Star            |" +
                        "         Disc Method          |" +
                        " Disc Year|" +
                        "  Temper  |" +
                        "  Radius  |" +
                        "   Mass   |" +
                        "    Age   |" +
                        "  Rot Vel |" +
                        "  Rot Per |" +
                        " Dist Sun |" +
                        "Num of Planets");

                    foreach (KeyValuePair<int, Star> item in showInfo)
                    {
                        Console.WriteLine($"{item.Key,-5}" +
                            $"|{item.Value.HostName}|" +
                            $"{item.Value.DiscoveryMethod}" +
                            $"|{item.Value.Disc_Year,-10}|" +
                            $"{item.Value.St_Teff,-10}" +
                            $"|{item.Value.St_Rad,-10}|" +
                            $"{item.Value.St_Mass,-10}" +
                            $"|{item.Value.St_Age,-10}|" +
                            $"{item.Value.St_Vsin,-10}" +
                            $"|{item.Value.St_Rotp,-10}|" +
                            $"{item.Value.Sy_Dist,-10}" +
                            $"|{item.Value.St_PlCount,-10}");
                    }
                    skip += 10;
                }
                else if (choice.Key == ConsoleKey.UpArrow)
                {
                    isDone = true;
                }
            }
        }

        /// <summary>
        /// Método para odernar planetas por nome.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação segundário.
        /// </param>
        public void PlanetSortName(string input, bool isAscending,
        Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>,
            Object> order, Func<KeyValuePair<int, Planet>, Object>
            secondOrder)
        {
            if (input != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Name.StartsWith(input,
                         StringComparison.InvariantCultureIgnoreCase)
                         select item).OrderBy(x => order(x)).ThenBy(x =>
                         secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Name.StartsWith(input,
                         StringComparison.InvariantCultureIgnoreCase)
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para odernar planetas por estrela.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void PlanetSortHost(string input, bool isAscending,
        Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>,
            Object> order, Func<KeyValuePair<int, Planet>, Object>
            secondOrder)
        {
            if (input != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.HostName.StartsWith(input,
                         StringComparison.InvariantCultureIgnoreCase)
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.HostName.StartsWith(input,
                         StringComparison.InvariantCultureIgnoreCase)
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para odernar planetas por método de descoberta.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário.
        /// </param>
        public void PlanetSortDiscMethod(string input, bool isAscending,
    Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>, Object>
            order, Func<KeyValuePair<int, Planet>, Object> secondOrder)
        {
            if (input != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.DiscoveryMethod.StartsWith(input,
                         StringComparison.InvariantCultureIgnoreCase)
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.DiscoveryMethod.StartsWith(input,
                         StringComparison.InvariantCultureIgnoreCase)
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar os planetas por ano de descoberta.
        /// </summary>
        /// <param name="min"> Ano mínimo (input do user). </param>
        /// <param name="max"> Ano máximo (input máximo). </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário.
        /// </param>
        public void PlanetSortDiscYear(int? min, int? max, bool isAscending,
            Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>,
                Object> order, Func<KeyValuePair<int, Planet>, Object>
            secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year < max
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year < max
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min &&
                         item.Value.Disc_Year < max
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min &&
                         item.Value.Disc_Year < max
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        // Método para ordenar informação com inputs double para planetas
        /// <summary>
        /// Método para ordenar os planetas por período orbital.
        /// </summary>
        /// <param name="min"> Mínimo de dias. (input do user). </param>
        /// <param name="max"> Máximo de dias. (input do user). </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void PlanetSortOrbp(double? min, double? max, bool isAscending,
            Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>,
                Object> order, Func<KeyValuePair<int, Planet>, Object>
            secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Orbper < max
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Orbper < max
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Orbper > min
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Orbper > min
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Orbper > min &&
                         item.Value.Pl_Orbper < max
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Orbper > min &&
                         item.Value.Pl_Orbper < max
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        // Método para ordenar informação com inputs double para planetas
        /// <summary>
        /// Método para ordenar os planetas por emperatura do equilíbrio.
        /// </summary>
        /// <param name="min"> Temperatura mínima. </param>
        /// <param name="max"> Temperatura máximo. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void PlanetSortEqt(int? min, int? max, bool isAscending,
            Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>,
                Object> order, Func<KeyValuePair<int, Planet>, Object>
            secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Eqt < max
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Eqt < max
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Eqt > min
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Eqt > min
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Eqt > min &&
                         item.Value.Pl_Eqt < max
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Eqt > min &&
                         item.Value.Pl_Eqt < max
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar os planetas por massa.
        /// </summary>
        /// <param name="min"> Massa mínima. </param>
        /// <param name="max"> Massa máxima. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void PlanetSortPlMass(double? min, double? max,
            bool isAscending,
            Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>,
                Object> order, Func<KeyValuePair<int, Planet>, Object>
            secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Masse < max
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Masse < max
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Masse > min
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Masse > min
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Masse > min
                         && item.Value.Pl_Masse < max
                         select item).OrderBy(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Masse > min
                         && item.Value.Pl_Masse < max
                         select item).OrderByDescending(x => order(x)).
                         ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar planetas por massa da sua estrela.
        /// </summary>
        /// <param name="min"> Massa mínima. </param>
        /// <param name="max"> Massa máxima. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void PlanetSortStMass(double? min, double? max,
            bool isAscending, Dictionary<int, Planet> filter,
            Func<KeyValuePair<int, Planet>,
                Object> order, Func<KeyValuePair<int, Planet>, Object>
            secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass > min
                         && item.Value.St_Mass < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass > min
                         && item.Value.St_Mass < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar planetas por idade da sua estrela.
        /// </summary>
        /// <param name="min"> Idade mínima. </param>
        /// <param name="max"> Idade máxima. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void PlanetSortStAge(double? min, double? max, bool isAscending,
            Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>,
                Object> order, Func<KeyValuePair<int, Planet>, Object>
            secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age > min
                         && item.Value.St_Age < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age > min
                         && item.Value.St_Age < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        // Método para ordenar informação com inputs double para planetas
        /// <summary>
        /// Método para ordenar planetas por velocidade de rotação da sua 
        /// estrela.
        /// </summary>
        /// <param name="min"> Velocidade mínima. </param>
        /// <param name="max"> Velocidade máxima. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void PlanetSortStVsin(double? min, double? max,
            bool isAscending, Dictionary<int, Planet> filter,
            Func<KeyValuePair<int, Planet>, Object> order,
            Func<KeyValuePair<int, Planet>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin > min
                         && item.Value.St_Vsin < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin > min
                         && item.Value.St_Vsin < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar planetas por período de rotação da sua estrela.
        /// </summary>
        /// <param name="min"> Período mínimo. </param>
        /// <param name="max"> Período máximo. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário.
        /// </param>
        public void PlanetSortStRotp(double? min, double? max,
            bool isAscending, Dictionary<int, Planet> filter,
            Func<KeyValuePair<int, Planet>, Object> order,
            Func<KeyValuePair<int, Planet>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp > min
                         && item.Value.St_Rotp < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp > min
                         && item.Value.St_Rotp < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar planetas por distância da sua estrela.
        /// </summary>
        /// <param name="min"> Distância mínima. </param>
        /// <param name="max"> Distância máxima. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void PlanetSortStDyst(double? min, double? max,
            bool isAscending, Dictionary<int, Planet> filter,
            Func<KeyValuePair<int, Planet>, Object> order,
            Func<KeyValuePair<int, Planet>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist > min
                         && item.Value.Sy_Dist < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist > min
                         && item.Value.Sy_Dist < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método de ordenação de planetas por temperatura efetiva da sua 
        /// estrela.
        /// </summary>
        /// <param name="min"> Temperatura mínima. </param>
        /// <param name="max"> Temperatura máxima. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário.
        /// </param>
        public void PlanetSortHostTeff(int? min, int? max,
            bool isAscending, Dictionary<int, Planet> filter,
            Func<KeyValuePair<int, Planet>, Object> order,
            Func<KeyValuePair<int, Planet>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff > min
                         && item.Value.St_Teff < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff > min
                         && item.Value.St_Teff < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método de ordenação de planetas por raio do planeta.
        /// </summary>
        /// <param name="min"> Raio mínimo. </param>
        /// <param name="max"> Raio máximo. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void PlanetSortRade(double? min, double? max,
            bool isAscending, Dictionary<int, Planet> filter,
            Func<KeyValuePair<int, Planet>, Object> order,
            Func<KeyValuePair<int, Planet>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Rade < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Rade < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Rade > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Rade > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Rade > min
                         && item.Value.Pl_Rade < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Rade > min
                         && item.Value.Pl_Rade < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método de ordenação de planetas por raio da sua estrela.
        /// </summary>
        /// <param name="min"> Raio mínimo. </param>
        /// <param name="max"> Raio máximo. </param>
        /// <param name="isAscending"> Ordem da ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário.
        /// </param>
        public void PlanetSortHostRad(double? min, double? max,
            bool isAscending, Dictionary<int, Planet> filter,
            Func<KeyValuePair<int, Planet>, Object> order,
            Func<KeyValuePair<int, Planet>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad > min
                         && item.Value.St_Rad < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad > min
                         && item.Value.St_Rad < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar estrelas pelo seu nome.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário.
        /// </param>
        public void StarSortName(string input, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>,
                Object> order, Func<KeyValuePair<int, Star>, Object>
            secondOrder)
        {
            if (input != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.HostName.StartsWith(input,
                         StringComparison.InvariantCultureIgnoreCase)
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.HostName.StartsWith(input,
                         StringComparison.InvariantCultureIgnoreCase)
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar estrelas pelo método de descoberta.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void StarSortDiscMethod(string input, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>,
                Object> order, Func<KeyValuePair<int, Star>, Object>
            secondOrder)
        {
            if (input != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.DiscoveryMethod.StartsWith(input,
                         StringComparison.InvariantCultureIgnoreCase)
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.DiscoveryMethod.StartsWith(input,
                         StringComparison.InvariantCultureIgnoreCase)
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar estrelas pelo ano de descoberta.
        /// </summary>
        /// <param name="min"> Ano mínimo. </param>
        /// <param name="max"> Ano máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void StarSortDiscYear(int? min, int? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object>
            order, Func<KeyValuePair<int, Star>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min
                         && item.Value.Disc_Year < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min
                         && item.Value.Disc_Year < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar estrelas pela temperatura. 
        /// </summary>
        /// <param name="min"> Temperatura mínima. </param>
        /// <param name="max"> Temperatura máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void StarSortTeff(double? min, double? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object>
            order, Func<KeyValuePair<int, Star>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff > min
                         && item.Value.St_Teff < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Teff > min
                         && item.Value.St_Teff < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar estrelas pelo raio.
        /// </summary>
        /// <param name="min"> Raio mínimo. </param>
        /// <param name="max"> Raio máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário.
        /// </param>
        public void StarSortRad(double? min, double? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object>
            order, Func<KeyValuePair<int, Star>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad > min
                         && item.Value.St_Rad < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad > min
                         && item.Value.St_Rad < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar estrelas pela idade.
        /// </summary>
        /// <param name="min"> Idade mínima. </param>
        /// <param name="max"> Idade máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void StarSortAge(double? min, double? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object>
            order, Func<KeyValuePair<int, Star>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age > min
                         && item.Value.St_Age < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Age > min
                         && item.Value.St_Age < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar estrelas pela velocidade de rotação.
        /// </summary>
        /// <param name="min"> Velocidade mínima. </param>
        /// <param name="max"> Velocidade máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void StarSortVsin(double? min, double? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object>
            order, Func<KeyValuePair<int, Star>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin > min
                         && item.Value.St_Vsin < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Vsin > min
                         && item.Value.St_Vsin < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar estrelas pelo período de rotação.
        /// </summary>
        /// <param name="min"> Período mínimo. </param>
        /// <param name="max"> Período máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void StarSortRtop(double? min, double? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object>
            order, Func<KeyValuePair<int, Star>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp > min
                         && item.Value.St_Rotp < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rotp > min
                         && item.Value.St_Rotp < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        // Método para ordenar informação com inputs double para estrelas
        /// <summary>
        /// Método para ordenar estrelas pela distância. 
        /// </summary>
        /// <param name="min"> Distância mínima. </param>
        /// <param name="max"> Distância máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário.
        /// </param>
        public void StarSortDyst(double? min, double? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object>
            order, Func<KeyValuePair<int, Star>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist > min
                         && item.Value.Sy_Dist < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Sy_Dist > min
                         && item.Value.Sy_Dist < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar estrelas pelo número de planetas.
        /// </summary>
        /// <param name="min"> Número mínimo de planetas. </param>
        /// <param name="max"> Número máximo de planetas. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void StarSortPlCount(int? min, int? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object>
            order, Func<KeyValuePair<int, Star>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_PlCount < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_PlCount < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_PlCount > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_PlCount > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_PlCount > min
                         && item.Value.St_PlCount < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_PlCount > min
                         && item.Value.St_PlCount < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para ordenar estrelas pela massa.
        /// </summary>
        /// <param name="min"> Massa mínima. </param>
        /// <param name="max"> Massa máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="filter"> Dados filtrados. </param>
        /// <param name="order"> Critério de ordenação. </param>
        /// <param name="secondOrder"> Critério de ordenação secundário. 
        /// </param>
        public void StarSortMass(double? min, double? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object>
            order, Func<KeyValuePair<int, Star>, Object> secondOrder)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass > min
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass > min
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass > min
                         && item.Value.St_Mass < max
                         select item).OrderBy(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Mass > min
                         && item.Value.St_Mass < max
                         select item).OrderByDescending(x => order(x))
                         .ThenBy(x => secondOrder(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                PrintInfo(filter);
            }
            else
            {
                PrintInfo(filter);
            }
            Console.WriteLine("Dicionary filter: " + filter.Count);
        }

        /// <summary>
        /// Método para pesquisar estrelas por nome de estrela.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByStarName(string input, bool isAscending,
            StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByName(input, isAscending, fields);
        }

        /// <summary>
        /// Méotod para pesquisar estrelas por método de descoberta.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. <param>
        public void SearchByStarDiscoveryMethod(string input, bool isAscending,
            StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDiscoveryMethod(input, isAscending, fields);
        }

        /// <summary>
        /// Método para pesquisar estrelas por ano de descoberta. 
        /// </summary>
        /// <param name="min"> Ano mínimo. </param>
        /// <param name="max"> Ano máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByStarDiscoveryYear(int? min, int? max,
            bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDiscoveryYear(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método para pesquisar estrelas por temperatura.
        /// </summary>
        /// <param name="min"> Temperatura mínima. </param>
        /// <param name="max"> Temperatura máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByStarTeff(double? min, double? max, bool isAscending
            , StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByTeff(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método para pesquisar estrelas por raio.
        /// </summary>
        /// <param name="min"> Raio mínimo. </param>
        /// <param name="max"> Raio máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByStarRad(double? min, double? max, bool isAscending,
            StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByRad(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método para pesquisar estrelas pela massa.
        /// </summary>
        /// <param name="min"> Massa mínima. </param>
        /// <param name="max"> Massa máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByStarMass(double? min, double? max, bool isAscending
            , StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByMass(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método para pesquisar estrelas pela idade.
        /// </summary>
        /// <param name="min"> Idade mínima. </param>
        /// <param name="max"> Idade máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByStarAge(double? min, double? max, bool isAscending,
            StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByAge(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método para pesquisar estrelas pela velocidade de rotação.
        /// </summary>
        /// <param name="min"> Velocidade mínima. </param>
        /// <param name="max"> Velocidade máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByStarVsin(double? min, double? max, bool isAscending
            , StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByVsin(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método para pesquisar estrelas pelo período de rotação.
        /// </summary>
        /// <param name="min"> Período mínimo. </param>
        /// <param name="max"> Período máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByStarRtop(double? min, double? max, bool isAscending
            , StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByRotp(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método para pesquisar estrelas pela distância.
        /// </summary>
        /// <param name="min"> Distância mínima. </param>
        /// <param name="max"> Distância máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByStarDist(double? min, double? max, bool isAscending
            , StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDist(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método para pesquisar estrelas pelo número de planetas. 
        /// </summary>
        /// <param name="min"> Número de planetas mínimo. </param>
        /// <param name="max"> Número de planetas máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByPlCount(int? min, int? max, bool isAscending,
            StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByPlCount(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo nome.
        /// </summary>
        /// <param name="name"> Nome do planeta. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetName(string name, bool isAscending,
            PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetName(name, isAscending, fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo nome das suas estrelas.
        /// </summary>
        /// <param name="hostname"> Nome da estrela. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostName(string hostname, bool isAscending,
            PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostName(hostname, isAscending,
                fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo método de descoberta.
        /// </summary>
        /// <param name="discoveryMethod"> Método de descoberta. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetDiscoveryMethod(string discoveryMethod,
            bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetDiscoveryMethod(discoveryMethod,
                isAscending, fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo ano de descoberta.
        /// </summary>
        /// <param name="min"> Ano mínimo. </param>
        /// <param name="max"> Ano máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetDiscoveryYear(int? min, int? max,
            bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetDiscoveryYear(min, max, isAscending,
                fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo período orbital.
        /// </summary>
        /// <param name="min"> Período orbital mínimo. </param>
        /// <param name="max"> Período orbital máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetOrbitalPeriod(int? min, int? max,
            bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetOrbitalPeriod(min, max, isAscending,
                fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo raio.
        /// </summary>
        /// <param name="min"> Raio mínimo. </param>
        /// <param name="max"> Raio máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetRadius(double? min, double? max,
            bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetRadius(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo raio da estrela.
        /// </summary>
        /// <param name="min"> Raio mínimo. </param>
        /// <param name="max"> Raio máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostRad(double? min, double? max,
            bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostRad(min, max, isAscending,
                fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela temperatura de equilibrio.
        /// </summary>
        /// <param name="min"> Temeperatura mínima. </param>
        /// <param name="max"> Temperatura máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetEqt(int? min, int? max, bool isAscending,
            PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetEqt(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela temperatura efetiva da sua 
        /// estrela.
        /// </summary>
        /// <param name="min"> Temperatura mínima. </param>
        /// <param name="max"> Temperatura máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostTeff(int? min, int? max, bool isAscending
            , PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostTeff(min, max, isAscending,
                fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela massa.
        /// </summary>
        /// <param name="min"> Massa mínima. </param>
        /// <param name="max"> Massa máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetMass(double? min, double? max,
            bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetMass(min, max, isAscending, fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela massa da sua estrela.
        /// </summary>
        /// <param name="min"> Massa mínima. </param>
        /// <param name="max"> Massa máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostMass(double? min, double? max,
            bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostMass(min, max, isAscending,
                fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela idade da sua estrela.
        /// </summary>
        /// <param name="min"> Idade mínima. </param>
        /// <param name="max"> Idade máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostAge(int? min, int? max, bool isAscending,
            PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostAge(min, max, isAscending,
                fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela velocidade de rotação da sua
        /// estrela.
        /// </summary>
        /// <param name="min"> Velocidade mínima. </param>
        /// <param name="max"> Velocidade máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostVsin(double? min, double? max,
            bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostVsin(min, max, isAscending,
                fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo período de rotação da sua 
        /// estrela.
        /// </summary>
        /// <param name="min"> Período mínimo. </param>
        /// <param name="max"> Período máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostRotp(int? min, int? max, bool isAscending
            , PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostRotp(min, max, isAscending,
                fields);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela distância do sol até a sua
        /// estrela.
        /// </summary>
        /// <param name="min"> Distância mínima. </param>
        /// <param name="max"> Distância máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta.</param>
        public void SearchByPlanetHostDist(double? min, double? max,
            bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostDist(min, max, isAscending,
                fields);
        }
    }
}
