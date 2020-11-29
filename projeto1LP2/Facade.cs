﻿using System;
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
            FileReader teste = new FileReader("planetList.csv");
            teste.ReadFile();
        }

        // Método que chama método de pesquisa exemplo de planetas.
        public void SearchPlanetsTeste1() {
            PlanetSearcher planetSearcher = new PlanetSearcher();
            planetSearcher.Exemplo1();
        }

        // Método que chama método de pesquisa exemplo de estrelas.
        public void SearchStarsTeste1() {
            StarSearcher starSearcher = new StarSearcher();
            starSearcher.Exemplo1();
        }
    }
}
