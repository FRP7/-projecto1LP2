using System;

namespace projeto1LP2
{
    struct Star
    {
        // Nome da estrela.
        public string HostName { get; set; }
        // Método de descoberta.
        public string DiscoveryMethod { get; set; }
        // Ano de descoberta.
        public int Disc_Year { get; set; }
        // Temperatura efetiva da estrela (em Kelvins).
        public double St_Teff { get; set; }
        // Raio da estrela (em comparação com o Sol).
        public double St_Rad { get; set; }
        // Massa da estrela (em comparação com o Sol).
        public double St_Mass { get; set; }
        /* Idade da estrela (em Giga-anos, ou seja, por milhar de 
         * milhão de anos).*/
        public double St_Age { get; set; } // Não tem
        // Velocidade de rotação da estrela (em km/s).
        public double St_Vsin { get; set; } //não tem
        // Período de rotação da estrela (em dias).
        public double St_Rotp { get; set; } //não tem.
        /* Distância entre a Terra e a estrela (em Parsecs, 
         * sendo 1 Parsec ≈ 3,26 anos-luz).*/
        public double Sy_Dist { get; set; }
        // Número de planetas lidos que orbitam 
        public int St_PlCount { get; set; }

        public Star(string hostName, string discoveryMethod, int disc_Year, 
            double st_Teff, double st_Rad, double st_Mass, double st_Age, 
            double st_Vsin, double st_Rotp, double sy_Dist, int st_PlCount) {
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
