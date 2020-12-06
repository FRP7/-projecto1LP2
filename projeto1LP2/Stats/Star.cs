using System;

namespace projeto1LP2
{
    struct Star
    {
        // Nome da estrela.
        public string HostName { get; }

        // Método de descoberta.
        public string DiscoveryMethod { get; }

        // Ano de descoberta.
        public Nullable<int> Disc_Year { get; }

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
        public Nullable<double> St_Vsin { get; } 

        // Período de rotação da estrela (em dias).
        public Nullable<double> St_Rotp { get; } 

        /* Distância entre a Terra e a estrela (em Parsecs, 
         * sendo 1 Parsec ≈ 3,26 anos-luz).*/
        public Nullable<double> Sy_Dist { get; }

        // Número de planetas lidos que orbitam.
        public Nullable<int> St_PlCount { get; }


        /// <summary>
        /// Inicializar as propriedades.
        /// </summary>
        /// <param name="hostName"> Nome da estrela. </param>
        /// <param name="discoveryMethod"> Método de descoberta. </param>
        /// <param name="disc_Year"> Ano de descoberta. </param>
        /// <param name="st_Teff"> Temperatura efetiva da estrela (em Kelvins). 
        /// </param>
        /// <param name="st_Rad"> Raio da estrela (em comparação com o Sol). 
        /// </param>
        /// <param name="st_Mass"> Massa da estrela (em comparação com o Sol). 
        /// </param>
        /// <param name="st_Age"> Idade da estrela (em Giga-anos, ou seja, 
        /// por milhar de milhão de anos). </param>
        /// <param name="st_Vsin"> Velocidade de rotação da estrela (em km/s). </param>
        /// <param name="st_Rotp"> Período de rotação da estrela (em dias). </param>
        /// <param name="sy_Dist"> Distância entre a Terra e a estrela 
        /// (em Parsecs, sendo 1 Parsec ≈ 3,26 anos-luz). </param>
        /// <param name="st_PlCount"> Número de planetas lidos que orbitam. 
        /// </param>
        public Star(string hostName, string discoveryMethod, int? disc_Year, 
            double? st_Teff, double? st_Rad, double? st_Mass, double? st_Age, 
            double? st_Vsin, double? st_Rotp, double? sy_Dist, int? st_PlCount) {

            HostName = hostName;
            DiscoveryMethod = discoveryMethod;
            Disc_Year = disc_Year;
            St_Teff = st_Teff;
            St_Rad = st_Rad;
            St_Mass = st_Mass;
            St_Age = st_Age;
            St_Vsin = st_Vsin;
            St_Rotp = st_Rotp;
            Sy_Dist = sy_Dist;
            St_PlCount = st_PlCount;
        }
    }
}
