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
            //Console.WriteLine("Hello World!");
            FileReader teste = new FileReader();
            teste.ReadFile();
            /*foreach (KeyValuePair<int, Types> item in Facade.planetList) {
                Console.WriteLine(item);
            }
            Console.WriteLine(Facade.planetList[0].Teste);*/

            for(int i = 0; i < Facade.planetList.Count; i++) {
                Console.WriteLine(Facade.planetList[i].Teste);
            }
        }
    }
}
