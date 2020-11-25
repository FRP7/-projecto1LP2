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
        public Dictionary<string, Types> planetList;

        public Facade() {
            planetList = new Dictionary<string, Types>();
        }
    }
}
