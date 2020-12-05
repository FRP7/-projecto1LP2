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
        // Construir a coleção
        private Facade facade;
        // Contar as linhas.
        private int lineCount;

        /// <summary>
        /// Método de leitura do ficheiro.
        /// </summary>
        public void ReadFile() {
            // Tentar ler ficheiro.
            try {
                //Método que verifica se o ficheiro pode ser lido.
                if (CanItRead() == true) {
                    // Método de leitura de planetas e estrelas.
                    ReadData();
                } else {
                    // Caso não veja true, atira exception.
                    throw new Exception();
                }
            }
            // Caso o ficheiro não consiga ser lido.
            catch(Exception) {
                Console.WriteLine("O ficheiro não pode ser lido");
            }
        }

        /// <summary>
        /// Método que verifica se o ficheiro tem as colunas obrigatórias.
        /// </summary>
        /// <returns> Retorna true caso tenha as colunas obrigatórias. 
        /// </returns>
        private bool CanItRead() {
            // Indicar se existe a coluna do planeta.
            bool planetName = false;
            // Indicar se existe a coluna da estrela.
            bool starName = false;
            // Indicar se existem ambas as colunas.
            bool itExists = false;

            // Tentar ler o ficheiro.
            try {
                // Conteúdo do ficheiro.
                string content = "";
                // Linhas do ficheiro.
                string[] lines;

                // Ler ficheiro.
                using (StreamReader sr = File.OpenText(fileName)) {
                    lineCount = File.ReadLines(fileName).Count();

                    // Passar à frente as linhas que têem #.
                    do {
                        content = sr.ReadLine();
                    } while (content.StartsWith("#"));

                    // Dividir a linha e colocar cada campo na array.
                    lines = new string[content.Length];
                    lines = content.Split(',');

                    // Verificar se os campos obrigatórios existem na array.
                    for (int i = 0; i < lines.Length; i++) {
                        if (lines[i].Contains("pl_name")) {
                            planetName = true;
                        }
                        if (lines[i].Contains("hostname")) {
                            starName = true;
                        }
                    }

                    // Verificar se os campos obrigatórios existem.
                    if (planetName == true && starName == true) {
                        itExists = true;
                    } else {
                        /* Atirar exceção caso não tenha as colunas 
                         * obrigatórias. */
                        throw new Exception();
                    }

                }
                return itExists;
            }
            // Caso não  tenhas as colunas obrigatórias.
            catch (Exception) {
               Console.WriteLine("O ficheiro não tem as colunas obrigatórias");
               itExists = false;
               return itExists;
            }
        }

        /// <summary>
        /// Método de leitura de planetas e estrelas.
        /// </summary>
        private void ReadData() {
            // Tentar ler planetas e estrelas.
            try {
                // Verificar se os planetas e estrelas podem ser lidos.
                if (GetPlanets() && GetStars() == true) {
                } else {
                    throw new Exception();
                }
            }
            // Caso não consiga ler os planetas e as estrelas.
            catch (Exception) {
                Console.WriteLine("Uma das colunas tem valores inválidos.");
            }
        }

        /// <summary>
        /// Método de leitura de planetas.
        /// </summary>
        /// <returns> Retorna true caso consiga ler os planetas. </returns>
        private bool GetPlanets() {
            // Conteúdo do ficheiro.
            string content = "";
            // Linhas do ficheiro.
            string[] lines;

            // Campos de interesse.
            string planetName = "";
            string starName = "";
            string discoveryMethodName = "";
            Nullable<int> discoveryYear = 0;
            Nullable<double> orbitalPeriod = 0;
            Nullable<double> planetRade = 0;
            Nullable<double> planetMasse = 0;
            Nullable<int> planetTemp = 0;
            Nullable<double> starTemp = 0;
            Nullable<double> starRade = 0;
            Nullable<double> starMass = 0;
            Nullable<double> starAge = 0;
            Nullable<double> starRotation = 0;
            Nullable<double> starRotp = 0;
            Nullable<double> starDistance = 0;

            // Suporte.
            int intSupport = 0;
            double doubleSupport = 0;

            // Contar as colunas.
            int columnCount = 0;

            // Contar a quantidade de conteúdo que tem cada coluna.
            int contentCount = 0;

            // Array de iteração.
            int[] index = new int[15];

            // Definir o valor dos elementos da array para zero.
            for (int i = 0; i < index.Length; i++) {
                index[i] = 0;
            }

            // Array que indica se a coluna existe.
            bool[] itExists = new bool[15];

            // Definir o valor dos elementos da array para false.
            for (int i = 0; i < itExists.Length; i++) {
                itExists[i] = false;
            }

            // Ler ficheiro.
            using (StreamReader sr = File.OpenText(fileName)) {
                lineCount = File.ReadLines(fileName).Count();

                // Passar à frente as linhas que têem #.
                do {
                    content = sr.ReadLine();
                } while (content.StartsWith("#"));

                // Dividir a linha e colocar cada campo na array.
                lines = new string[content.Length];
                lines = content.Split(',');
                // 

                // Identificar o index dos campos de interesse.
                for (int i = 0; i < lines.Length; i++) {
                    if (lines[i].Contains("pl_name")) {
                        index[0] = i;
                        itExists[0] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("hostname")) {
                        index[1] = i;
                        itExists[1] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("discoverymethod")) {
                        index[2] = i;
                        itExists[2] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("disc_year")) {
                        index[3] = i;
                        itExists[3] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("pl_orbper")) {
                        index[4] = i;
                        itExists[4] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("pl_rade")) {
                        index[5] = i;
                        itExists[5] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("pl_bmasse")) {
                        index[6] = i;
                        itExists[6] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("pl_eqt")) {
                        index[7] = i;
                        itExists[7] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("st_teff")) {
                        index[8] = i;
                        itExists[8] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("st_rad")) {
                        index[9] = i;
                        itExists[9] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("st_mass")) {
                        index[10] = i;
                        itExists[10] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("st_age")) {
                        index[11] = i;
                        itExists[11] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("st_vsin")) {
                        index[12] = i;
                        itExists[12] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("st_rotp")) {
                        index[13] = i;
                        itExists[13] = true;
                        columnCount++;
                    }
                    if (lines[i].Contains("sy_dist")) {
                        index[14] = i;
                        itExists[14] = true;
                        columnCount++;
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

                    // Pl_Name.
                    if (itExists[0] == true) {
                        planetName = lines[index[0]];
                    }

                    // HostName.
                    if (itExists[1] == true) {
                        starName = lines[index[1]];
                    }

                    // DiscoveryMethod.
                    if (itExists[2] == true) {
                        discoveryMethodName = lines[index[2]];
                    }

                    // Disc_Year.
                    if (itExists[3] == true) {
                        if (lines[index[3]].Any(x => char.IsLetter(x)) 
                            == false) {
                            int.TryParse(lines[index[3]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        intSupport);
                        } else {
                            return false;
                        }

                        if (intSupport == 0) {
                            discoveryYear = null;
                        } else {
                            discoveryYear = intSupport;
                        }
                    }

                    // Pl_Orbper.
                    if (itExists[4] == true) {
                        if (lines[index[4]].Any(x => char.IsLetter(x)) 
                            == false) {
                            double.TryParse(lines[index[4]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            orbitalPeriod = null;
                        } else {
                            orbitalPeriod = doubleSupport;
                        }
                    }

                    // Pl_Rade.
                    if (itExists[5] == true) {
                        if (lines[index[5]].Any(x => char.IsLetter(x))
                            == false) {
                            double.TryParse(lines[index[5]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            planetRade = null;
                        } else {
                            planetRade = doubleSupport;
                        }
                    }

                    // Pl_Masse.
                    if (itExists[6] == true) {
                        if (lines[index[6]].Any(x => char.IsLetter(x))
                            == false) {
                            double.TryParse(lines[index[6]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            planetMasse = null;
                        } else {
                            planetMasse = doubleSupport;
                        }
                    }

                    // Pl_Eqt.
                    if (itExists[7] == true) {
                        if (lines[index[7]].Any(x => char.IsLetter(x)) 
                            == false) {
                            int.TryParse(lines[index[7]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        intSupport);
                        } else {
                            return false;
                        }

                        if (planetTemp == 0) {
                            planetTemp = null;
                        } else {
                            planetTemp = intSupport;
                        }
                    }

                    // St_Teff.
                    if (itExists[8] == true) {
                        if (lines[index[8]].Any(x => char.IsLetter(x)) 
                            == false) {
                            double.TryParse(lines[index[8]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starTemp = null;
                        } else {
                            starTemp = doubleSupport;
                        }
                    }

                    // St_Rad.
                    if (itExists[9] == true) {
                        if (lines[index[9]].Any(x => char.IsLetter(x)) 
                            == false) {
                            double.TryParse(lines[index[9]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starRade = null;
                        } else {
                            starRade = doubleSupport;
                        }
                    }

                    // St_Mass.
                    if (itExists[10] == true) {
                        if (lines[index[10]].Any(x => char.IsLetter(x)) 
                            == false) {
                            double.TryParse(lines[index[10]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starMass = null;
                        } else {
                            starMass = doubleSupport;
                        }
                    }

                    // St_Age.
                    if (itExists[11] == true) {
                        if (lines[index[11]].Any(x => char.IsLetter(x))
                            == false) {
                            double.TryParse(lines[index[11]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starAge = null;
                        } else {
                            starAge = doubleSupport;
                        }
                    }

                    // St_Vsin.
                    if (itExists[12] == true) {
                        if (lines[index[12]].Any(x => char.IsLetter(x)) 
                            == false) {
                            double.TryParse(lines[index[12]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starRotation = null;
                        } else {
                            starRotation = doubleSupport;
                        }
                    }

                    // St_Rotp.
                    if (itExists[13] == true) {
                        if (lines[index[13]].Any(x => char.IsLetter(x))
                            == false) {
                            double.TryParse(lines[index[13]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starRotp = null;
                        } else {
                            starRotp = doubleSupport;
                        }
                    }

                    // Sy_Dist.
                    if (lines[index[14]].Any(x => char.IsLetter(x)) 
                        == false) {
                        double.TryParse(lines[index[14]], NumberStyles.Any,
                    CultureInfo.InvariantCulture, out
                    doubleSupport);
                    } else {
                        return false;
                    }

                    if (doubleSupport == 0) {
                        starDistance = null;
                    } else {
                        starDistance = doubleSupport;
                    }

                    // Colocar os valores no dicionário dos planetas.
                    Facade.planetList.Add(
                       i, new Planet(
                       pl_Name: planetName,
                       hostName: starName,
                       discoveryMethod: discoveryMethodName,
                       disc_Year: discoveryYear,
                       pl_Orbper: orbitalPeriod,
                       pl_Rade: planetRade,
                       pl_Masse: planetMasse,
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

            /* Verificar se a quantidade de conteúdo existente não é menor 
              * que o número de colunas lidas. */

            // Coluna Pl_Name.
            contentCount = Facade.planetList.Values.SelectMany
                (x => x.Pl_Name).Count();
            if (contentCount < columnCount) {
                return false;
            } 

            // Coluna HostName.
            contentCount = Facade.planetList.Values.Select
                (x => x.HostName).Count();
            if (contentCount < columnCount) {
                return false;
            } 

            // Coluna DiscoveryMethod.
            contentCount = Facade.planetList.Values.Select
                (x => x.DiscoveryMethod).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna Disc_Year.
            contentCount = Facade.planetList.Values.Select
                (x => x.Disc_Year).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna Pl_Orbper.
            contentCount = Facade.planetList.Values.Select
                (x => x.Pl_Orbper).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna Pl_Rade.
            contentCount = Facade.planetList.Values.Select
                (x => x.Pl_Rade).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna Pl_Masse.
            contentCount = Facade.planetList.Values.Select
                (x => x.Pl_Masse).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna Pl_Eqt.
            contentCount = Facade.planetList.Values.Select
                (x => x.Pl_Eqt).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna St_Teff.
            contentCount = Facade.planetList.Values.Select
                (x => x.St_Teff).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna St_Rad.
            contentCount = Facade.planetList.Values.Select
                (x => x.St_Rad).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna St_Mass.
            contentCount = Facade.planetList.Values.Select
                (x => x.St_Mass).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna St_Age.
            contentCount = Facade.planetList.Values.Select
                (x => x.St_Age).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna St_Vsin.
            contentCount = Facade.planetList.Values.Select
                (x => x.St_Vsin).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna St_Rotp.
            contentCount = Facade.planetList.Values.Select
                (x => x.St_Rotp).Count();
            if (contentCount < columnCount) {
                return false;
            }

            // Coluna Sy_Dist.
            contentCount = Facade.planetList.Values.Select
                (x => x.Sy_Dist).Count();
            if (contentCount < columnCount) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método de leitura de estrelas.
        /// </summary>
        /// <returns> Retorna true caso consiga ler as estrelas. </returns>
        private bool GetStars() {
            // Conteúdo do ficheiro.
            string content = "";
            // Linhas do ficheiro.
            string[] lines;

            // Contar o número de planetas.
            Nullable<int> planetCount = 0;

            // Contar o número de estrelas repetidas na sua coleção.
            int isRepeated = 0;

            // Campos de interesse.
            string starName = "";
            string discoveryMethodName = "";
            Nullable<int> discoveryYear = 0;
            Nullable<double> starTemp = 0;
            Nullable<double> starRade = 0;
            Nullable<double> starMass = 0;
            Nullable<double> starAge = 0;
            Nullable<double> starRotation = 0;
            Nullable<double> starRotp = 0;
            Nullable<double> starDistance = 0;

            // Suporte.
            int intSupport = 0;
            double doubleSupport = 0;

            // Array de iteração.
            int[] index = new int[10];

            // Definir o valor dos elementos da array para zero.
            for (int i = 0; i < index.Length; i++) {
                index[i] = 0;
            }

            // Array que indica se as colunas existem.
            bool[] itExists = new bool[10];

            // Definir o valor dos elementos da array para false.
            for (int i = 0; i < itExists.Length; i++) {
                itExists[i] = false;
            }

            // Ler ficheiro.
            using (StreamReader sr = File.OpenText(fileName)) {
                lineCount = File.ReadLines(fileName).Count();

                // Passar à frente as linhas que têem #.
                do {
                    content = sr.ReadLine();
                } while (content.StartsWith("#"));


                // Dividir a linha e colocar cada campo na array.
                lines = new string[content.Length];
                lines = content.Split(',');


                // Identificar o index dos campos de interesse.
                for (int i = 0; i < lines.Length; i++) {
                    if (lines[i].Contains("hostname")) {
                        index[0] = i;
                        itExists[0] = true;
                    }
                    if (lines[i].Contains("discoverymethod")) {
                        index[1] = i;
                        itExists[1] = true;
                    }
                    if (lines[i].Contains("disc_year")) {
                        index[2] = i;
                        itExists[2] = true;
                    }
                    if (lines[i].Contains("st_teff")) {
                        index[3] = i;
                        itExists[3] = true;
                    }
                    if (lines[i].Contains("st_rad")) {
                        index[4] = i;
                        itExists[4] = true;
                    }
                    if (lines[i].Contains("st_mass")) {
                        index[5] = i;
                        itExists[5] = true;
                    }
                    if (lines[i].Contains("st_age")) {
                        index[6] = i;
                        itExists[6] = true;
                    }
                    if (lines[i].Contains("st_vsin")) {
                        index[7] = i;
                        itExists[7] = true;
                    }
                    if (lines[i].Contains("st_rotp")) {
                        index[8] = i;
                        itExists[8] = true;
                    }
                    if (lines[i].Contains("sy_dist")) {
                        index[9] = i;
                        itExists[9] = true;
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

                    // Hostname.
                    if (itExists[0] == true) {
                        starName = lines[index[0]];
                    }

                    // DiscoveryMethod.
                    if (itExists[1] == true) {
                        discoveryMethodName = lines[index[1]];
                    }

                    // Disc_Year.
                    if (itExists[2] == true) {
                        if (lines[index[2]].Any(x => char.IsLetter(x))
                            == false) {
                            int.TryParse(lines[index[2]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        intSupport);
                        } else {
                            return false;
                        }

                        if (intSupport == 0) {
                            discoveryYear = null;
                        } else {
                            discoveryYear = intSupport;
                        }
                    }

                    // St_Teff.
                    if (itExists[3] == true) {
                        if (lines[index[3]].Any(x => char.IsLetter(x))
                            == false) {
                            double.TryParse(lines[index[3]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starTemp = null;
                        } else {
                            starTemp = doubleSupport;
                        }
                    }

                    // St_Rad.
                    if (itExists[4] == true) {
                        if (lines[index[4]].Any(x => char.IsLetter(x))
                            == false) {
                            double.TryParse(lines[index[4]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starRade = null;
                        } else {
                            starRade = doubleSupport;
                        }
                    }

                    // St_Mass.
                    if (itExists[5] == true) {
                        if (lines[index[5]].Any(x => char.IsLetter(x)) 
                            == false) {
                            double.TryParse(lines[index[5]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starMass = null;
                        } else {
                            starMass = doubleSupport;
                        }
                    }

                    // St_Age.
                    if (itExists[6] == true) {
                        if (lines[index[6]].Any(x => char.IsLetter(x))
                            == false) {
                            double.TryParse(lines[index[6]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starAge = null;
                        } else {
                            starAge = doubleSupport;
                        }
                    }

                    // St_Vsin.
                    if (itExists[7] == true) {
                        if (lines[index[7]].Any(x => char.IsLetter(x))
                            == false) {
                            double.TryParse(lines[index[7]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starRotation = null;
                        } else {
                            starRotation = doubleSupport;
                        }
                    }

                    // St_Rotp.
                    if (itExists[8] == true) {
                        if (lines[index[8]].Any(x => char.IsLetter(x)) 
                            == false) {
                            double.TryParse(lines[index[8]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starRotp = null;
                        } else {
                            starRotp = doubleSupport;
                        }
                    }

                    // Sy_Dist.
                    if (itExists[9] == true) {
                        if (lines[index[9]].Any(x => char.IsLetter(x))
                            == false) {
                            double.TryParse(lines[index[9]], NumberStyles.Any,
                        CultureInfo.InvariantCulture, out
                        doubleSupport);
                        } else {
                            return false;
                        }

                        if (doubleSupport == 0) {
                            starDistance = null;
                        } else {
                            starDistance = doubleSupport;
                        }
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
            return true;
        }

        /// <summary>
        /// Inicializar as variáveis.
        /// </summary>
        /// <param name="file"> Nome do ficheiro a ser lido. </param>
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
