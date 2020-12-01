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
        public void MainMenu() {
            Facade facade = new Facade();
            string file = "planetList.csv";
            facade.ReadFile();
            Console.WriteLine("\nWelcome to the Interstelar sorter." +
                $"\nYou are currently reading {file}." +
                "\nWhat would you like to sort?\n\n\t1 = Planets;" +
                "\n\t2 = Stars;\n\tR = Read another File;\n\tEsc = Exit.");
            bool retry;
            do {
                // Variável para manter a escolha do utilizador
                ConsoleKeyInfo choice = Console.ReadKey();
                // Variável para se o utilizador escolhar uma opção inválida
                retry = false;
                // Switch para as variadas opções
                switch (choice.Key) {
                    // Caso o utilizador escolha a opção número 1
                    case ConsoleKey.D1:
                        Console.Write("\nYou have chosen Planets," +
                            " standby for results");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(" .");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(" .");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(" .\n");
                        System.Threading.Thread.Sleep(1000);
                        // Mostrar planetas (id e nome, só para testar)
                        foreach (KeyValuePair<int, Planet> item in Facade.planetList) {
                            Console.WriteLine(string.Format($"ID: " +
                                $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}"));
                        }
                        // Voltar ao menu
                        MainMenu();
                        break;
                    // Caso o utilizador escolha a opção número 2
                    case ConsoleKey.D2:
                        Console.Write("\nYou have chosen Stars, standby for results");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(" .");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(" .");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(" .\n");
                        System.Threading.Thread.Sleep(1000);
                        // Mostrar estrelas (id, nome e nº de planetas só para testar)
                        foreach (KeyValuePair<int, Star> item in Facade.starList) {
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
                        Console.WriteLine("\nWelcome to the Interstelar sorter." +
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