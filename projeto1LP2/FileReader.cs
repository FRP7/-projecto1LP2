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
        private string fileName;
        // Aceder à coleção.
        Facade facade;
        // Contar as linhas.
        private int lineCount;

        // Método de leitura do ficheiro.
        public void ReadFile() {
            // Método que verifica se o ficheiro pode ser lido.
            if (CanItRead() == true) {
                // Método de leitura de planetas e seus respetivos campos.
                ReadData();
            } else {
                Console.WriteLine("O ficheiro não pode ser lido");
            }
        }

        // Método que verifica se o ficheiro pode ser lido.
        private bool CanItRead() {
            // Indicar se existe a coluna do planeta.
            bool planetName = false;
            // Indicar se existe a coluna da estrela.
            bool starName = false;
            // Indicar se existem ambas as colunas.
            bool itExists = false;

            // Tentar ler o ficheiro
            try {
                // Conteúdo do ficheiro.
                string content = "";
                // Linhas do ficheiro.
                string[] lines;

                // Ler ficheiro.
                using (StreamReader sr = File.OpenText(fileName)) {
                    lineCount = File.ReadLines(fileName).Count();

                    // Passar à frente as primeiras linhas.
                    for (int i = 0; i < 48; i++) {
                        content = sr.ReadLine();
                    }
                    // Dividir a linha e colocar cada campo na array.
                    lines = new string[content.Length];
                    lines = content.Split(',');
                    // 

                    // Verificar se os campos obrigatórios existem.
                    for (int i = 0; i < lines.Length; i++) {
                        if (lines[i].Contains("pl_name")) {
                            planetName = true;
                        }
                        if (lines[i].Contains("hostname")) {
                            starName = true;
                        }
                    }

                    if(planetName == true && starName == true) {
                        itExists = true;
                    }

                }
                return itExists;
            }
            // Caso não consiga ler o ficheiro.
            catch (Exception message) {
                Console.WriteLine("Ocorreu o seguinte problema: " +
                    message.Message);
                itExists = false;
                return itExists;
            }
        }

        // Método de leitura de planetas e seus respetivos campos.
        private void ReadData() {
            // Tentar ler ficheiro.
            try {
                // Método de leitura de planetas.
                GetPlanets();
                // Método de leitura de estrelas.
                GetStars();
            }
            // Caso não consiga ler o ficheiro.
            catch (Exception message) {
                Console.WriteLine("Ocorreu o seguinte problema: " +
                    message.Message);
            }
        }

        // Método de leitura de planetas.
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

            // Variável array de iteração.
            int[] index = new int[15];

            // Definir o valor dos elementos para zero.
            for (int i = 0; i < index.Length; i++) {
                index[i] = 0;
            }

            // Ler ficheiro.
            using (StreamReader sr = File.OpenText(fileName)) {
                lineCount = File.ReadLines(fileName).Count();

                // Passar à frente as primeiras linhas.
                for (int i = 0; i < 48; i++) {
                    content = sr.ReadLine();
                }
                // Dividir a linha e colocar cada campo na array.
                lines = new string[content.Length];
                lines = content.Split(',');
                // 

                // Identificar o index dos campos de interesse.
                for (int i = 0; i < lines.Length; i++) {
                    if (lines[i].Contains("pl_name")) {
                        index[0] = i;
                    }
                    if (lines[i].Contains("hostname")) {
                        index[1] = i;
                    }
                    if (lines[i].Contains("discoverymethod")) {
                        index[2] = i;
                    }
                    if (lines[i].Contains("disc_year")) {
                        index[3] = i;
                    }
                    if (lines[i].Contains("pl_orbper")) {
                        index[4] = i;
                    }
                    if (lines[i].Contains("pl_rade")) {
                        index[5] = i;
                    }
                    if (lines[i].Contains("pl_bmasse")) {
                        index[6] = i;
                    }
                    if (lines[i].Contains("pl_eqt")) {
                        index[7] = i;
                    }
                    if (lines[i].Contains("st_teff")) {
                        index[8] = i;
                    }
                    if (lines[i].Contains("st_rad")) {
                        index[9] = i;
                    }
                    if (lines[i].Contains("st_mass")) {
                        index[10] = i;
                    }
                    if (lines[i].Contains("st_age")) {
                        index[11] = i;
                    }
                    if (lines[i].Contains("st_vsin")) {
                        index[12] = i;
                    }
                    if (lines[i].Contains("st_rotp")) {
                        index[13] = i;
                    }
                    if (lines[i].Contains("sy_dist")) {
                        index[14] = i;
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
                    planetName = lines[index[0]];
                    starName = lines[index[1]];

                    discoveryMethodName = lines[index[2]];
                    if (int.TryParse(lines[index[3]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out discoveryYear)) {
                    } else {
                        discoveryYear = 0;
                    }
                    if (double.TryParse(lines[index[4]], NumberStyles.Any
                        , CultureInfo.InvariantCulture,
                        out orbitalPeriod)) {
                    } else {
                        orbitalPeriod = 0;
                    }
                    if (double.TryParse(lines[index[5]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out planetRade)) {
                    } else {
                        planetRade = 0;
                    }
                    if (double.TryParse(lines[index[6]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out planetMasse)) {
                    } else {
                        planetMasse = 0;
                    }
                    if (int.TryParse(lines[index[7]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out planetTemp)) {
                    } else {
                        planetTemp = 0;
                    }
                    if (double.TryParse(lines[index[8]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starTemp)) {
                    } else {
                        starTemp = 0;
                    }
                    if (double.TryParse(lines[index[9]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starRade)) {
                    } else {
                        starRade = 0;
                    }
                    if (double.TryParse(lines[index[10]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starMass)) {
                    } else {
                        starMass = 0;
                    }
                    if (double.TryParse(lines[index[11]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starAge)) {
                    } else {
                        starAge = 0;
                    }
                    if (double.TryParse(lines[index[12]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starRotation)) {
                    } else {
                        starRotation = 0;
                    }
                    if (double.TryParse(lines[index[13]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starRotp)) {
                    } else {
                        starRotp = 0;
                    }
                    if (double.TryParse(lines[index[14]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starDistance)) {
                    } else {
                        starDistance = 0;
                    }

                    // Colocar os valores no dicionário dos planetas.
                    Facade.planetList.Add(
                       i, new Planet(
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

        }

        // Método de leitura de estrelas.
        private void GetStars() {
            // Conteúdo do ficheiro.
            string content = "";
            // Linhas do ficheiro.
            string[] lines;

            // Contar o número de planetas.
            int planetCount = 0;

            // Contar o número de estrelas repetidas na sua coleção.
            int isRepeated = 0;

            // Variáveis dos campos de interesse.
            string starName = "";
            string discoveryMethodName = "";
            int discoveryYear = 0;
            double starTemp = 0;
            double starRade = 0;
            double starMass = 0;
            double starAge = 0;
            double starRotation = 0;
            double starRotp = 0;
            double starDistance = 0;

            // Variável array de iteração.
            int[] index = new int[15];

            // Definir o valor dos elementos para zero.
            for (int i = 0; i < index.Length; i++) {
                index[i] = 0;
            }
            // Ler ficheiro.
            using (StreamReader sr = File.OpenText(fileName)) {
                lineCount = File.ReadLines(fileName).Count();

                // Passar à frente as primeiras linhas.
                for (int i = 0; i < 48; i++) {
                    content = sr.ReadLine();
                }
                // Dividir a linha e colocar cada campo na array.
                lines = new string[content.Length];
                lines = content.Split(',');
                // 

                // Identificar o index dos campos de interesse.
                for (int i = 0; i < lines.Length; i++) {
                    if (lines[i].Contains("pl_name")) {
                        index[0] = i;
                    }
                    if (lines[i].Contains("hostname")) {
                        index[1] = i;
                    }
                    if (lines[i].Contains("discoverymethod")) {
                        index[2] = i;
                    }
                    if (lines[i].Contains("disc_year")) {
                        index[3] = i;
                    }
                    if (lines[i].Contains("pl_orbper")) {
                        index[4] = i;
                    }
                    if (lines[i].Contains("pl_rade")) {
                        index[5] = i;
                    }
                    if (lines[i].Contains("pl_bmasse")) {
                        index[6] = i;
                    }
                    if (lines[i].Contains("pl_eqt")) {
                        index[7] = i;
                    }
                    if (lines[i].Contains("st_teff")) {
                        index[8] = i;
                    }
                    if (lines[i].Contains("st_rad")) {
                        index[9] = i;
                    }
                    if (lines[i].Contains("st_mass")) {
                        index[10] = i;
                    }
                    if (lines[i].Contains("st_age")) {
                        index[11] = i;
                    }
                    if (lines[i].Contains("st_vsin")) {
                        index[12] = i;
                    }
                    if (lines[i].Contains("st_rotp")) {
                        index[13] = i;
                    }
                    if (lines[i].Contains("sy_dist")) {
                        index[14] = i;
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
                    starName = lines[index[1]];
                    discoveryMethodName = lines[index[2]];
                    if (int.TryParse(lines[index[3]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out discoveryYear)) {
                    } else {
                        discoveryYear = 0;
                    }
                    if (double.TryParse(lines[index[8]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starTemp)) {
                    } else {
                        starTemp = 0;
                    }
                    if (double.TryParse(lines[index[9]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starRade)) {
                    } else {
                        starRade = 0;
                    }
                    if (double.TryParse(lines[index[10]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starMass)) {
                    } else {
                        starMass = 0;
                    }
                    if (double.TryParse(lines[index[11]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starAge)) {
                    } else {
                        starAge = 0;
                    }
                    if (double.TryParse(lines[index[12]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starRotation)) {
                    } else {
                        starRotation = 0;
                    }
                    if (double.TryParse(lines[index[13]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starRotp)) {
                    } else {
                        starRotp = 0;
                    }
                    if (double.TryParse(lines[index[14]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out starDistance)) {
                    } else {
                        starDistance = 0;
                    }

                    // Contar o número de planetas da estrela.
                    foreach (KeyValuePair<int, Planet> item in
                        Facade.planetList) {
                        if (item.Value.HostName == starName) {
                            planetCount++;
                        }
                    }

                    // Colocar os valores no dicionário das estrelas.
                    Facade.starList.Add(
                        i, new Star(
                            hostName: starName,
                            discoveryMethod: discoveryMethodName,
                            disc_Year: discoveryYear,
                            st_Teff: starTemp,
                            st_Rad: starRade,
                            st_Mass: starMass,
                            st_Age: starAge,
                            st_Vsin: starRotation,
                            st_Rotp: starRotp,
                            sy_Dist: starDistance,
                            st_PlCount: planetCount
                            )
                        );
                    // Colocar o contador de planetas a zero.
                    planetCount = 0;
                }

                // Retirar as estrelas repetidas da coleção.
                foreach (KeyValuePair<int, Star> item in Facade.starList) {
                    foreach (KeyValuePair<int, Star> compare in
                        Facade.starList) {
                        if (item.Value.HostName == compare.Value.HostName) {
                            isRepeated++;
                        }
                        if (isRepeated > 1) {
                            Facade.starList.Remove(item.Key);
                        }
                    }
                    isRepeated = 0;
                }
            }
        }

        // Inicializar as variáveis.
        public FileReader(string file) {
            // Nome do ficheiro.
            fileName = file;
            // Inicializar a coleção.
            facade = new Facade();
            // Contar as linhas.
            lineCount = 0;
        }
    }
}
