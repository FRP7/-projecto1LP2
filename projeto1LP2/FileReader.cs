using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace projeto1LP2
{
    /// <summary>
    /// Classe onde o ficheiro é lido e guardado numa coleção.
    /// </summary>
    class FileReader
    {
        private const string fileName = "planetList.csv";
        Facade facade = new Facade();
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
            try {
                using(StreamReader sr = File.OpenText(fileName)) {
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
                    // Dividir a linha e colocar na array
                    lines = new string[content.Length];
                    lines = content.Split(',');
                    foreach(string item in lines) {
                        Console.WriteLine(item);
                    }
                }
                // debug pa testes, delete later
                //Console.WriteLine(Facade.planetList[0].Pl_Name);

                return true;
            } catch(Exception message) {
                Console.WriteLine("Ocorreu o seguinte problema: " +
                    message.Message);
                return false;
            }
        }
    }
}
