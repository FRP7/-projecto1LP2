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
            FileReader teste = new FileReader();
            teste.ReadFile();
            // debug pa testes, delete later.
            // testar planetas:
            Console.WriteLine("Planetas: ");
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

            if (Facade.planetList[0].St_Age == 0) {
                Console.WriteLine("Informação não disponível");
            }
            if (Facade.planetList[0].St_Vsin == 0) {
                Console.WriteLine("Informação não disponível");
            }
            if (Facade.planetList[0].St_Rotp == 0) {
                Console.WriteLine("Informação não disponível");
            }
            Console.WriteLine(Facade.planetList[0].Sy_Dist);
            // testar estrela, delete later
            Console.WriteLine("Estrelas: ");
            /*Console.WriteLine(Facade.starList[0].HostName);
            Console.WriteLine(Facade.starList[0].DiscoveryMethod);
            Console.WriteLine(Facade.starList[0].Disc_Year);
            Console.WriteLine(Facade.starList[0].St_Teff);
            Console.WriteLine(Facade.starList[0].St_Rad);
            Console.WriteLine(Facade.starList[0].St_Mass);
            if (Facade.starList[0].St_Age == 0) {
                Console.WriteLine("Informação não disponível");
            }
            if (Facade.starList[0].St_Vsin == 0) {
                Console.WriteLine("Informação não disponível");
            }
            if (Facade.starList[0].St_Rotp == 0) {
                Console.WriteLine("Informação não disponível");
            }
            Console.WriteLine(Facade.starList[0].Sy_Dist);
            Console.WriteLine(Facade.starList[0].Sy_Pnum);*/
            Console.WriteLine(Facade.starList[0].Item1.HostName);
        }
    }
}
