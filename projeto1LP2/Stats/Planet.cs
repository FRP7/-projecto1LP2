using System;

namespace projeto1LP2
{
    struct Planet
    {
        // Nome do planeta.
        public string Pl_Name { get; }

        // Nome da estrela que o planeta orbita.
        public string HostName { get; }

        // Método de descoberta.
        public string DiscoveryMethod { get; }

        // Ano de descoberta.
        public Nullable<int> Disc_Year { get; }

        // Período orbital (em dias).
        public Nullable<double> Pl_Orbper { get; }

        // Raio do planeta (em comparação com a Terra).
        public Nullable<double> Pl_Rade { get; }

        // Massa do planeta (em comparação com a Terra
        public Nullable<double> Pl_Masse { get; }

        // Temperatura do equilíbrio do planeta (em Kelvins).
        public Nullable<int> Pl_Eqt { get; }

        // Temperatura efetiva da estrela (em Kelvins).
        public Nullable<double> St_Teff { get; }

        // Raio da estrela (em comparação com o Sol).
        public Nullable<double> St_Rad { get; }

        // Massa da estrela (em comparação com o Sol).
        public Nullable<double> St_Mass { get; }

        /* Idade da estrela (em Giga-anos, ou seja, por milhar de 
         * milhão de anos).*/
        public Nullable<double> St_Age { get; } 

        // Velocidade de rotação da estrela (em km/s).
        public Nullable<double> St_Vsin { get; } //não tem

        // Período de rotação da estrela (em dias).
        public Nullable<double> St_Rotp { get; } 

        /* Distância entre a Terra e a estrela (em Parsecs, 
         * sendo 1 Parsec ≈ 3,26 anos-luz).*/
        public Nullable<double> Sy_Dist { get; }

        /// <summary>
        /// Inicializar as propriedades.
        /// </summary>
        /// <param name="pl_Name"> Nome do planeta. </param>
        /// <param name="hostName"> Nome da estrela que o planeta orbita. 
        /// </param>
        /// <param name="discoveryMethod"> Método de descoberta. </param>
        /// <param name="disc_Year"> Ano de descoberta. </param>
        /// <param name="pl_Orbper"> Período orbital (em dias). </param>
        /// <param name="pl_Rade"> Raio do planeta (em comparação com a Terra). 
        /// </param>
        /// <param name="pl_Masse"> Massa do planeta (em comparação
        /// com a Terra. </param>
        /// <param name="pl_Eqt"> Temperatura do equilíbrio do planeta
        /// (em Kelvins). </param>
        /// <param name="st_Teff"> Temperatura efetiva da estrela (em Kelvins).
        /// </param>
        /// <param name="st_Rad"> Raio da estrela (em comparação com o Sol). 
        /// </param>
        /// <param name="st_Mass"> Massa da estrela (em comparação com o Sol). 
        /// </param>
        /// <param name="st_Age"> Idade da estrela (em Giga-anos, ou seja, 
        /// por milhar de milhão de anos).</param>
        /// <param name="st_Rotation"> Velocidade de rotação da estrela
        /// (em km/s). </param>
        /// <param name="st_Rotp"> Período de rotação da estrela (em dias). 
        /// </param>
        /// <param name="sy_Dist"> Distância entre a Terra e a estrela 
        /// (em Parsecs, sendo 1 Parsec ≈ 3,26 anos-luz). </param>
        public Planet(string pl_Name, string hostName, string discoveryMethod,
            int? disc_Year, double? pl_Orbper, double? pl_Rade, double? pl_Masse,
            int? pl_Eqt, double? st_Teff, double? st_Rad, double? st_Mass,
            double? st_Age, double? st_Rotation, double? st_Rotp,
            double? sy_Dist) {

            Pl_Name = pl_Name;
            HostName = hostName;
            DiscoveryMethod = discoveryMethod;
            Disc_Year = disc_Year;
            Pl_Orbper = pl_Orbper;
            Pl_Rade = pl_Rade;
            Pl_Masse = pl_Masse;
            Pl_Eqt = pl_Eqt;
            St_Teff = st_Teff;
            St_Rad = st_Rad;
            St_Mass = st_Mass;
            St_Age = st_Age;
            St_Vsin = st_Rotation;
            St_Rotp = st_Rotp;
            Sy_Dist = sy_Dist;
        }
    }
}
