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
        private Dictionary<int, Star> filterByDiscoveryYear = new Dictionary<int, Star>(Facade.starList);

        // Método de pesquisa de estrelas pelo nome.
        public void SearchByName(string input) {
            Facade.starList = filterByName; // obrigatório!!!!

            Console.WriteLine("Filtrar pelo nome");

            filterByName =
                (from item in filterByName
                 where item.Value.HostName.StartsWith(input)
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
        public void SearchByDiscoveryMethod(string input) {
            Facade.starList = filterByDiscoveryMethod; // obrigatório!!!!

            Console.WriteLine("Filtrar pelo método de descoberta");

            filterByDiscoveryMethod =
                (from item in filterByDiscoveryMethod
                 where item.Value.DiscoveryMethod.StartsWith(input)
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByDiscoveryMethod) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Discovery method: {item.Value.DiscoveryMethod,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByName.Count);
        }

        public void SearchByDiscoveryYear(int input) {
            Facade.starList = filterByDiscoveryMethod; // obrigatório!!!!

            Console.WriteLine("Filtrar pelo ano de descoberta");

            filterByDiscoveryMethod =
                (from item in filterByDiscoveryMethod
                 where item.Value.Disc_Year == input
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByDiscoveryMethod) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Discovery year: {item.Value.Disc_Year,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByName.Count);
        }

        public void SearchByTeff(double input) {
            Facade.starList = filterByDiscoveryMethod; // obrigatório!!!!

            Console.WriteLine("Filtrar pela temperatura");

            filterByDiscoveryMethod =
                (from item in filterByDiscoveryMethod
                 where item.Value.St_Teff == input
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByDiscoveryMethod) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Temperature: {item.Value.St_Teff,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByName.Count);
        }

        public void SearchByRad(double input) {
            Facade.starList = filterByDiscoveryMethod; // obrigatório!!!!

            Console.WriteLine("Filtrar pela temperatura");

            filterByDiscoveryMethod =
                (from item in filterByDiscoveryMethod
                 where item.Value.St_Rad == input
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByDiscoveryMethod) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Radius: {item.Value.St_Rad,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByName.Count);
        }

        // Inicializar as variáveis.
        public StarSearcher() {
            facade = new Facade();
        }
    }
}
