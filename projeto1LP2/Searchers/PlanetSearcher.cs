using System;
using System.Linq;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Classe onde vão estar os métodos de pesquisa de planetas.
    /// </summary>
    class PlanetSearcher
    {
        // Aceder à Facade.
        private Facade facade;
        // Estas variáveis têem obrigatoriamente de serem inicializadas aqui!
        private Dictionary<int, Planet> filterByName =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByHostName =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByDiscoveryMethod =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByDiscoveryYear =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByOrbitalPeriod =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByRadius =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByMass =
            new Dictionary<int, Planet>(Facade.planetList);

        // Método de pesquisa de planetas pelo nome.
        public void SearchByPlanetName(string input)
        {
            Facade.planetList = filterByName; // obrigatório!!!!

            Console.WriteLine("Filter by name");

            if (input != null)
            {
                filterByName =
                    (from item in filterByName
                     where item.Value.Pl_Name.StartsWith(input.ToUpper())
                     select item).ToDictionary(p => p.Key, p => p.Value);

                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByName)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByName)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.HostName,-30}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByName.Count);
        }

        // Método de pesquisa de planetas pelo nome das suas estrelas.
        public void SearchByPlanetHostName(string input)
        {
            Facade.planetList = filterByHostName; // obrigatório!!!!

            Console.WriteLine("Filter by host star");

            if (input != null)
            {
                filterByHostName =
                    (from item in filterByHostName
                     where item.Value.HostName.StartsWith(input.ToUpper())
                     select item).ToDictionary(p => p.Key, p => p.Value);

                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostName)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Star: {item.Value.HostName,-30}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostName)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Star: {item.Value.HostName,-30}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByHostName.Count);
        }

        // Método de pesquisa de planetas pelo método de descoberta.
        public void SearchByPlanetDiscoveryMethod(string input)
        {
            Facade.planetList = filterByDiscoveryMethod; // obrigatório!!!!

            Console.WriteLine("Filter by discovery method");

            if (input != null)
            {
                filterByDiscoveryMethod =
                    (from item in filterByDiscoveryMethod
                     where item.Value.DiscoveryMethod.StartsWith(input.ToUpper())
                     select item).ToDictionary(p => p.Key, p => p.Value);

                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryMethod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery method: {item.Value.DiscoveryMethod,-20}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryMethod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery method: {item.Value.DiscoveryMethod,-20}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByDiscoveryMethod.Count);
        }

        // Método de pesquisa de planetas pelo ano de descoberta.
        public void SearchByPlanetDiscoveryYear(int? min, int? max)
        {
            Facade.planetList = filterByDiscoveryYear; // obrigatório!!!!

            Console.WriteLine("Filter by discovery year");

            if (min == null && max != null)
            {
                filterByDiscoveryYear =
               (from item in filterByDiscoveryYear
                where item.Value.Disc_Year < max
                select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryYear)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-4}"));
                }
            }
            else if (min != null && max == null)
            {
                filterByDiscoveryYear =
               (from item in filterByDiscoveryYear
                where item.Value.Disc_Year > min
                select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryYear)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-4}"));
                }
            }
            else if (min != null && max != null)
            {
                filterByDiscoveryYear =
              (from item in filterByDiscoveryYear
               where item.Value.Disc_Year > min && item.Value.Disc_Year < max
               select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryYear)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-4}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryYear)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-4}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByDiscoveryYear.Count);
        }

        // Método de pesquisa de planetas pelo periodo de orbita.
        public void SearchByPlanetOrbitalPeriod(int? min, int? max)
        {
            Facade.planetList = filterByOrbitalPeriod; // obrigatório!!!!

            Console.WriteLine("Filter by orbital period");

            if (min == null && max != null)
            {
                filterByOrbitalPeriod =
               (from item in filterByOrbitalPeriod
                where item.Value.Pl_Orbper < max
                select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByOrbitalPeriod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Orbital Period: {item.Value.Pl_Orbper,-5}"));
                }
            }
            else if (min != null && max == null)
            {
                filterByOrbitalPeriod =
               (from item in filterByOrbitalPeriod
                where item.Value.Pl_Orbper > min
                select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByOrbitalPeriod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Orbital Period: {item.Value.Pl_Orbper,-5}"));
                }
            }
            else if (min != null && max != null)
            {
                filterByOrbitalPeriod =
              (from item in filterByOrbitalPeriod
               where item.Value.Pl_Orbper > min && item.Value.Pl_Orbper < max
               select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByOrbitalPeriod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Orbital Period: {item.Value.Pl_Orbper,-5}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByOrbitalPeriod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Orbital Period: {item.Value.Pl_Orbper,-5}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByOrbitalPeriod.Count);
        }

        // Método de pesquisa de planetas pelo raio.
        public void SearchByPlanetRadius(double? min, double? max)
        {
            Facade.planetList = filterByRadius; // obrigatório!!!!

            Console.WriteLine("Filter by radius");

            if (min == null && max != null)
            {
                filterByRadius =
               (from item in filterByRadius
                where item.Value.Pl_Rade < max
                select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByRadius)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Radius: {item.Value.Pl_Rade,-3}"));
                }
            }
            else if (min != null && max == null)
            {
                filterByRadius =
               (from item in filterByRadius
                where item.Value.Pl_Rade > min
                select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByRadius)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Radius: {item.Value.Pl_Rade,-3}"));
                }
            }
            else if (min != null && max != null)
            {
                filterByRadius =
              (from item in filterByRadius
               where item.Value.Pl_Rade > min && item.Value.Pl_Rade < max
               select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByRadius)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Radius: {item.Value.Pl_Rade,-3}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByRadius)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Radius: {item.Value.Pl_Rade,-3}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByRadius.Count);
        }

        // Método de pesquisa de planetas pela massa.
        public void SearchByPlanetMass(double? min, double? max)
        {
            Facade.planetList = filterByMass; // obrigatório!!!!

            Console.WriteLine("Filter by mass");

            if (min == null && max != null)
            {
                filterByMass =
               (from item in filterByMass
                where item.Value.Pl_Masse < max
                select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Mass: {item.Value.Pl_Masse,-3}"));
                }
            }
            else if (min != null && max == null)
            {
                filterByMass =
               (from item in filterByMass
                where item.Value.Pl_Masse > min
                select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Mass: {item.Value.Pl_Masse,-3}"));
                }
            }
            else if (min != null && max != null)
            {
                filterByMass =
              (from item in filterByMass
               where item.Value.Pl_Masse > min && item.Value.Pl_Masse < max
               select item).ToDictionary(p => p.Key, p => p.Value);
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Mass: {item.Value.Pl_Masse,-3}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Mass: {item.Value.Pl_Masse,-3}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByMass.Count);
        }

        // Inicializar as variáveis.
        public PlanetSearcher() {
            facade = new Facade();
        }
    }
}
