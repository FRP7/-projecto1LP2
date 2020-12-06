using System;
using System.Linq;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Classe onde vão estar os métodos de pesquisa de planetas.
    /// </summary>
    class PlanetSearcher
    {
        // Aceder à Facade.
        private Facade facade;
        // Estas variáveis têem obrigatoriamente de serem inicializadas aqui!
        private Dictionary<int, Planet> filterByName =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByHostName =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByDiscoveryMethod =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByDiscoveryYear =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByOrbitalPeriod =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByRadius =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByMass =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByEqt =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByHostTeff =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByHostRad =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByHostMass =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByHostAge =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByHostVsin =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByHostRotp =
            new Dictionary<int, Planet>(Facade.planetList);
        private Dictionary<int, Planet> filterByHostDist =
            new Dictionary<int, Planet>(Facade.planetList);

        private Func<KeyValuePair<int, Planet>, Object> orderByFunc;
        private Func<KeyValuePair<int, Planet>, Object> secondOrderByFunc;

        private void CheckField(PlanetField fields)
        {
            if (fields == PlanetField.Pl_Name)
            {
                orderByFunc = item => item.Value.Pl_Name.Length;
            }
            if (fields == PlanetField.HostName)
            {
                orderByFunc = item => item.Value.HostName.Length;
            }
            if (fields == PlanetField.DiscoveryMethod)
            {
                orderByFunc = item => item.Value.DiscoveryMethod.Length;
            }
            if (fields == PlanetField.Disc_Year)
            {
                orderByFunc = item => item.Value.Disc_Year;
            }
            if (fields == PlanetField.Pl_Orbper)
            {
                orderByFunc = item => item.Value.Pl_Orbper;
            }
            if (fields == PlanetField.Pl_Rade)
            {
                orderByFunc = item => item.Value.Pl_Rade;
            }
            if (fields == PlanetField.Pl_Masse)
            {
                orderByFunc = item => item.Value.Pl_Masse;
            }
            if (fields == PlanetField.Pl_Eqt)
            {
                orderByFunc = item => item.Value.Pl_Eqt;
            }
            if (fields == PlanetField.St_Teff)
            {
                orderByFunc = item => item.Value.St_Teff;
            }
            if (fields == PlanetField.St_Rad)
            {
                orderByFunc = item => item.Value.St_Rad;
            }
            if (fields == PlanetField.St_Mass)
            {
                orderByFunc = item => item.Value.St_Mass;
            }
            if (fields == PlanetField.St_Age)
            {
                orderByFunc = item => item.Value.St_Age;
            }
            if (fields == PlanetField.St_Vsin)
            {
                orderByFunc = item => item.Value.St_Vsin;
            }
            if (fields == PlanetField.St_Rotp)
            {
                orderByFunc = item => item.Value.St_Rotp;
            }
            if (fields == PlanetField.Sy_Dist)
            {
                orderByFunc = item => item.Value.Sy_Dist;
            }
        }

        private void SecondField(PlanetField fields) {
            if (fields == PlanetField.Pl_Name) {
                secondOrderByFunc = item => item.Value.HostName.Length;
            }
            if (fields == PlanetField.HostName) {
                secondOrderByFunc = item => item.Value.DiscoveryMethod.Length;
            }
            if (fields == PlanetField.DiscoveryMethod) {
                secondOrderByFunc = item => item.Value.Disc_Year;
            }
            if (fields == PlanetField.Disc_Year) {
                secondOrderByFunc = item => item.Value.Pl_Orbper;
            }
            if (fields == PlanetField.Pl_Orbper) {
                secondOrderByFunc = item => item.Value.Pl_Rade;
            }
            if (fields == PlanetField.Pl_Rade) {
                secondOrderByFunc = item => item.Value.Pl_Masse;
            }
            if (fields == PlanetField.Pl_Masse) {
                secondOrderByFunc = item => item.Value.Pl_Eqt;
            }
            if (fields == PlanetField.Pl_Eqt) {
                secondOrderByFunc = item => item.Value.St_Teff;
            }
            if (fields == PlanetField.St_Teff) {
                secondOrderByFunc = item => item.Value.St_Rad;
            }
            if (fields == PlanetField.St_Rad) {
                secondOrderByFunc = item => item.Value.St_Mass;
            }
            if (fields == PlanetField.St_Mass) {
                secondOrderByFunc = item => item.Value.St_Age;
            }
            if (fields == PlanetField.St_Age) {
                secondOrderByFunc = item => item.Value.St_Vsin;
            }
            if (fields == PlanetField.St_Vsin) {
                secondOrderByFunc = item => item.Value.St_Rotp;
            }
            if (fields == PlanetField.St_Rotp) {
                secondOrderByFunc = item => item.Value.Sy_Dist;
            }
            if (fields == PlanetField.Sy_Dist) {
                secondOrderByFunc = item => item.Value.St_Rotp;
            }
        }

        // Método de pesquisa de planetas pelo nome.
        public void SearchByPlanetName(string input, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByName;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet name");

            facade.SortInfo(input, isAscending, filterByName, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pelo nome das suas estrelas.
        public void SearchByPlanetHostName(string input, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostName;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by host star");

            facade.SortInfo(input, isAscending, filterByHostName, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pelo método de descoberta.
        public void SearchByPlanetDiscoveryMethod(string input, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByDiscoveryMethod;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by discovery method");

            facade.SortInfo(input, isAscending, filterByDiscoveryMethod, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pelo ano de descoberta.
        public void SearchByPlanetDiscoveryYear(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByDiscoveryYear;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by discovery year");

            facade.SortInfo(min, max, isAscending, filterByDiscoveryYear, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pelo periodo de orbita.
        public void SearchByPlanetOrbitalPeriod(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByOrbitalPeriod;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by orbital period");

            facade.SortInfo(min, max, isAscending, filterByOrbitalPeriod, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pelo raio.
        public void SearchByPlanetRadius(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByRadius;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by radius");

            facade.SortInfo(min, max, isAscending, filterByRadius, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pelo raio da sua estrela.
        public void SearchByPlanetHostRad(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostRad;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet hosting star radius");

            facade.SortInfo(min, max, isAscending, filterByRadius, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pela temperatura de equilibrio.
        public void SearchByPlanetEqt(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByEqt;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by equilibrium temperature");

            facade.SortInfo(min, max, isAscending, filterByEqt, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pela temperatura efetiva da sua estrela.
        public void SearchByPlanetHostTeff(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostTeff;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by the planet hosting star temperature");

            facade.SortInfo(min, max, isAscending, filterByHostTeff, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pela massa.
        public void SearchByPlanetMass(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByMass;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by mass");

            facade.SortInfo(min, max, isAscending, filterByRadius, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pela massa da sua estrela.
        public void SearchByPlanetHostMass(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostMass;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star mass");

            facade.SortInfo(min, max, isAscending, filterByRadius, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pela idade da sua estrela.
        public void SearchByPlanetHostAge(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostAge;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star age");

            facade.SortInfo(min, max, isAscending, filterByHostAge, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pela velocidade de rotação da sua estrela.
        public void SearchByPlanetHostVsin(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostVsin;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star rotation speed");

            facade.SortInfo(min, max, isAscending, filterByRadius, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pelo período de rotação da sua estrela.
        public void SearchByPlanetHostRotp(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostRotp;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star rotation period");

            facade.SortInfo(min, max, isAscending, filterByHostRotp, orderByFunc, secondOrderByFunc);
        }

        // Método de pesquisa de planetas pela distância do sol até a sua estrela.
        public void SearchByPlanetHostDist(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostDist;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by distance from the sun to the host star");

            facade.SortInfo(min, max, isAscending, filterByRadius, orderByFunc, secondOrderByFunc);
        }

        // Inicializar as variáveis.
        public PlanetSearcher()
        {
            facade = new Facade();
        }
    }
}
