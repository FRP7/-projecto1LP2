

namespace projeto1LP2
{
    /// <summary>
    /// Classe que começa o programa.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Neste médoto é chamado o método MainMenu na classe Menu.
        /// </summary>
        /// <param name="args"> Argumentos da linha de comandos. </param>
        static void Main(string[] args) {
            Menu menu = new Menu();
            string file = null;
            menu.MainMenu(file);
        }
    }
}
