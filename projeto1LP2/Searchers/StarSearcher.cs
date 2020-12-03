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
        private Dictionary<int, Star> filterByName =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByDiscoveryMethod =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByDiscoveryYear =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByTaff =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByRad =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByMass =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByAge =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByVsin =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByRotp =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByDyst =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByPlCount =
            new Dictionary<int, Star>(Facade.starList);

        // Método de pesquisa de estrelas pelo nome.
        public void SearchByName(string input) {
            Facade.starList = filterByName; // obrigatório!!!!

            Console.WriteLine("Filtrar pelo nome");

            filterByName =
                (from item in filterByName
                     where item.Value.HostName.StartsWith(input.ToUpper())
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
                 where item.Value.DiscoveryMethod.StartsWith(input.ToUpper())
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByDiscoveryMethod) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Discovery method: {item.Value.DiscoveryMethod,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByDiscoveryMethod.Count);
        }

        // Método de pesquisa de estrelas pelo ano de descoberta.
        public void SearchByDiscoveryYear(int min, int max) {
            Facade.starList = filterByDiscoveryYear; // obrigatório!!!!

            Console.WriteLine("Filtrar pelo ano de descoberta");

            filterByDiscoveryYear =
                (from item in filterByDiscoveryYear
                 where item.Value.Disc_Year > min && item.Value.Disc_Year < max
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByDiscoveryYear) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Discovery year: {item.Value.Disc_Year,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByDiscoveryYear.Count);
        }

        // Método de pesquisa de estrelas pela temperatura.
        public void SearchByTeff(double min, double max) {
            Facade.starList = filterByTaff; // obrigatório!!!!

            Console.WriteLine("Filtrar pela temperatura");

            filterByTaff =
                (from item in filterByTaff
                 where item.Value.St_Teff > min && item.Value.St_Teff < max
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByTaff) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Temperature: {item.Value.St_Teff,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByTaff.Count);
        }

        // Método de pesquisa de estrelas pelo raio.
        public void SearchByRad(double min, double max) {
            Facade.starList = filterByRad; // obrigatório!!!!

            Console.WriteLine("Filtrar pelo raio");

            filterByRad =
                (from item in filterByRad
                 where item.Value.St_Rad > min && item.Value.St_Rad < max
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByRad) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Radius: {item.Value.St_Rad,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByRad.Count);
        }

        // Método de pesquisa de estrelas pela massa.
        public void SearchByMass(double min, double max) {
            Facade.starList = filterByMass; // obrigatório!!!!

            Console.WriteLine("Filtrar pela massa");

            filterByMass =
                (from item in filterByMass
                 where item.Value.St_Mass > min && item.Value.St_Mass < max
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByMass) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Mass: {item.Value.St_Mass,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByMass.Count);
        }

        // Método de pesquisa de estrelas pela idade.
        public void SearchByAge(double min, double max) {
            Facade.starList = filterByAge; // obrigatório!!!!

            Console.WriteLine("Filtrar pela idade");

            filterByAge =
                (from item in filterByAge
                 where item.Value.St_Age > min && item.Value.St_Age < max
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByAge) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Age: {item.Value.St_Age,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByAge.Count);
        }

        // Método de pesquisa de estrelas pela velocidade de rotação.
        public void SearchByVsin(double min, double max) {
            Facade.starList = filterByVsin; // obrigatório!!!!

            Console.WriteLine("Filtrar pela velocidade de rotação");

            filterByVsin =
                (from item in filterByVsin
                 where item.Value.St_Vsin > min && item.Value.St_Vsin < max
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByVsin) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Rotation velocity: {item.Value.St_Vsin,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByVsin.Count);
        }

        // Método de pesquisa de estrelas pelo período de rotação.
        public void SearchByRotp(double min, double max) {
            Facade.starList = filterByRotp; // obrigatório!!!!

            Console.WriteLine("Filtrar pelo período de rotação");

            filterByRotp =
                (from item in filterByRotp
                 where item.Value.St_Rotp > min && item.Value.St_Rotp < max
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByRotp) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Rotation period: {item.Value.St_Rotp,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByRotp.Count);
        }

        // Método de pesquisa de estrelas pela distância.
        public void SearchByDist(double min, double max) {
            Facade.starList = filterByDyst; // obrigatório!!!!

            Console.WriteLine("Filtrar pela distância");

            filterByDyst =
                (from item in filterByDyst
                 where item.Value.Sy_Dist > min && item.Value.Sy_Dist < max
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByDyst) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Distance: {item.Value.Sy_Dist,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByDyst.Count);
        }

        // Método de pesquisa de estrelas pela quantidade de planetas.
        public void SearchByPlCount(double min, double max) {
            Facade.starList = filterByPlCount; // obrigatório!!!!

            Console.WriteLine("Filtrar pelo número de planetas");

            filterByPlCount =
                (from item in filterByPlCount
                 where item.Value.St_PlCount > min && item.Value.St_PlCount < max
                 select item).ToDictionary(p => p.Key, p => p.Value);

            // Imprimir
            foreach (KeyValuePair<int, Star> item in filterByPlCount) {
                Console.WriteLine(string.Format($"ID: " +
                    $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                 $" | Planet count: {item.Value.St_PlCount,-2}"));
            }
            Console.WriteLine("Dicionário filtro: " + filterByPlCount.Count);
        }

        // Inicializar as variáveis.
        public StarSearcher() {
            facade = new Facade();
        }
    }
}
