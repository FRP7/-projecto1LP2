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
        private Dictionary<int, Star> filter = Facade.starList;

        // Método exemplo de pesquisa de estrelas.
        public void SearchByName(string name) {

            Console.WriteLine("Filtrar pelo nome");

            // Filtro
            filter = filter.Where(p => p.Value.HostName.StartsWith(name))
                .ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filter) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Planets: {item.Value.St_PlCount,-2}"));
            }
        }

        // Inicializar as variáveis.
        public StarSearcher() {
            facade = new Facade();
        }
    }
}
