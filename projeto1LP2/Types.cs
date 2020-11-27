using System;

namespace projeto1LP2
{
    struct Types
    {
        // Nome do planeta.
        public string Pl_Name { get; set; }
        // Nome da estrela que o planeta orbita.
        public string HostName { get; set; }
        // Método de descoberta.
        public string DiscoveryMethod { get; set; }
        // Ano de descoberta
        public int Disc_Year { get; set; }
        // Período orbital (em dias)
        public double P1_Orbper { get; set; }
        /*
        // Período orbital (em dias).
        public float Pl_Orbper { get; set; } 
        // Raio do planeta (em comparação com a Terra).
        public float Pl_Rade { get; set; } 
         // Massa do planeta (em comparação com a Terra).
        public float Pl_Masse { get; set; } 
        // Temperatura do equilíbrio do planeta (em Kelvins).
        public int Pl_Eqt { get; set; } 
        // Temperatura efetiva da estrela (em Kelvins).
        public float St_Teff { get; set; } 
        // Raio da estrela (em comparação com o Sol).
        public float St_Rad { get; set; } 
        // Massa da estrela (em comparação com o Sol).
        public float St_Mass { get; set; }*/
        /* Idade da estrela (em Giga-anos, ou seja, por milhar de 
         * milhão de anos).*/
        /*public float St_Age { get; set; } //não tem
        // Velocidade de rotação da estrela (em km/s).
        public float St_Vsin { get; set; } //não tem
        // Período de rotação da estrela (em dias).
        public float St_Rotp { get; set; } //não tem.
        /* Distância entre a Terra e a estrela (em Parsecs, 
         * sendo 1 Parsec ≈ 3,26 anos-luz).*/
        //public float Sy_Dist { get; set; } 

        /*// Construtor onde são inicializadas as variáveis.
        public Types(string pl_name, string hostname, string discoverymethod,
            int disc_year, float pl_orbper, float pl_rade, float pl_masse, 
            int pl_eqt, float st_teff, float st_rad, float st_mass, 
            float st_age, float st_vsin, float st_rotp, float sy_dist) {

            Pl_Name = pl_name;
            HostName = hostname;
            DiscoveryMethod = discoverymethod;
            Disc_Year = disc_year;
            Pl_Orbper = pl_orbper;
            Pl_Rade = pl_rade;
            Pl_Masse = pl_masse;
            Pl_Eqt = pl_eqt;
            St_Teff = st_teff;
            St_Rad = st_rad;
            St_Mass = st_mass;
            St_Age = st_age;
            St_Vsin = st_vsin;
            St_Rotp = st_rotp;
            Sy_Dist = sy_dist;
        }*/

        public Types(string pl_Name, string hostName, string discoveryMethod, int disc_Year, double p1_Orbper) {
            Pl_Name = pl_Name;
            HostName = hostName;
            DiscoveryMethod = discoveryMethod;
            Disc_Year = disc_Year;
            P1_Orbper = p1_Orbper;
        }
    }
}
