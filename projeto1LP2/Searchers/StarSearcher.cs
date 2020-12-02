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
        // Estas variáveis têem obrigatoriamente de serem inicializadas aqui!
        private Dictionary<int, Star> filterByName = new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByDiscoveryMethod = new Dictionary<int, Star>(Facade.starList);

        // Método de pesquisa de estrelas pelo nome.
        public void SearchByName(string name) {
            Facade.starList = filterByName; // obrigatório!!!!

            Console.WriteLine("Filtrar pelo nome");

            filterByName =
                (from item in filterByName
                 where item.Value.HostName.StartsWith(name)
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByName) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Planets: {item.Value.St_PlCount,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByName.Count);
        }

        // Método de pesquisa de estrelas pelo método de descoberta.
        public void SearchByDiscoveryMethod(string name) {
            Facade.starList = filterByDiscoveryMethod; // obrigatório!!!!

            Console.WriteLine("Filtrar pelo nome");

            filterByDiscoveryMethod =
                (from item in filterByDiscoveryMethod
                 where item.Value.DiscoveryMethod.StartsWith(name)
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByDiscoveryMethod) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Discovery method: {item.Value.DiscoveryMethod,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByName.Count);
        }

        // Inicializar as variáveis.
        public StarSearcher() {
            facade = new Facade();
        }
    }
}
