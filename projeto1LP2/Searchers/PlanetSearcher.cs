using System;
using System.Collections.Generic;

namespace projeto1LP2
{
    /// <summary>
    /// Classe onde vão estar os métodos de pesquisa de planetas.
    /// </summary>
    class PlanetSearcher
    {
        // Inicializar a Facade.
        private Facade facade;

        // Coleções de planetas de acordo com os filtros escolhidos.
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

        // Critério de ordenação.
        private Func<KeyValuePair<int, Planet>, Object> orderByFunc;

        // Critério de ordenação secundário.
        private Func<KeyValuePair<int, Planet>, Object> secondOrderByFunc;

        /// <summary>
        /// Verificar qual é o método de ordenação primário.
        /// </summary>
        /// <param name="fields"> Enum do critério de ordenação. </param>
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

        /// <summary>
        /// Verificar qual é o método de ordenação secundário.
        /// </summary>
        /// <param name="fields"> Enum do critério de ordenação secundário. 
        /// </param>
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

        /// <summary>
        /// Método de pesquisa de planetas pelo nome.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta.</param>
        public void SearchByPlanetName(string input, bool isAscending, 
            PlanetField fields)
        {
            Facade.planetList = filterByName;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet name");

            facade.PlanetSortName(input, isAscending, filterByName, orderByFunc
                , secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo nome das suas estrelas.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostName(string input, bool isAscending,
            PlanetField fields)
        {
            Facade.planetList = filterByHostName;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by host star");

            facade.PlanetSortHost(input, isAscending, filterByHostName, 
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo método de descoberta.
        /// </summary>
        /// <param name="input"> Input do user. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetDiscoveryMethod(string input, 
            bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByDiscoveryMethod;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by discovery method");

            facade.PlanetSortDiscMethod(input, isAscending, 
                filterByDiscoveryMethod, orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo ano de descoberta.
        /// </summary>
        /// <param name="min"> Ano mínimo. </param>
        /// <param name="max"> Ano máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetDiscoveryYear(int? min, int? max, 
            bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByDiscoveryYear;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by discovery year");

            facade.PlanetSortDiscYear(min, max, isAscending, 
                filterByDiscoveryYear, orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo periodo de orbita.
        /// </summary>
        /// <param name="min"> Período mínimo. </param>
        /// <param name="max"> Período máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetOrbitalPeriod(int? min, int? max,
            bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByOrbitalPeriod;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by orbital period");

            facade.PlanetSortOrbp(min, max, isAscending, filterByOrbitalPeriod,
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo raio.
        /// </summary>
        /// <param name="min"> Raio mínimo. </param>
        /// <param name="max"> Raio máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetRadius(double? min, double? max, 
            bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByRadius;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by radius");

            facade.PlanetSortRade(min, max, isAscending, filterByRadius,
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo raio da sua estrela.
        /// </summary>
        /// <param name="min"> Raio mínimo. </param>
        /// <param name="max">´Raio máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostRad(double? min, double? max,
            bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostRad;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet hosting star radius");

            facade.PlanetSortHostRad(min, max, isAscending, filterByRadius,
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela temperatura de equilibrio.
        /// </summary>
        /// <param name="min"> Temperatura mínima. </param>
        /// <param name="max"> Temperatura máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetEqt(int? min, int? max, bool isAscending,
            PlanetField fields)
        {
            Facade.planetList = filterByEqt;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by equilibrium temperature");

            facade.PlanetSortEqt(min, max, isAscending, filterByEqt,
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela temperatura efetiva da sua estrela.
        /// </summary>
        /// <param name="min"> Temperatura mínima. </param>
        /// <param name="max"> Temperatura máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostTeff(int? min, int? max, bool isAscending
            , PlanetField fields)
        {
            Facade.planetList = filterByHostTeff;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by the planet hosting star temperature");

            facade.PlanetSortHostTeff(min, max, isAscending, filterByHostTeff,
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela massa.
        /// </summary>
        /// <param name="min"> Massa mínima. </param>
        /// <param name="max"> Massa máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetMass(double? min, double? max, 
            bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByMass;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by mass");

            facade.PlanetSortPlMass(min, max, isAscending, filterByRadius, 
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela massa da sua estrela.
        /// </summary>
        /// <param name="min"> Massa mínima. </param>
        /// <param name="max"> Massa máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostMass(double? min, double? max,
            bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostMass;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star mass");

            facade.PlanetSortStMass(min, max, isAscending, filterByRadius, 
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela idade da sua estrela.
        /// </summary>
        /// <param name="min"> Idade mínima. </param>
        /// <param name="max"> Idade máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostAge(int? min, int? max, bool isAscending,
            PlanetField fields)
        {
            Facade.planetList = filterByHostAge;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star age");

            facade.PlanetSortStAge(min, max, isAscending, filterByHostAge,
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela velocidade de rotação da sua 
        ///estrela.
        /// </summary>
        /// <param name="min"> Velocidade mínima. </param>
        /// <param name="max"> Velocidade máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostVsin(double? min, double? max, 
            bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostVsin;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star rotation speed");

            facade.PlanetSortStVsin(min, max, isAscending, filterByRadius, 
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pelo período de rotação da sua 
        /// estrela.
        /// </summary>
        /// <param name="min"> Período mínimo. </param>
        /// <param name="max"> Período máximo. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostRotp(int? min, int? max, 
            bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostRotp;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star rotation period");

            facade.PlanetSortStRotp(min, max, isAscending, filterByHostRotp, 
                orderByFunc, secondOrderByFunc);
        }

        /// <summary>
        /// Método de pesquisa de planetas pela distância do sol até a sua
        /// estrela.
        /// </summary>
        /// <param name="min"> Distância mínima. </param>
        /// <param name="max"> Distância máxima. </param>
        /// <param name="isAscending"> Ordem de ordenação. </param>
        /// <param name="fields"> Campo do planeta. </param>
        public void SearchByPlanetHostDist(double? min, double? max,
            bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostDist;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by distance from the sun to the " +
                "host star");

            facade.PlanetSortStDyst(min, max, isAscending, filterByRadius,
                orderByFunc, secondOrderByFunc);
        }

        // Inicializar as variáveis.
        public PlanetSearcher()
        {
            facade = new Facade();
        }
    }
}
