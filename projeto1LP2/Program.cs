using System;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Aqui é onde começa o programa.
    /// </summary>
    class Program
    {
        static void Main(string[] args) {
            FileReader teste = new FileReader("planetList.csv");
            teste.ReadFile();
            // debug pa testes, delete later.
            /*foreach (KeyValuePair<int, Star> item in Facade.starList) {
                Console.WriteLine($"ID: {item.Key}.  Estrela: {item.Value.HostName}." +
                 $" Planetas: {item.Value.St_PlCount}");
            }*/
            foreach (KeyValuePair<int, Planet> item in Facade.planetList) {
                Console.WriteLine($"ID: {item.Key}.  Planeta: {item.Value.Pl_Name}." +
                 $" Planetas: {item.Value.P1_Orbper}");
            }
        }
    }
}
