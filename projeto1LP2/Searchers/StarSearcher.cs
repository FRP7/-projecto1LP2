using System;
using System.Linq;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Classe onde vão estar os métodos de pesquisa de estrelas.
    /// </summary>
    class StarSearcher 
    {
        // Aceder à Facade.
        private Facade facade;
        private Dictionary<int, Star> filter = new Dictionary<int, Star>(Facade.starList);

        // Método exemplo de pesquisa de estrelas.
        public void SearchByName(string name) {
            Facade.starList = filter;

            Console.WriteLine("Filtrar pelo nome");

            // Filtro
            /*filter = filter.Where(p => p.Value.HostName.StartsWith(name))
                .ToDictionary(p => p.Key, p => p.Value);*/

            // Filtro (código simplificado)
            filter =
                (from item in filter
                 where item.Value.HostName.StartsWith(name)
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filter) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Planets: {item.Value.St_PlCount,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filter.Count);
        }

        // Inicializar as variáveis.
        public StarSearcher() {
            facade = new Facade();
        }
    }
}
