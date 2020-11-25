using System;
using System.IO;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Classe onde o ficheiro é lido e guardado numa coleção.
    /// </summary>
    class FileReader
    {
        private const string fileName = "planetList.csv";
        //private string teste;

        public void ReadFile() {
            /*StreamReader sr = File.OpenText(fileName);
            teste = sr.ReadToEnd();
            Console.WriteLine(teste);
            sr.Close();*/
            /*using(StreamReader sr = File.OpenText(fileName)) {
            }*/
            Facade facade = new Facade();
            facade.planetList.Add(
                "Teste",
                new Types(
                    teste: "Hello World"
                    )
                );

            /*foreach (KeyValuePair<string, Types> item in facade.planetList) {
                Console.WriteLine(item);
            }
            Console.WriteLine(facade.planetList["Teste"].Teste);*/
        }
    }
}
