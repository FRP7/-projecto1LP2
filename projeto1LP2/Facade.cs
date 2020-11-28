using System;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Classe "Facade" onde se pode aceder ao conteúdo das outras classes.
    /// É a classe "mãe" ou núcleo do programa. É tudo guardado aqui,
    /// incluído o conteúdo do ficheiro.
    /// </summary>
    class Facade
    {
        // Dictionary de planetas.
        public static Dictionary<int, Planet> planetList;
        // Dictionary de estrelas.
        //public static Dictionary<int, Star> starList;
        public static Dictionary<int, Tuple<Star, int>> starList;

        public static Dictionary<int, Tuple<Star, int>> teste;

        public Facade() {
            // Inicializar os dictionaries.
            planetList = new Dictionary<int, Planet>();
            // starList = new Dictionary<int, Star>();
            starList = new Dictionary<int, Tuple<Star, int>>();
        }
    }
}
