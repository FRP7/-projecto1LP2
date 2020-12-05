﻿using System;
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

        private void CheckField(PlanetField fields) {
            if (fields == PlanetField.Pl_Name) {
                orderByFunc = item => item.Value.Pl_Name;
            }
            if (fields == PlanetField.HostName) {
                orderByFunc = item => item.Value.HostName;
            }
            if (fields == PlanetField.DiscoveryMethod) {
                orderByFunc = item => item.Value.DiscoveryMethod;
            }
            if (fields == PlanetField.Disc_Year) {
                orderByFunc = item => item.Value.Disc_Year;
            }
            if (fields == PlanetField.Pl_Orbper) {
                orderByFunc = item => item.Value.Pl_Orbper;
            }
            if (fields == PlanetField.Pl_Rade) {
                orderByFunc = item => item.Value.Pl_Rade;
            }
            if (fields == PlanetField.Pl_Masse) {
                orderByFunc = item => item.Value.Pl_Masse;
            }
            if (fields == PlanetField.Pl_Eqt) {
                orderByFunc = item => item.Value.Pl_Eqt;
            }
            if (fields == PlanetField.St_Teff) {
                orderByFunc = item => item.Value.St_Teff;
            }
            if (fields == PlanetField.St_Rad) {
                orderByFunc = item => item.Value.St_Rad;
            }
            if (fields == PlanetField.St_Mass) {
                orderByFunc = item => item.Value.St_Mass;
            }
            if (fields == PlanetField.St_Age) {
                orderByFunc = item => item.Value.St_Age;
            }
            if (fields == PlanetField.St_Vsin) {
                orderByFunc = item => item.Value.St_Vsin;
            }
            if (fields == PlanetField.St_Rotp) {
                orderByFunc = item => item.Value.St_Rotp;
            }
            if (fields == PlanetField.Sy_Dist) {
                orderByFunc = item => item.Value.Sy_Dist;
            }
        }

        private void SecondField(PlanetField fields) {
            if (fields == PlanetField.Pl_Name) {
                orderByFunc = item => item.Value.HostName;
            }
            if (fields == PlanetField.HostName) {
                orderByFunc = item => item.Value.DiscoveryMethod;
            }
            if (fields == PlanetField.DiscoveryMethod) {
                orderByFunc = item => item.Value.Disc_Year;
            }
            if (fields == PlanetField.Disc_Year) {
                orderByFunc = item => item.Value.Pl_Orbper;
            }
            if (fields == PlanetField.Pl_Orbper) {
                orderByFunc = item => item.Value.Pl_Rade;
            }
            if (fields == PlanetField.Pl_Rade) {
                orderByFunc = item => item.Value.Pl_Masse;
            }
            if (fields == PlanetField.Pl_Masse) {
                orderByFunc = item => item.Value.Pl_Eqt;
            }
            if (fields == PlanetField.Pl_Eqt) {
                orderByFunc = item => item.Value.St_Teff;
            }
            if (fields == PlanetField.St_Teff) {
                orderByFunc = item => item.Value.St_Rad;
            }
            if (fields == PlanetField.St_Rad) {
                orderByFunc = item => item.Value.St_Mass;
            }
            if (fields == PlanetField.St_Mass) {
                orderByFunc = item => item.Value.St_Age;
            }
            if (fields == PlanetField.St_Age) {
                orderByFunc = item => item.Value.St_Vsin;
            }
            if (fields == PlanetField.St_Vsin) {
                orderByFunc = item => item.Value.St_Rotp;
            }
            if (fields == PlanetField.St_Rotp) {
                orderByFunc = item => item.Value.Sy_Dist;
            }
            if (fields == PlanetField.Sy_Dist) {
                orderByFunc = item => item.Value.St_Rotp;
            }
        }

        // Método de pesquisa de planetas pelo nome.
        public void SearchByPlanetName(string input, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByName;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by name");

            if (input != null)
            {
                if (isAscending)
                {
                    filterByName =
                        (from item in filterByName
                         where item.Value.Pl_Name.StartsWith(input)
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByName =
                        (from item in filterByName
                         where item.Value.Pl_Name.StartsWith(input)
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByName)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByName)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.HostName,-30}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByName.Count);
        }

        // Método de pesquisa de planetas pelo nome das suas estrelas.
        public void SearchByPlanetHostName(string input, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostName;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by host star");

            if (input != null)
            {
                if (isAscending)
                {
                    filterByHostName =
                        (from item in filterByHostName
                         where item.Value.HostName.StartsWith(input)
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostName =
                        (from item in filterByHostName
                         where item.Value.HostName.StartsWith(input)
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostName)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star: {item.Value.HostName,-30}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostName)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star: {item.Value.HostName,-30}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByHostName.Count);
        }

        // Método de pesquisa de planetas pelo método de descoberta.
        public void SearchByPlanetDiscoveryMethod(string input, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByDiscoveryMethod; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by discovery method");

            if (input != null)
            {
                if (isAscending)
                {
                    filterByDiscoveryMethod =
                        (from item in filterByDiscoveryMethod
                         where item.Value.DiscoveryMethod.StartsWith(input)
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByDiscoveryMethod =
                        (from item in filterByDiscoveryMethod
                         where item.Value.DiscoveryMethod.StartsWith(input)
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryMethod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery method: {item.Value.DiscoveryMethod,-20}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryMethod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery method: {item.Value.DiscoveryMethod,-20}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByDiscoveryMethod.Count);
        }

        // Método de pesquisa de planetas pelo ano de descoberta.
        public void SearchByPlanetDiscoveryYear(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByDiscoveryYear;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by discovery year");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByDiscoveryYear =
                        (from item in filterByDiscoveryYear
                         where item.Value.Disc_Year < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByDiscoveryYear =
                        (from item in filterByDiscoveryYear
                         where item.Value.Disc_Year < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryYear)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-4}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByDiscoveryYear =
                        (from item in filterByDiscoveryYear
                         where item.Value.Disc_Year > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByDiscoveryYear =
                        (from item in filterByDiscoveryYear
                         where item.Value.Disc_Year > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryYear)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-4}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByDiscoveryYear =
                        (from item in filterByDiscoveryYear
                         where item.Value.Disc_Year > min && item.Value.Disc_Year < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByDiscoveryYear =
                        (from item in filterByDiscoveryYear
                         where item.Value.Disc_Year > min && item.Value.Disc_Year < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryYear)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-4}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByDiscoveryYear)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-4}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByDiscoveryYear.Count);
        }

        // Método de pesquisa de planetas pelo periodo de orbita.
        public void SearchByPlanetOrbitalPeriod(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByOrbitalPeriod;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by orbital period");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByOrbitalPeriod =
                        (from item in filterByOrbitalPeriod
                         where item.Value.Pl_Orbper < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByOrbitalPeriod =
                        (from item in filterByOrbitalPeriod
                         where item.Value.Pl_Orbper < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByOrbitalPeriod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-2}" +
                     $" | Orbital Period: {item.Value.Pl_Orbper,-5}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByOrbitalPeriod =
                        (from item in filterByOrbitalPeriod
                         where item.Value.Pl_Orbper > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByOrbitalPeriod =
                        (from item in filterByOrbitalPeriod
                         where item.Value.Pl_Orbper > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByOrbitalPeriod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-2}" +
                     $" | Orbital Period: {item.Value.Pl_Orbper,-5}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByOrbitalPeriod =
                        (from item in filterByOrbitalPeriod
                         where item.Value.Pl_Orbper > min && item.Value.Pl_Orbper < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByOrbitalPeriod =
                        (from item in filterByOrbitalPeriod
                         where item.Value.Pl_Orbper > min && item.Value.Pl_Orbper < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByOrbitalPeriod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-2}" +
                     $" | Orbital Period: {item.Value.Pl_Orbper,-5}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByOrbitalPeriod)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-2}" +
                     $" | Orbital Period: {item.Value.Pl_Orbper,-5}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByOrbitalPeriod.Count);
        }

        // Método de pesquisa de planetas pelo raio.
        public void SearchByPlanetRadius(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByRadius;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by radius");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByRadius =
                        (from item in filterByRadius
                         where item.Value.Pl_Rade < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByRadius =
                        (from item in filterByRadius
                         where item.Value.Pl_Rade < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByRadius)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Radius: {item.Value.Pl_Rade,-3}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByRadius =
                        (from item in filterByRadius
                         where item.Value.Pl_Rade > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByRadius =
                        (from item in filterByRadius
                         where item.Value.Pl_Rade > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByRadius)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Radius: {item.Value.Pl_Rade,-3}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByRadius =
                        (from item in filterByRadius
                         where item.Value.Pl_Rade > min && item.Value.Pl_Rade < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByRadius =
                        (from item in filterByRadius
                         where item.Value.Pl_Rade > min && item.Value.Pl_Rade < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByRadius)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Radius: {item.Value.Pl_Rade,-3}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByRadius)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Radius: {item.Value.Pl_Rade,-3}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByRadius.Count);
        }

        // Método de pesquisa de planetas pelo raio da sua estrela.
        public void SearchByPlanetHostRad(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostRad;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet hosting star radius");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByHostRad =
                        (from item in filterByHostRad
                         where item.Value.St_Rad < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostRad =
                        (from item in filterByHostRad
                         where item.Value.St_Rad < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostRad)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Radius: {item.Value.St_Rad,-20}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByHostRad =
                        (from item in filterByHostRad
                         where item.Value.St_Rad > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostRad =
                        (from item in filterByHostRad
                         where item.Value.St_Rad > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostRad)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Radius: {item.Value.St_Rad,-20}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByHostRad =
                        (from item in filterByHostRad
                         where item.Value.St_Rad > min && item.Value.St_Rad < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostRad =
                        (from item in filterByHostRad
                         where item.Value.St_Rad > min && item.Value.St_Rad < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostRad)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Radius: {item.Value.St_Rad,-20}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostRad)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Radius: {item.Value.St_Rad,-20}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByHostRad.Count);
        }

        // Método de pesquisa de planetas pela temperatura de equilibrio.
        public void SearchByPlanetEqt(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByEqt;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by equilibrium temperature");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByEqt =
                        (from item in filterByEqt
                         where item.Value.Pl_Eqt < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByEqt =
                        (from item in filterByEqt
                         where item.Value.Pl_Eqt < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByEqt)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Equlibrium Temperature: {item.Value.Pl_Eqt,-5}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByEqt =
                        (from item in filterByEqt
                         where item.Value.Pl_Eqt > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByEqt =
                        (from item in filterByEqt
                         where item.Value.Pl_Eqt > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByEqt)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Equlibrium Temperature: {item.Value.Pl_Eqt,-5}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByEqt =
                        (from item in filterByEqt
                         where item.Value.Pl_Eqt > min && item.Value.Pl_Eqt < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByEqt =
                        (from item in filterByEqt
                         where item.Value.Pl_Eqt > min && item.Value.Pl_Eqt < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByEqt)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Equlibrium Temperature: {item.Value.Pl_Eqt,-5}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByEqt)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Equlibrium Temperature: {item.Value.Pl_Eqt,-5}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByEqt.Count);
        }

        // Método de pesquisa de planetas pela temperatura efetiva da sua estrela.
        public void SearchByPlanetHostTeff(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostTeff;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by the planet hosting star temperature");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByHostTeff =
                        (from item in filterByHostTeff
                         where item.Value.St_Teff < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostTeff =
                        (from item in filterByHostTeff
                         where item.Value.St_Teff < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostTeff)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Temperature: {item.Value.St_Teff,-5}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByHostTeff =
                        (from item in filterByHostTeff
                         where item.Value.St_Teff > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostTeff =
                        (from item in filterByHostTeff
                         where item.Value.St_Teff > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostTeff)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Temperature: {item.Value.St_Teff,-5}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByHostTeff =
                        (from item in filterByHostTeff
                         where item.Value.St_Teff > min && item.Value.St_Teff < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostTeff =
                        (from item in filterByHostTeff
                         where item.Value.St_Teff > min && item.Value.St_Teff < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostTeff)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Temperature: {item.Value.St_Teff,-5}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostTeff)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Temperature: {item.Value.St_Teff,-5}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByHostTeff.Count);
        }

        // Método de pesquisa de planetas pela massa.
        public void SearchByPlanetMass(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByMass;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by mass");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByMass =
                        (from item in filterByMass
                         where item.Value.Pl_Masse < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByMass =
                        (from item in filterByMass
                         where item.Value.Pl_Masse < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Mass: {item.Value.Pl_Masse,-3}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByMass =
                        (from item in filterByMass
                         where item.Value.Pl_Masse > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByMass =
                        (from item in filterByMass
                         where item.Value.Pl_Masse > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Mass: {item.Value.Pl_Masse,-3}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByMass =
                        (from item in filterByMass
                         where item.Value.Pl_Masse > min && item.Value.Pl_Masse < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByMass =
                        (from item in filterByMass
                         where item.Value.Pl_Masse < max && item.Value.Pl_Masse < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Mass: {item.Value.Pl_Masse,-3}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Mass: {item.Value.Pl_Masse,-3}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByMass.Count);
        }

        // Método de pesquisa de planetas pela massa da sua estrela.
        public void SearchByPlanetHostMass(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostMass;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star mass");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByHostMass =
                        (from item in filterByHostMass
                         where item.Value.St_Mass < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostMass =
                        (from item in filterByHostMass
                         where item.Value.St_Mass < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Mass: {item.Value.St_Mass,-20}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByHostMass =
                        (from item in filterByHostMass
                         where item.Value.St_Mass > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostMass =
                        (from item in filterByHostMass
                         where item.Value.St_Mass > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Mass: {item.Value.St_Mass,-20}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByHostMass =
                        (from item in filterByHostMass
                         where item.Value.St_Mass > min && item.Value.St_Mass < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostMass =
                        (from item in filterByHostMass
                         where item.Value.St_Mass > min && item.Value.St_Mass < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Mass: {item.Value.St_Mass,-20}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostMass)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Mass: {item.Value.St_Mass,-20}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByHostMass.Count);
        }

        // Método de pesquisa de planetas pela idade da sua estrela.
        public void SearchByPlanetHostAge(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostAge;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star age");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByHostAge =
                        (from item in filterByHostAge
                         where item.Value.St_Age < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostAge =
                        (from item in filterByHostAge
                         where item.Value.St_Age < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostAge)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Age: {item.Value.St_Age,-10}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByHostAge =
                        (from item in filterByHostAge
                         where item.Value.St_Age > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostAge =
                        (from item in filterByHostAge
                         where item.Value.St_Age > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostAge)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Age: {item.Value.St_Age,-10}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByHostAge =
                        (from item in filterByHostAge
                         where item.Value.St_Age > min && item.Value.St_Age < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostAge =
                        (from item in filterByHostAge
                         where item.Value.St_Age > min && item.Value.St_Age < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostAge)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Age: {item.Value.St_Age,-10}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostAge)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Age: {item.Value.St_Age,-10}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByHostAge.Count);
        }

        // Método de pesquisa de planetas pela velocidade de rotação da sua estrela.
        public void SearchByPlanetHostVsin(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostVsin;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star rotation speed");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByHostVsin =
                        (from item in filterByHostVsin
                         where item.Value.St_Vsin < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostVsin =
                        (from item in filterByHostVsin
                         where item.Value.St_Vsin < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostVsin)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Rotation velocity: {item.Value.St_Vsin,-5}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByHostVsin =
                        (from item in filterByHostVsin
                         where item.Value.St_Vsin > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostVsin =
                        (from item in filterByHostVsin
                         where item.Value.St_Vsin > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostVsin)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Rotation velocity: {item.Value.St_Vsin,-5}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByHostVsin =
                        (from item in filterByHostVsin
                         where item.Value.St_Vsin > min && item.Value.St_Vsin < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostVsin =
                         (from item in filterByHostVsin
                          where item.Value.St_Vsin > min && item.Value.St_Vsin < max
                          select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostVsin)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Rotation velocity: {item.Value.St_Vsin,-5}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostVsin)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Rotation velocity: {item.Value.St_Vsin,-5}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByHostVsin.Count);
        }

        // Método de pesquisa de planetas pelo período de rotação da sua estrela.
        public void SearchByPlanetHostRotp(int? min, int? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostRotp;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by planet host star rotation period");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByHostRotp =
                        (from item in filterByHostRotp
                         where item.Value.St_Rotp < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostRotp =
                        (from item in filterByHostRotp
                         where item.Value.St_Rotp < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostRotp)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Rotation period: {item.Value.St_Rotp,-4}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByHostRotp =
                        (from item in filterByHostRotp
                         where item.Value.St_Rotp > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostRotp =
                        (from item in filterByHostRotp
                         where item.Value.St_Rotp > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostRotp)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Rotation period: {item.Value.St_Rotp,-4}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByHostRotp =
                        (from item in filterByHostRotp
                         where item.Value.St_Rotp > min && item.Value.St_Rotp < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostRotp =
                        (from item in filterByHostRotp
                         where item.Value.St_Rotp > min && item.Value.St_Rotp < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostRotp)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Rotation period: {item.Value.St_Rotp,-4}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostRotp)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Rotation period: {item.Value.St_Rotp,-4}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByHostRotp.Count);
        }

        // Método de pesquisa de planetas pela distância do sol até a sua estrela.
        public void SearchByPlanetHostDist(double? min, double? max, bool isAscending, PlanetField fields)
        {
            Facade.planetList = filterByHostDist;

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filter by distance from the sun to the host star");

            if (min == null && max != null)
            {
                if (isAscending)
                {
                    filterByHostDist =
                        (from item in filterByHostDist
                         where item.Value.Sy_Dist < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostDist =
                        (from item in filterByHostDist
                         where item.Value.Sy_Dist < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostDist)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Distance to the Sun: {item.Value.Sy_Dist,-5}"));
                }
            }
            else if (min != null && max == null)
            {
                if (isAscending)
                {
                    filterByHostDist =
                        (from item in filterByHostDist
                         where item.Value.Sy_Dist > min
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostDist =
                        (from item in filterByHostDist
                         where item.Value.Sy_Dist > min
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostDist)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Distance to the Sun: {item.Value.Sy_Dist,-5}"));
                }
            }
            else if (min != null && max != null)
            {
                if (isAscending)
                {
                    filterByHostDist =
                        (from item in filterByHostDist
                         where item.Value.Sy_Dist > min && item.Value.Sy_Dist < max
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                }
                else
                {
                    filterByHostDist =
                        (from item in filterByHostDist
                         where item.Value.Sy_Dist > min && item.Value.Sy_Dist < max
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostDist)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Distance to the Sun: {item.Value.Sy_Dist,-5}"));
                }
            }
            else
            {
                // Imprimir
                foreach (KeyValuePair<int, Planet> item in filterByHostDist)
                {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Planet: {item.Value.Pl_Name,-30}" +
                     $" | Host Star Distance to the Sun: {item.Value.Sy_Dist,-5}"));
                }
            }
            Console.WriteLine("Dicionary filter: " + filterByHostDist.Count);
        }

        // Inicializar as variáveis.
        public PlanetSearcher()
        {
            facade = new Facade();
        }
    }
}
