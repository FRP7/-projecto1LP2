using System;
using System.IO;

namespace projeto1LP2
{
    /// <summary>
    /// Classe onde o ficheiro é lido e guardado numa coleção.
    /// </summary>
    class FileReader
    {
        private const string fileName = "planetList.csv";
        private string teste;

        public void ReadFile() {
            StreamReader sr = File.OpenText(fileName);
            teste = sr.ReadToEnd();
            Console.WriteLine(teste);
        }
    }
}
