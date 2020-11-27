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
        private const string fileName = "planetList.csv";
        Facade facade = new Facade();
        private int lineCount = 0;
        //private string teste;

        public void ReadFile() {
            /*StreamReader sr = File.OpenText(fileName);
            teste = sr.ReadToEnd();
            Console.WriteLine(teste);
            sr.Close();*/
            /*using(StreamReader sr = File.OpenText(fileName)) {
            }*/
            /*Facade facade = new Facade();
            Facade.planetList.Add(
                0,
                new Types(
                    teste: "Hello World"
                    )
                );*/
            ValidatyCheck();
        }

        private bool ValidatyCheck() {
            string content = "";
            string[] lines;
            string planetName = "";
            string starName = "";
            string discoveryMethodName = "";
            int discoveryYear = 0;
            double orbitalPeriod = 0;
            double planetRade = 0;
            double planetMasse = 0;
            int planetTemp = 0;
            int indexPlanet = 0;
            int indexStar = 0;
            int indexDiscoveryMethod = 0;
            int indexDiscoveryYear = 0;
            int indexOrbitalPeriod = 0;
            int indexP1Rade = 0;
            int indexP1Masse = 0;
            int indexPlEqt = 0;
            try {
                using (StreamReader sr = File.OpenText(fileName)) {
                    lineCount = File.ReadLines(fileName).Count();
                    /*// Passar à frente as primeiras linhas
                    for(int i = 0; i < 47; i++) {
                        line = sr.ReadLine();
                    }
                    line = "";
                    // Ler em linha horizontal as colunas e filtrar
                    line = sr.ReadLine();
                    if(line.Contains("pl_name") == true &&
                        line.Contains("hostname") == true) {
                        /*Facade.planetList.Add(
                        0,
                        new Types(
                            pl_name: "pl_name",
                            hostname: "hostname"
                        )
                        );*/
                    //}
                    // Passar à frente as primeiras linhas
                    for (int i = 0; i < 48; i++) {
                        content = sr.ReadLine();
                    }
                    // Dividir a linha e colocar cada coluna na array
                    lines = new string[content.Length];
                    lines = content.Split(',');
                    // 

                    // Identificar o index das colunas desejadas
                    for (int i = 0; i < lines.Length; i++) {
                        if (lines[i].Contains("pl_name")) {
                            indexPlanet = i;
                        }
                        //planetName = lines[indexPlanet];
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
                        //starName = lines[indexStar];
                    }

                    // Verificar os campos abaixo
                    for (int i = 0; i < lineCount - 48; i++) {
                        content = sr.ReadLine();
                        //lines = content.Split(',');
                        if (content != null) {
                            lines = content.Split(',');
                        }
                        planetName = lines[indexPlanet];
                        starName = lines[indexStar];
                        discoveryMethodName = lines[indexDiscoveryMethod];
                        if (int.TryParse(lines[indexDiscoveryYear], NumberStyles.Any, CultureInfo.InvariantCulture, out discoveryYear)) {
                        } else {
                            discoveryYear = 0;
                        }
                        //orbitalPeriod = Convert.ToSingle(lines[indexOrbitalPeriod]);
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
                        /*Console.WriteLine($"Iteração {i}. " +
                            $"Planeta: {lines[indexPlanet]}. " +
                            $"Estrela: {lines[indexStar]}");*/
                        //Console.WriteLine($"Iteração {i}. Campo: {lines[indexPlanet]}");
                        // Colocar os valores no dicionário
                        Facade.planetList.Add(
                           i, new Types(
                           pl_Name: planetName,
                           hostName: starName,
                           discoveryMethod: discoveryMethodName,
                           disc_Year: discoveryYear,
                           p1_Orbper: orbitalPeriod,
                           p1_Rade: planetRade,
                           p1_Masse: planetMasse,
                           pl_Eqt: planetTemp
                           )
                       );
                    }

                    /*// Colocar os valores no dicionário
                    Facade.planetList.Add(
                        0,
                        new Types(
                            pl_name: planetName,
                            hostname: starName
                            )
                        );*/

                    // teste, delete later
                    //Console.WriteLine(planetName);
                    //Console.WriteLine(starName);
                    /*foreach(string item in lines) {
                        Console.WriteLine(item);
                    }*/
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

                return true;
            }
            catch (Exception message) {
                Console.WriteLine("Ocorreu o seguinte problema: " +
                    message.Message);
                return false;
            }
        }
    }
}
