using System;
using System.Collections.Generic;
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

        // Método que chama método de ler ficheiro no FileReader.
        public void ReadFile()
        {
            FileReader file = new FileReader("planetList.csv");
            file.ReadFile();
        }

        // Método para ler ficheiro atrávez de uma string.
        public void ReadFile(string file)
        {
            FileReader newFile = new FileReader(file);
            newFile.ReadFile();
        }

        // Método para ordenar parametros para planetas
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
                // Variável para manter a escolha do utilizador
                choice = Console.ReadKey();
                // Variável para se o utilizador escolhar uma opção inválida
                retry = false;
                switch (choice.Key)
                {
                    // Caso o utilizador escolha a opção número 1
                    case ConsoleKey.D1:
                        return PlanetField.Pl_Name;
                    // Caso o utilizador escolha a opção número 2
                    case ConsoleKey.D2:
                        return PlanetField.HostName;
                    // Caso o utilizador escolha a opção número 3
                    case ConsoleKey.D3:
                        return PlanetField.DiscoveryMethod;
                    // Caso o utilizador escolha a opção número 4
                    case ConsoleKey.D4:
                        return PlanetField.Disc_Year;
                    // Caso o utilizador escolha a opção número 5
                    case ConsoleKey.D5:
                        return PlanetField.Pl_Orbper;
                    // Caso o utilizador escolha a opção número 6
                    case ConsoleKey.D6:
                        return PlanetField.Pl_Rade;
                    // Caso o utilizador escolha a opção número 7
                    case ConsoleKey.D7:
                        return PlanetField.St_Rad;
                    // Caso o utilizador escolha a opção número 8
                    case ConsoleKey.D8:
                        return PlanetField.Pl_Eqt;
                    // Caso o utilizador escolha a opção número 9
                    case ConsoleKey.D9:
                        return PlanetField.St_Teff;
                    // Caso o utilizador escolha a opção letra A
                    case ConsoleKey.A:
                        return PlanetField.Pl_Masse;
                    // Caso o utilizador escolha a opção letra B
                    case ConsoleKey.B:
                        return PlanetField.St_Mass;
                    // Caso o utilizador escolha a opção letra C
                    case ConsoleKey.C:
                        return PlanetField.St_Age;
                    // Caso o utilizador escolha a opção letra D
                    case ConsoleKey.D:
                        return PlanetField.St_Vsin;
                    // Caso o utilizador escolha a opção letra E
                    case ConsoleKey.E:
                        return PlanetField.St_Rotp;
                    // Caso o utilizador escolha a opção letra F
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

        // Método para ordenar parametros para estrelas
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
                // Variável para manter a escolha do utilizador
                choice = Console.ReadKey();
                // Variável para se o utilizador escolhar uma opção inválida
                retry = false;
                switch (choice.Key)
                {
                    // Caso o utilizador escolha a opção número 1
                    case ConsoleKey.D1:
                        return StarFields.HostName;
                    // Caso o utilizador escolha a opção número 2
                    case ConsoleKey.D2:
                        return StarFields.DiscoveryMethod;
                    // Caso o utilizador escolha a opção número 3
                    case ConsoleKey.D3:
                        return StarFields.Disc_Year;
                    // Caso o utilizador escolha a opção número 4
                    case ConsoleKey.D4:
                        return StarFields.St_Rad;
                    // Caso o utilizador escolha a opção número 5
                    case ConsoleKey.D5:
                        return StarFields.St_Teff;
                    // Caso o utilizador escolha a opção número 6
                    case ConsoleKey.D6:
                        return StarFields.St_Mass;
                    // Caso o utilizador escolha a opção número 7
                    case ConsoleKey.D7:
                        return StarFields.St_Age;
                    // Caso o utilizador escolha a opção número 8
                    case ConsoleKey.D8:
                        return StarFields.St_Vsin;
                    // Caso o utilizador escolha a opção número 9
                    case ConsoleKey.D9:
                        return StarFields.St_Rotp;
                    // Caso o utilizador escolha a opção letra A
                    case ConsoleKey.A:
                        return StarFields.Sy_Dist;
                    // Caso o utilizador escolha a opção letra B
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

        // Método para imprimir informação na consola
        public void PrintInfo(Dictionary<int, Planet> filter)
        {
            // Imprimir
            foreach (KeyValuePair<int, Planet> item in filter)
            {
                Console.WriteLine(string.Format($"ID:{item.Key,-5}|" +
                    $"Planet:{item.Value.HostName}|" +
                    $"Host:{item.Value.HostName}|" +
                    $"Disc Method:{item.Value.DiscoveryMethod}|" +
                    $"Disc Year:{item.Value.Disc_Year,-4}|" +
                    $"Orb Per:{item.Value.Pl_Orbper,-12}|" +
                    $"Planet Radius:{item.Value.Pl_Rade,-6}|" +
                    $"Host Radius:{item.Value.St_Rad,-6}|" +
                    $"Planet Temp:{item.Value.Pl_Eqt,-5}|" +
                    $"Host Temper:{item.Value.St_Teff,-7}|" +
                    $"Planet Mass:{item.Value.Pl_Masse,-10}|" +
                    $"Host Mass:{item.Value.St_Mass,-6}|" +
                    $"Host Age:{item.Value.St_Age,-3}|" +
                    $"Host Rot Vel:{item.Value.St_Vsin,-3}|" +
                    $"Host Rot Per:{item.Value.St_Rotp,-3}|" +
                    $"Host Dist to Sun:{item.Value.Sy_Dist,-10}"));
            }
        }

        // Método para imprimir informação na consola Estrelas
        public void PrintInfo(Dictionary<int, Star> filter)
        {
            // Imprimir
            foreach (KeyValuePair<int, Star> item in filter)
            {
                Console.WriteLine(string.Format($"ID:{item.Key,-5}|" +
                    $"Star:{item.Value.HostName}|" +
                    $"Disc Method:{item.Value.DiscoveryMethod}|" +
                    $"Disc Year:{item.Value.Disc_Year,-4}|" +
                    $"Temper:{item.Value.St_Teff,-7}|" +
                    $"Radius:{item.Value.St_Rad,-6}|" +
                    $"Mass:{item.Value.St_Mass,-6}|" +
                    $"Age:{item.Value.St_Age,-3}|" +
                    $"Rot Vel:{item.Value.St_Vsin,-3}|" +
                    $"Rot Per:{item.Value.St_Rotp,-3}|" +
                    $"Dist to Sun:{item.Value.Sy_Dist,-10}|" +
                    $"Num of Planets:{item.Value.St_PlCount,-2}"));
            }
        }
        // Método para odernar informação com inputs string para planetas
        public void SortInfo(string input, bool isAscending,
        Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>, Object> order)
        {
            if (input != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Name.StartsWith(input)
                         select item).OrderBy(x => order(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Name.StartsWith(input)
                         select item).OrderByDescending(x => order(x))
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

        // Método para odernar informação com inputs string para estrelas
        public void SortInfo(string input, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object> order)
        {
            if (input != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.HostName.StartsWith(input)
                         select item).OrderBy(x => order(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.HostName.StartsWith(input)
                         select item).OrderByDescending(x => order(x))
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

        // Método para ordenar informação com inputs int para planetas
        public void SortInfo(int? min, int? max, bool isAscending,
            Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>, Object> order)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year < max
                         select item).OrderBy(x => order(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year < max
                         select item).OrderByDescending(x => order(x))
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
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min
                         select item).OrderByDescending(x => order(x))
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
                         where item.Value.Disc_Year > min && item.Value.Disc_Year < max
                         select item).OrderBy(x => order(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min && item.Value.Disc_Year < max
                         select item).OrderByDescending(x => order(x))
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

        // Método para ordenar informação com inputs int para estrelas
        public void SortInfo(int? min, int? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object> order)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year < max
                         select item).OrderBy(x => order(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year < max
                         select item).OrderByDescending(x => order(x))
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
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min
                         select item).OrderByDescending(x => order(x))
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
                         where item.Value.Disc_Year > min && item.Value.Disc_Year < max
                         select item).OrderBy(x => order(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Disc_Year > min && item.Value.Disc_Year < max
                         select item).OrderByDescending(x => order(x))
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
        public void SortInfo(double? min, double? max, bool isAscending,
            Dictionary<int, Planet> filter, Func<KeyValuePair<int, Planet>, Object> order)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Rade < max
                         select item).OrderBy(x => order(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Rade < max
                         select item).OrderByDescending(x => order(x))
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
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Rade > min
                         select item).OrderByDescending(x => order(x))
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
                         where item.Value.Pl_Rade > min && item.Value.Pl_Rade < max
                         select item).OrderBy(x => order(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.Pl_Rade > min && item.Value.Pl_Rade < max
                         select item).OrderByDescending(x => order(x))
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
        public void SortInfo(double? min, double? max, bool isAscending,
            Dictionary<int, Star> filter, Func<KeyValuePair<int, Star>, Object> order)
        {
            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad < max
                         select item).OrderBy(x => order(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad < max
                         select item).OrderByDescending(x => order(x))
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
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad > min
                         select item).OrderByDescending(x => order(x))
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
                         where item.Value.St_Rad > min && item.Value.St_Rad < max
                         select item).OrderBy(x => order(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filter =
                        (from item in filter
                         where item.Value.St_Rad > min && item.Value.St_Rad < max
                         select item).OrderByDescending(x => order(x))
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

        // Método que chama método de pesquisa de estrelas pelo nome
        public void SearchByStarName(string input, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByName(input, isAscending, fields);
        }

        // Método que chama método de pesquisa de estrelas pelo método de descoberta
        public void SearchByStarDiscoveryMethod(string input, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDiscoveryMethod(input, isAscending, fields);
        }

        public void SearchByStarDiscoveryYear(int? min, int? max, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDiscoveryYear(min, max, isAscending, fields);
        }

        public void SearchByStarTeff(double? min, double? max, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByTeff(min, max, isAscending, fields);
        }

        public void SearchByStarRad(double? min, double? max, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByRad(min, max, isAscending, fields);
        }

        public void SearchByStarMass(double? min, double? max, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByMass(min, max, isAscending, fields);
        }

        public void SearchByStarAge(double? min, double? max, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByAge(min, max, isAscending, fields);
        }

        public void SearchByStarVsin(double? min, double? max, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByVsin(min, max, isAscending, fields);
        }

        public void SearchByStarRtop(double? min, double? max, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByRotp(min, max, isAscending, fields);
        }

        public void SearchByStarDist(double? min, double? max, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDist(min, max, isAscending, fields);
        }

        public void SearchByPlCount(double? min, double? max, bool isAscending, StarFields fields)
        {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByPlCount(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pelo nome.
        public void SearchByPlanetName(string name, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetName(name, isAscending, fields);
        }

        // Método de pesquisa de planetas pelo nome das suas estrelas.
        public void SearchByPlanetHostName(string hostname, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostName(hostname, isAscending, fields);
        }

        // Método de pesquisa de planetas pelo método de descoberta.
        public void SearchByPlanetDiscoveryMethod(string discoveryMethod, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetDiscoveryMethod(discoveryMethod, isAscending, fields);
        }

        // Método de pesquisa de planetas pelo ano de descoberta.
        public void SearchByPlanetDiscoveryYear(int? min, int? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetDiscoveryYear(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pelo ano de descoberta.
        public void SearchByPlanetOrbitalPeriod(int? min, int? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetOrbitalPeriod(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pelo raio.
        public void SearchByPlanetRadius(double? min, double? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetRadius(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pelo raio.
        public void SearchByPlanetHostRad(double? min, double? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostRad(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pela temperatura de equilibrio.
        public void SearchByPlanetEqt(int? min, int? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetEqt(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pela temperatura efetiva da sua estrela.
        public void SearchByPlanetHostTeff(int? min, int? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostTeff(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pela massa.
        public void SearchByPlanetMass(double? min, double? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetMass(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pela massa da sua estrela.
        public void SearchByPlanetHostMass(double? min, double? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostMass(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pela idade da sua estrela.
        public void SearchByPlanetHostAge(int? min, int? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostAge(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pela velocidade de rotação da sua estrela.
        public void SearchByPlanetHostVsin(double? min, double? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostVsin(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pelo período de rotação da sua estrela.
        public void SearchByPlanetHostRotp(int? min, int? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostRotp(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pela distância do sol até a sua estrela.
        public void SearchByPlanetHostDist(double? min, double? max, bool isAscending, PlanetField fields)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostDist(min, max, isAscending, fields);
        }
    }
}
