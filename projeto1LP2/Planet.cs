using System;

namespace projeto1LP2
{
    struct Planet
    {
        // Nome do planeta.
        public string Pl_Name { get; set; }
        // Nome da estrela que o planeta orbita.
        public string HostName { get; set; }
        // Método de descoberta.
        public string DiscoveryMethod { get; set; }
        // Ano de descoberta.
        public int Disc_Year { get; set; }
        // Período orbital (em dias).
        public double Pl_Orbper { get; set; }
        // Raio do planeta (em comparação com a Terra).
        public double Pl_Rade { get; set; }
        // Massa do planeta (em comparação com a Terra
        public double Pl_Masse { get; set; }
        // Temperatura do equilíbrio do planeta (em Kelvins).
        public int Pl_Eqt { get; set; }
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


        public Planet(string pl_Name, string hostName, string discoveryMethod,
            int disc_Year, double pl_Orbper, double pl_Rade, double pl_Masse,
            int pl_Eqt, double st_Teff, double st_Rad, double st_Mass,
            double st_Age, double st_Rotation, double st_Rotp,
            double sy_Dist) {
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
