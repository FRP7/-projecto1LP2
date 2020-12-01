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
            // Mostrar planetas (id e nome, só para testar)
            /*foreach (KeyValuePair<int, Planet> item in Facade.planetList) {
                Console.WriteLine($"ID: {item.Key} | Planeta: {item.Value.Pl_Name} | Teste: {item.Value.Disc_Year}");
            }*/

            // Mostrar estrelas (id, nome e nº de planetasm só para testar)
            /*foreach (KeyValuePair<int, Star> item in Facade.starList) {
                Console.WriteLine($"ID: {item.Key} | Estrela: {item.Value.HostName}" +
                 $" | Planetas: {item.Value.St_PlCount}");
            }*/
        }
    }
}
