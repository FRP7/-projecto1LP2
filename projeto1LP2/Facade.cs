using System;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Classe "Facade" onde se pode aceder ao conteúdo das outras classes.
    /// É a classe "mãe" ou núcleo do programa. É tudo guardado aqui,
    /// incluído o conteúdo do ficheiro.
    /// Sempre que for necessário aceder a alguma classe, acedemos por aqui.
    /// </summary>
    class Facade
    {
        // Dictionary de planetas.
        public static Dictionary<int, Planet> planetList;
        // Dictionary de estrelas.
        public static Dictionary<int, Star> starList;

        // Inicializar variáveis.
        public Facade() {
            // Inicializar os dictionaries.
            planetList = new Dictionary<int, Planet>();
            starList = new Dictionary<int, Star>();
        }

        // Método que chama método de ler ficheiro no FileReader.
        public void ReadFile() {
            FileReader file = new FileReader("planetList.csv");
            file.ReadFile();
        }

        // Método para ler ficheiro atrávez de uma string.
        public void ReadFile(string file) {
            FileReader newFile = new FileReader(file);
            newFile.ReadFile();
        }

        // Método que chama método de pesquisa exemplo de planetas.
        public void SearchPlanetsTeste1() {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.Exemplo1();
        }

        // Método que chama método de pesquisa de estrelas pelo nome
        public void SearchByName(string input) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByName(input);
        }

        // Método que chama método de pesquisa de estrelas pelo método de descoberta
        public void SearchByDiscoveryMethod(string input) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDiscoveryMethod(input);
        }

        public void SearchByDiscoveryYear(int input) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDiscoveryYear(input);
        }

        public void SearchByTeff(double input) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByTeff(input);
        }

        public void SearchByRad(double input) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByRad(input);
        }
    }
}
