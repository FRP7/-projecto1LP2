using System;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Aqui é onde começa o programa.
    /// </summary>
    class Program
    {
        static void Main(string[] args) {
            /*Menu menu = new Menu();
            menu.MainMenu();*/
            // testar filtros
            Facade facade = new Facade();
            facade.ReadFile();
            facade.SearchByName("t");
            //Console.WriteLine("Dicionario principal: " + Facade.starList.Count);
            Console.WriteLine("Dicionario principal: " + Facade.starList[0].HostName);
        }
    }
}
