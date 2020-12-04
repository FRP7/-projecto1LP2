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
        public void SearchByName(string input, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByName(input, isAscending);
        }

        // Método que chama método de pesquisa de estrelas pelo método de descoberta
        public void SearchByDiscoveryMethod(string input, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDiscoveryMethod(input, isAscending);
        }

        public void SearchByDiscoveryYear(int ?min, int ?max, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDiscoveryYear(min, max, isAscending);
        }

        public void SearchByTeff(double ?min, double ?max, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByTeff(min, max, isAscending);
        }

        public void SearchByRad(double ?min, double ?max, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByRad(min, max, isAscending);
        }

        public void SearchByMass(double ?min, double ?max, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByMass(min, max, isAscending);
        }

        public void SearchByAge(double ?min, double ?max, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByAge(min, max, isAscending);
        }

        public void SearchByVsin(double ?min, double ?max, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByVsin(min, max, isAscending);
        }

        public void SearchByRtop(double ?min, double ?max, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByRotp(min, max, isAscending);
        }

        public void SearchByDist(double ?min, double ?max, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDist(min, max, isAscending);
        }

        public void SearchByPlCount(double ?min, double ?max, bool ?isAscending) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByPlCount(min, max, isAscending);
        }
    }
}
