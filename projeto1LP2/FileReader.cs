using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace projeto1LP2
{
    /// <summary>
    /// Classe onde o ficheiro é lido e guardado numa coleção.
    /// </summary>
    class FileReader
    {
        // Nome do ficheiro.
        private const string fileName = "planetList.csv";
        // Inicializar a coleção.
        Facade facade = new Facade();
        // Contar as linhas.
        private int lineCount = 0;

        // Método de leitura do ficheiro.
        public void ReadFile() {
            // Método de leitura de planetas e seus respetivos campos.
            GetPlanets();
        }

        // Método de leitura de planetas e seus respetivos campos.
        private void GetPlanets() {
            // Conteúdo do ficheiro.
            string content = "";
            // Linhas do ficheiro.
            string[] lines;

            // Variáveis dos campos de interesse.
            string planetName = "";
            string starName = "";
            string discoveryMethodName = "";
            int discoveryYear = 0;
            double orbitalPeriod = 0;
            double planetRade = 0;
            double planetMasse = 0;
            int planetTemp = 0;
            double starTemp = 0;
            double starRade = 0;
            double starMass = 0;
            double starAge = 0;
            double starRotation = 0;
            double starRotp = 0;
            double starDistance = 0;

            // Variáveis de iteração.
            int indexPlanet = 0;
            int indexStar = 0;
            int indexDiscoveryMethod = 0;
            int indexDiscoveryYear = 0;
            int indexOrbitalPeriod = 0;
            int indexP1Rade = 0;
            int indexP1Masse = 0;
            int indexPlEqt = 0;
            int indexStTeff = 0;
            int indexStRad = 0;
            int indexStMass = 0;
            int indexStAge = 0;
            int indexStRotation = 0;
            int indexStRotp = 0;
            int indexStDist = 0;

            // Tentar ler ficheiro.
            try {
                using (StreamReader sr = File.OpenText(fileName)) {
                    lineCount = File.ReadLines(fileName).Count();

                    // Passar à frente as primeiras linhas
                    for (int i = 0; i < 48; i++) {
                        content = sr.ReadLine();
                    }
                    // Dividir a linha e colocar cada campo na array
                    lines = new string[content.Length];
                    lines = content.Split(',');
                    // 

                    // Identificar o index dos campos desejados
                    for (int i = 0; i < lines.Length; i++) {
                        if (lines[i].Contains("pl_name")) {
                            indexPlanet = i;
                        }
                        if (lines[i].Contains("hostname")) {
                            indexStar = i;
                        }
                        if (lines[i].Contains("discoverymethod")) {
                            indexDiscoveryMethod = i;
                        }
                        if (lines[i].Contains("disc_year")) {
                            indexDiscoveryYear = i;
                        }
                        if (lines[i].Contains("pl_orbper")) {
                            indexOrbitalPeriod = i;
                        }
                        if (lines[i].Contains("pl_rade")) {
                            indexP1Rade = i;
                        }
                        if (lines[i].Contains("pl_bmasse")) {
                            indexP1Masse = i;
                        }
                        if (lines[i].Contains("pl_eqt")) {
                            indexPlEqt = i;
                        }
                        if (lines[i].Contains("st_teff")) {
                            indexStTeff = i;
                        }
                        if (lines[i].Contains("st_rad")) {
                            indexStRad = i;
                        }
                        if (lines[i].Contains("st_mass")) {
                            indexStMass = i;
                        }
                        if (lines[i].Contains("st_age")) {
                            indexStAge = i;
                        }
                        if (lines[i].Contains("st_vsin")) {
                            indexStRotation = i;
                        }
                        if (lines[i].Contains("st_rotp")) {
                            indexStRotp = i;
                        }
                        if (lines[i].Contains("sy_dist")) {
                            indexStDist = i;
                        }
                    }

                    // Verificar os valores dos campos.
                    for (int i = 0; i < lineCount - 48; i++) {
                        // Ler o ficheiro.
                        content = sr.ReadLine();
                        // Separar os campos.
                        if (content != null) {
                            lines = content.Split(',');
                        }
                        /* Ler os campos de interesse e colocar nas respetivas
                         * variáveis.*/
                        planetName = lines[indexPlanet];
                        starName = lines[indexStar];
                        discoveryMethodName = lines[indexDiscoveryMethod];
                        if (int.TryParse(lines[indexDiscoveryYear], NumberStyles.Any, CultureInfo.InvariantCulture, out discoveryYear)) {
                        } else {
                            discoveryYear = 0;
                        }
                        if (double.TryParse(lines[indexOrbitalPeriod], NumberStyles.Any ,CultureInfo.InvariantCulture ,out orbitalPeriod)) {
                        }
                        else {
                            orbitalPeriod = 0;
                        }
                        if (double.TryParse(lines[indexP1Rade], NumberStyles.Any, CultureInfo.InvariantCulture, out planetRade)) {
                        } else {
                            planetRade = 0;
                        }
                        if (double.TryParse(lines[indexP1Masse], NumberStyles.Any, CultureInfo.InvariantCulture, out planetMasse)) {
                        } else {
                            planetMasse = 0;
                        }
                        if (int.TryParse(lines[indexPlEqt], NumberStyles.Any, CultureInfo.InvariantCulture, out planetTemp)) {
                        } else {
                            planetTemp = 0;
                        }
                        if (double.TryParse(lines[indexStTeff], NumberStyles.Any, CultureInfo.InvariantCulture, out starTemp)) {
                        } else {
                            starTemp = 0;
                        }
                        if (double.TryParse(lines[indexStRad], NumberStyles.Any, CultureInfo.InvariantCulture, out starRade)) {
                        } else {
                            starRade = 0;
                        }
                        if (double.TryParse(lines[indexStMass], NumberStyles.Any, CultureInfo.InvariantCulture, out starMass)) {
                        } else {
                            starMass = 0;
                        }
                        if (double.TryParse(lines[indexStAge], NumberStyles.Any, CultureInfo.InvariantCulture, out starAge)) {
                        } else {
                            starAge = 0;
                        }
                        if (double.TryParse(lines[indexStRotation], NumberStyles.Any, CultureInfo.InvariantCulture, out starRotation)) {
                        } else {
                            starRotation = 0;
                        }
                        if (double.TryParse(lines[indexStRotp], NumberStyles.Any, CultureInfo.InvariantCulture, out starRotp)) {
                        } else {
                            starRotp = 0;
                        }
                        if (double.TryParse(lines[indexStDist], NumberStyles.Any, CultureInfo.InvariantCulture, out starDistance)) {
                        } else {
                            starDistance = 0;
                        }

                        // Colocar os valores no dicionário dos planetas.
                        Facade.planetList.Add(
                           i, new Types(
                           pl_Name: planetName,
                           hostName: starName,
                           discoveryMethod: discoveryMethodName,
                           disc_Year: discoveryYear,
                           p1_Orbper: orbitalPeriod,
                           p1_Rade: planetRade,
                           p1_Masse: planetMasse,
                           pl_Eqt: planetTemp,
                           st_Teff: starTemp,
                           st_Rad: starRade,
                           st_Mass: starMass,
                           st_Age: starAge,
                           st_Rotation: starRotation,
                           st_Rotp: starRotp,
                           sy_Dist: starDistance
                           )
                       );
                    }
                }
                // debug pa testes, delete later
                Console.WriteLine(Facade.planetList.Count);
                Console.WriteLine(Facade.planetList[0].Pl_Name);
                Console.WriteLine(Facade.planetList[0].HostName);
                Console.WriteLine(Facade.planetList[0].DiscoveryMethod);
                Console.WriteLine(Facade.planetList[0].Disc_Year);
                Console.WriteLine(Facade.planetList[0].P1_Orbper);
                Console.WriteLine(Facade.planetList[0].P1_Rade);
                Console.WriteLine(Facade.planetList[0].P1_Masse);
                Console.WriteLine(Facade.planetList[0].Pl_Eqt);
                Console.WriteLine(Facade.planetList[0].St_Teff);
                Console.WriteLine(Facade.planetList[0].St_Rad);
                Console.WriteLine(Facade.planetList[0].St_Mass);

                if(Facade.planetList[0].St_Age == 0) {
                    Console.WriteLine("Informação não disponível");
                }
                if (Facade.planetList[0].St_Vsin == 0) {
                    Console.WriteLine("Informação não disponível");
                }
                if (Facade.planetList[0].St_Rotp == 0) {
                    Console.WriteLine("Informação não disponível");
                }
                Console.WriteLine(Facade.planetList[0].Sy_Dist);
            }
            // Caso não consiga ler o ficheiro.
            catch (Exception message) {
                Console.WriteLine("Ocorreu o seguinte problema: " +
                    message.Message);
            }
        }
    }
}
