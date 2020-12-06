using System;
using System.Linq;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Classe onde vão estar os métodos de pesquisa de estrelas.
    /// </summary>
    class StarSearcher
    {
        // Aceder à Facade.
        private Facade facade;
        // Estas variáveis têem obrigatoriamente de serem inicializadas aqui!
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

        private Func<KeyValuePair<int, Star>, Object> orderByFunc;

        private void CheckField(StarFields fields)
        {
            if (fields == StarFields.HostName)
            {
                orderByFunc = item => item.Value.HostName;
            }
            if (fields == StarFields.DiscoveryMethod)
            {
                orderByFunc = item => item.Value.DiscoveryMethod;
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

        // Método de pesquisa de estrelas pelo nome.
        public void SearchByName(string input, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByName; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pelo nome");

            facade.SortInfo(input, isAscending, filterByName, orderByFunc);
        }

        // Método de pesquisa de estrelas pelo método de descoberta.
        public void SearchByDiscoveryMethod(string input, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByDiscoveryMethod; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pelo método de descoberta");

            facade.SortInfo(input, isAscending, filterByDiscoveryMethod, orderByFunc);
        }

        // Método de pesquisa de estrelas pelo ano de descoberta.
        public void SearchByDiscoveryYear(int? min, int? max, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByDiscoveryYear; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pelo ano de descoberta");

            facade.SortInfo(min, max, isAscending, filterByDiscoveryYear, orderByFunc);
        }

        // Método de pesquisa de estrelas pela temperatura.
        public void SearchByTeff(double? min, double? max, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByTaff; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pela temperatura");

            facade.SortInfo(min, max, isAscending, filterByTaff, orderByFunc);
        }

        // Método de pesquisa de estrelas pelo raio.
        public void SearchByRad(double? min, double? max, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByRad; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pelo raio");

            facade.SortInfo(min, max, isAscending, filterByRad, orderByFunc);
        }

        // Método de pesquisa de estrelas pela massa.
        public void SearchByMass(double? min, double? max, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByMass; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pela massa");

            facade.SortInfo(min, max, isAscending, filterByMass, orderByFunc);
        }

        // Método de pesquisa de estrelas pela idade.
        public void SearchByAge(double? min, double? max, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByAge; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pela idade");

            facade.SortInfo(min, max, isAscending, filterByAge, orderByFunc);
        }

        // Método de pesquisa de estrelas pela velocidade de rotação.
        public void SearchByVsin(double? min, double? max, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByVsin; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pela velocidade de rotação");

            facade.SortInfo(min, max, isAscending, filterByVsin, orderByFunc);
        }

        // Método de pesquisa de estrelas pelo período de rotação.
        public void SearchByRotp(double? min, double? max, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByRotp; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pelo período de rotação");

            facade.SortInfo(min, max, isAscending, filterByRotp, orderByFunc);
        }

        // Método de pesquisa de estrelas pela distância.
        public void SearchByDist(double? min, double? max, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByDyst; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pela distância");

            facade.SortInfo(min, max, isAscending, filterByDyst, orderByFunc);
        }

        // Método de pesquisa de estrelas pela quantidade de planetas.
        public void SearchByPlCount(double? min, double? max, bool isAscending, StarFields fields)
        {
            Facade.starList = filterByPlCount; // obrigatório!!!!

            CheckField(fields);

            Console.WriteLine("Filtrar pelo número de planetas");

            facade.SortInfo(min, max, isAscending, filterByPlCount, orderByFunc);
        }

        // Inicializar as variáveis.
        public StarSearcher()
        {
            facade = new Facade();
        }
    }
}
