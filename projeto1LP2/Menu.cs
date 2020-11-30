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
            facade.ReadFile();
            Console.WriteLine("\nWelcome to the Interstelar sorter.\n\nWhat would you like to sort?\n\n\t1 = Planets\n\t2 = Stars\n\tEsc = Exit");
            bool retry;
            do
            {
                ConsoleKeyInfo choice = Console.ReadKey();
                retry = false;
                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("\nYou have chosen Planets, standby for results");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(" .");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(" .");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(" .\n");
                        System.Threading.Thread.Sleep(1000);
                        // Mostrar planetas (id e nome, só para testar)
                        foreach (KeyValuePair<int, Planet> item in Facade.planetList)
                        {
                            Console.WriteLine(string.Format($"ID: {item.Key,-5} | Planeta: {item.Value.Pl_Name,-30}"));
                        }
                        MainMenu();
                        break;
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
                        foreach (KeyValuePair<int, Star> item in Facade.starList)
                        {
                            Console.WriteLine(string.Format($"ID: {item.Key,-5} | Estrela: {item.Value.HostName,-30}" +
                             $" | Planetas: {item.Value.St_PlCount,-2}"));
                        }
                        MainMenu();
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
                    default:
                        Console.WriteLine("\nUnknown Command, please try again.");
                        retry = true;
                        break;
                }
            } while (retry == true);
        }
    }
}
