using System;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Classe onde vão estar os métodos de pesquisa de estrelas.
    /// </summary>
    class StarSearcher
    {
        // Inicializar a Facade.
        private Facade facade;

        // Coleções de estrelas de acordo com os filtros escolhidos.
        private Dictionary<int, Star> filterByName =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByDiscoveryMethod =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByDiscoveryYear =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByTaff =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByRad =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByMass =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByAge =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByVsin =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByRotp =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByDyst =
            new Dictionary<int, Star>(Facade.starList);
        private Dictionary<int, Star> filterByPlCount =
            new Dictionary<int, Star>(Facade.starList);

        // Critério de ordenação.
        private Func<KeyValuePair<int, Star>, Object> orderByFunc;

        // Critério de ordenação secundário.
        private Func<KeyValuePair<int, Star>, Object> secondOrderByFunc;

        /// <summary>
        /// Verificar qual é o método de ordenação primário.
        /// </summary>
        /// <param name="fields"> Enum do critério de ordenação. </param>
        private void CheckField(StarFields fields)
        {
            if (fields == StarFields.HostName)
            {
                orderByFunc = item => item.Value.HostName.Length;
            }
            if (fields == StarFields.DiscoveryMethod)
            {
                orderByFunc = item => item.Value.DiscoveryMethod.Length;
            }
            if (fields == StarFields.Disc_Year)
            {
                orderByFunc = item => item.Value.Disc_Year;
            }
            if (fields == StarFields.St_Teff)
            {
                orderByFunc = item => item.Value.St_Teff;
            }
            if (fields == StarFields.St_Rad)
            {
                orderByFunc = item => item.Value.St_Rad;
            }
            if (fields == StarFields.St_Mass)
            {
                orderByFunc = item => item.Value.St_Mass;
            }
            if (fields == StarFields.St_Age)
            {
                orderByFunc = item => item.Value.St_Age;
            }
            if (fields == StarFields.St_Vsin)
            {
                orderByFunc = item => item.Value.St_Vsin;
            }
            if (fields == StarFields.St_Rotp)
            {
                orderByFunc = item => item.Value.St_Rotp;
            }
            if (fields == StarFields.Sy_Dist)
            {
                orderByFunc = item => item.Value.Sy_Dist;
            }
            if (fields == StarFields.St_PlCount)
            {
                orderByFunc = item => item.Value.St_PlCount;
            }
        }

        /// <summary>
        /// Verificar qual é o método de ordenação secundário.
        /// </summary>
        /// <param name="fields"> Enum do critério de ordenação secundário. 
        /// </param>
        private void SecondField(StarFields fields) {
            if (fields == StarFields.HostName) {
                secondOrderByFunc = item => item.Value.DiscoveryMethod.Length;
            }
            if (fields == StarFields.DiscoveryMethod) {
                secondOrderByFunc = item => item.Value.Disc_Year;
            }
            if (fields == StarFields.Disc_Year) {
                secondOrderByFunc = item => item.Value.St_Teff;
            }
            if (fields == StarFields.St_Teff) {
                secondOrderByFunc = item => item.Value.St_Rad;
            }
            if (fields == StarFields.St_Rad) {
                secondOrderByFunc = item => item.Value.St_Mass;
            }
            if (fields == StarFields.St_Mass) {
                secondOrderByFunc = item => item.Value.St_Age;
            }
            if (fields == StarFields.St_Age) {
                secondOrderByFunc = item => item.Value.St_Vsin;
            }
            if (fields == StarFields.St_Vsin) {
                secondOrderByFunc = item => item.Value.St_Rotp;
            }
            if (fields == StarFields.St_Rotp) {
                secondOrderByFunc = item => item.Value.Sy_Dist;
            }
            if (fields == StarFields.Sy_Dist) {
                secondOrderByFunc = item => item.Value.St_PlCount;
            }
            if (fields == StarFields.St_PlCount) {
                secondOrderByFunc = item => item.Value.Sy_Dist;
            }
        }

        /// <summary>
        /// Método de pesquisa de estrelas pelo nome.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByName(string input, bool isAscending, 
            StarFields fields)
        {
            Facade.starList = filterByName; 

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo nome");

            facade.StarSortName(input, isAscending, filterByName, orderByFunc,
                secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de estrelas pelo método de descoberta.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByDiscoveryMethod(string input, bool isAscending,
            StarFields fields)
        {
            Facade.starList = filterByDiscoveryMethod; 

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo método de descoberta");

            facade.StarSortDiscMethod(input, isAscending, 
                filterByDiscoveryMethod, orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de estrelas pelo ano de descoberta.
        /// </summary>
        /// <param name="min"> Ano mínimo. </param>
        /// <param name="max"> Ano máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByDiscoveryYear(int? min, int? max, bool isAscending,
            StarFields fields)
        {
            Facade.starList = filterByDiscoveryYear; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo ano de descoberta");

            facade.StarSortDiscYear(min, max, isAscending, 
                filterByDiscoveryYear, orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de estrelas pela temperatura.
        /// </summary>
        /// <param name="min"> Temperatura mínima. </param>
        /// <param name="max"> Temperatura máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByTeff(double? min, double? max, bool isAscending, 
            StarFields fields)
        {
            Facade.starList = filterByTaff; 

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pela temperatura");

            facade.StarSortTeff(min, max, isAscending, filterByTaff,
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de estrelas pelo raio.
        /// </summary>
        /// <param name="min"> Temperatura mínima. </param>
        /// <param name="max"> Temperatura máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByRad(double? min, double? max, bool isAscending,
            StarFields fields)
        {
            Facade.starList = filterByRad; 

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo raio");

            facade.StarSortRad(min, max, isAscending, filterByRad, orderByFunc,
                secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de estrelas pela massa.
        /// </summary>
        /// <param name="min"> Massa mínima. </param>
        /// <param name="max"> Massa máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByMass(double? min, double? max, bool isAscending,
            StarFields fields)
        {
            Facade.starList = filterByMass; 

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pela massa");

            facade.StarSortMass(min, max, isAscending, filterByMass,
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de estrelas pela idade.
        /// </summary>
        /// <param name="min"> Idade mínima. </param>
        /// <param name="max"> Idade máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByAge(double? min, double? max, bool isAscending,
            StarFields fields)
        {
            Facade.starList = filterByAge; 

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pela idade");

            facade.StarSortAge(min, max, isAscending, filterByAge, orderByFunc,
                secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de estrelas pela velocidade de rotação.
        /// </summary>
        /// <param name="min"> Velocidade mínima. </param>
        /// <param name="max"> Velocidade máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByVsin(double? min, double? max, bool isAscending, 
            StarFields fields)
        {
            Facade.starList = filterByVsin; 

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pela velocidade de rotação");

            facade.StarSortVsin(min, max, isAscending, filterByVsin, 
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de estrelas pelo período de rotação.
        /// </summary>
        /// <param name="min"> Período de rotação mínimo. </param>
        /// <param name="max"> Período do rotação máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByRotp(double? min, double? max, bool isAscending,
            StarFields fields)
        {
            Facade.starList = filterByRotp; 

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo período de rotação");

            facade.StarSortRtop(min, max, isAscending, filterByRotp,
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de estrelas pela distância.
        /// </summary>
        /// <param name="min"> Distância mínima. </param>
        /// <param name="max"> Distância máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByDist(double? min, double? max, bool isAscending,
            StarFields fields)
        {
            Facade.starList = filterByDyst; 

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pela distância");

            facade.StarSortDyst(min, max, isAscending, filterByDyst, 
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de estrelas pela quantidade de planetas.
        /// </summary>
        /// <param name="min"> Número mínimo de planetas. </param>
        /// <param name="max"> Número máximo de planetas. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo da estrela. </param>
        public void SearchByPlCount(int? min, int? max, bool isAscending, 
            StarFields fields)
        {
            Facade.starList = filterByPlCount; 

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo número de planetas");

            facade.StarSortPlCount(min, max, isAscending, filterByPlCount,
                orderByFunc, secondOrderByFunc);
        }

        // Inicializar as variáveis.
        public StarSearcher()
        {
            facade = new Facade();
        }
    }
}
