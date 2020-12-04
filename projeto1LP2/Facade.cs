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
        public Facade()
        {
            // Inicializar os dictionaries.
            planetList = new Dictionary<int, Planet>();
            starList = new Dictionary<int, Star>();
        }

        // Método que chama método de ler ficheiro no FileReader.
        public void ReadFile()
        {
            FileReader file = new FileReader("planetList.csv");
            file.ReadFile();
        }

        // Método para ler ficheiro atrávez de uma string.
        public void ReadFile(string file)
        {
            FileReader newFile = new FileReader(file);
            newFile.ReadFile();
        }

        // Método que chama método de pesquisa de estrelas pelo nome
        public void SearchByName(string input, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByName(input, isAscending, StarFields.St_Teff);
        }

        // Método que chama método de pesquisa de estrelas pelo método de descoberta
        public void SearchByDiscoveryMethod(string input, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDiscoveryMethod(input, isAscending, fields);
        }

        public void SearchByDiscoveryYear(int ?min, int ?max, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDiscoveryYear(min, max, isAscending, fields);
        }

        public void SearchByTeff(double ?min, double ?max, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByTeff(min, max, isAscending, fields);
        }

        public void SearchByRad(double ?min, double ?max, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByRad(min, max, isAscending, fields);
        }

        public void SearchByMass(double ?min, double ?max, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByMass(min, max, isAscending, fields);
        }

        public void SearchByAge(double ?min, double ?max, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByAge(min, max, isAscending, fields);
        }

        public void SearchByVsin(double ?min, double ?max, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByVsin(min, max, isAscending, fields);
        }

        public void SearchByRtop(double ?min, double ?max, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByRotp(min, max, isAscending, fields);
        }

        public void SearchByDist(double ?min, double ?max, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByDist(min, max, isAscending, fields);
        }

        public void SearchByPlCount(double ?min, double ?max, bool ?isAscending, StarFields fields) {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.SearchByPlCount(min, max, isAscending, fields);
        }

        // Método de pesquisa de planetas pelo nome.
        public void SearchByPlanetName(string name, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetName(name, isAscending);
        }

        // Método de pesquisa de planetas pelo nome das suas estrelas.
        public void SearchByPlanetHostName(string hostname, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostName(hostname, isAscending);
        }

        // Método de pesquisa de planetas pelo método de descoberta.
        public void SearchByPlanetDiscoveryMethod(string discoveryMethod, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetDiscoveryMethod(discoveryMethod, isAscending);
        }

        // Método de pesquisa de planetas pelo ano de descoberta.
        public void SearchByPlanetDiscoveryYear(int? min, int? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetDiscoveryYear(min, max, isAscending);
        }

        // Método de pesquisa de planetas pelo ano de descoberta.
        public void SearchByPlanetOrbitalPeriod(int? min, int? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetOrbitalPeriod(min, max, isAscending);
        }

        // Método de pesquisa de planetas pelo raio.
        public void SearchByPlanetRadius(double? min, double? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetRadius(min, max, isAscending);
        }

        // Método de pesquisa de planetas pelo raio.
        public void SearchByPlanetHostRad(double? min, double? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostRad(min, max, isAscending);
        }

        // Método de pesquisa de planetas pela temperatura de equilibrio.
        public void SearchByPlanetEqt(int? min, int? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetEqt(min, max, isAscending);
        }

        // Método de pesquisa de planetas pela temperatura efetiva da sua estrela.
        public void SearchByPlanetHostTeff(int? min, int? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostTeff(min, max, isAscending);
        }

        // Método de pesquisa de planetas pela massa.
        public void SearchByPlanetMass(double? min, double? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetMass(min, max, isAscending);
        }

        // Método de pesquisa de planetas pela massa da sua estrela.
        public void SearchByPlanetHostMass(double? min, double? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostMass(min, max, isAscending);
        }

        // Método de pesquisa de planetas pela idade da sua estrela.
        public void SearchByPlanetHostAge(int? min, int? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostAge(min, max, isAscending);
        }

        // Método de pesquisa de planetas pela velocidade de rotação da sua estrela.
        public void SearchByPlanetHostVsin(double? min, double? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostVsin(min, max, isAscending);
        }

        // Método de pesquisa de planetas pelo período de rotação da sua estrela.
        public void SearchByPlanetHostRotp(int? min, int? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostRotp(min, max, isAscending);
        }

        // Método de pesquisa de planetas pela distância do sol até a sua estrela.
        public void SearchByPlanetHostDist(double? min, double? max, bool isAscending)
        {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.SearchByPlanetHostDist(min, max, isAscending);
        }
    }
}
