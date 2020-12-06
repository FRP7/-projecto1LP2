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
        private Func<KeyValuePair<int, Star>, Object> secondOrderByFunc;

        private void CheckField(StarFields fields) {
            if(fields == StarFields.HostName) {
                orderByFunc = item => item.Value.HostName.Length;
            }
            if (fields == StarFields.DiscoveryMethod) {
                orderByFunc = item => item.Value.DiscoveryMethod.Length;
            }
            if (fields == StarFields.Disc_Year) {
                orderByFunc = item => item.Value.Disc_Year;
            }
            if (fields == StarFields.St_Teff) {
                orderByFunc = item => item.Value.St_Teff;
            }
            if (fields == StarFields.St_Rad) {
                orderByFunc = item => item.Value.St_Rad;
            }
            if (fields == StarFields.St_Mass) {
                orderByFunc = item => item.Value.St_Mass;
            }
            if (fields == StarFields.St_Age) {
                orderByFunc = item => item.Value.St_Age;
            }
            if (fields == StarFields.St_Vsin) {
                orderByFunc = item => item.Value.St_Vsin;
            }
            if (fields == StarFields.St_Rotp) {
                orderByFunc = item => item.Value.St_Rotp;
            }
            if (fields == StarFields.Sy_Dist) {
                orderByFunc = item => item.Value.Sy_Dist;
            }
            if (fields == StarFields.St_PlCount) {
                orderByFunc = item => item.Value.St_PlCount;
            }
        }

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

        // Método de pesquisa de estrelas pelo nome.
        public void SearchByName(string input, bool? isAscending, StarFields fields) {
            Facade.starList = filterByName; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo nome");



            if (input != null) {
                if (isAscending == true) {

                    filterByName =
                        (from item in filterByName
                         where item.Value.HostName.StartsWith(input.ToUpper())
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);

                } else if (isAscending == false) {
                    filterByName =
                        (from item in filterByName
                         where item.Value.HostName.StartsWith(input.ToUpper())
                         select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByName) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Planets: {item.Value.St_PlCount,-2}  | Teff: {item.Value.St_Teff}  | Year: {item.Value.Disc_Year}"));
                }

            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByName) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Planets: {item.Value.St_PlCount,-2} | Teff: { item.Value.St_Teff}  | Year: {item.Value.Disc_Year}"));
                }
            }
            Console.WriteLine("Dicionário filtro: " + filterByName.Count);
        }

        // Método de pesquisa de estrelas pelo método de descoberta.
        public void SearchByDiscoveryMethod(string input, bool? isAscending, StarFields fields) {
            Facade.starList = filterByDiscoveryMethod; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo método de descoberta");

            if (input != null) {
                if (isAscending == true) {
                    filterByDiscoveryMethod =
                        (from item in filterByDiscoveryMethod
                         where item.Value.DiscoveryMethod
                         .StartsWith(input.ToUpper())
                         select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                         .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByDiscoveryMethod =
                       (from item in filterByDiscoveryMethod
                        where item.Value.DiscoveryMethod
                        .StartsWith(input.ToUpper())
                        select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                        .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByDiscoveryMethod) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Discovery method: {item.Value.DiscoveryMethod,-2} | Teff: { item.Value.St_Teff}"));
                }
            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByDiscoveryMethod) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Discovery method: {item.Value.DiscoveryMethod,-2} | Teff: { item.Value.St_Teff}"));
                }
            }
            Console.WriteLine("Dicionário filtro: " + filterByDiscoveryMethod.Count);
        }

        // Método de pesquisa de estrelas pelo ano de descoberta.
        public void SearchByDiscoveryYear(int? min, int? max, bool? isAscending, StarFields fields) {
            Facade.starList = filterByDiscoveryYear; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo ano de descoberta");

            if (min == null && max != null) {
                if (isAscending == true) {
                    filterByDiscoveryYear =
                   (from item in filterByDiscoveryYear
                    where item.Value.Disc_Year < max
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByDiscoveryYear =
                  (from item in filterByDiscoveryYear
                   where item.Value.Disc_Year < max
                   select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                   .ToDictionary(p => p.Key, p => p.Value);
                } 
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByDiscoveryYear) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-2} | Teff: { item.Value.St_Teff}"));
                }
            } else if (min != null && max == null) {
                if (isAscending == true) {
                    filterByDiscoveryYear =
                   (from item in filterByDiscoveryYear
                    where item.Value.Disc_Year > min
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByDiscoveryYear =
               (from item in filterByDiscoveryYear
                where item.Value.Disc_Year > min
                select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                .ToDictionary(p => p.Key, p => p.Value);
                } 
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByDiscoveryYear) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-2} | Teff: { item.Value.St_Teff}"));
                }
            } else if (min != null && max != null) {
                if (isAscending == true) {
                    filterByDiscoveryYear =
                  (from item in filterByDiscoveryYear
                   where item.Value.Disc_Year > min && item.Value.Disc_Year < max
                   select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                   .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByDiscoveryYear =
                 (from item in filterByDiscoveryYear
                  where item.Value.Disc_Year > min && item.Value.Disc_Year < max
                  select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                  .ToDictionary(p => p.Key, p => p.Value);
                } 
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByDiscoveryYear) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-2} | Teff: { item.Value.St_Teff}"));
                }
            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByDiscoveryYear) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Discovery year: {item.Value.Disc_Year,-2} | Teff: { item.Value.St_Teff}"));
                }
            }

            Console.WriteLine("Dicionário filtro: " + filterByDiscoveryYear.Count);
        }

        // Método de pesquisa de estrelas pela temperatura.
        public void SearchByTeff(double? min, double? max, bool? isAscending, StarFields fields) {
            Facade.starList = filterByTaff; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pela temperatura");

            if (min == null && max != null) {
                if (isAscending == true) {
                    filterByTaff =
                   (from item in filterByTaff
                    where item.Value.St_Teff < max
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByTaff =
                 (from item in filterByTaff
                  where item.Value.St_Teff < max
                  select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                  .ToDictionary(p => p.Key, p => p.Value);
                } 
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByTaff) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Temperature: {item.Value.St_Teff,-2}"));
                }
            } else if (min != null && max == null) {
                if (isAscending == true) {
                    filterByTaff =
                   (from item in filterByTaff
                    where item.Value.St_Teff > min
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByTaff =
               (from item in filterByTaff
                where item.Value.St_Teff > min
                select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                .ToDictionary(p => p.Key, p => p.Value);
                } 
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByTaff) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Temperature: {item.Value.St_Teff,-2}"));
                }
            } else if (min != null && max != null) {
                if (isAscending == true) {
                    filterByTaff =
                   (from item in filterByTaff
                    where item.Value.St_Teff > min && item.Value.St_Teff < max
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByTaff =
                 (from item in filterByTaff
                  where item.Value.St_Teff > min && item.Value.St_Teff < max
                  select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                  .ToDictionary(p => p.Key, p => p.Value);
                }
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByTaff) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Temperature: {item.Value.St_Teff,-2}"));
                }
            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByTaff) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Temperature: {item.Value.St_Teff,-2}"));
                }
            }
            Console.WriteLine("Dicionário filtro: " + filterByTaff.Count);
        }

        // Método de pesquisa de estrelas pelo raio.
        public void SearchByRad(double? min, double? max, bool? isAscending, StarFields fields) {
            Facade.starList = filterByRad; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo raio");

            if (min != null && max == null) {
                if (isAscending == true) {
                    filterByRad =
                                   (from item in filterByRad
                                    where item.Value.St_Rad > min
                                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    (from item in filterByRad
                     where item.Value.St_Rad > min
                     select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x)).
                                    ToDictionary(p => p.Key, p => p.Value);
                } 
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByRad) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Radius: {item.Value.St_Rad,-2}"));
                }
            } else if (min == null && max != null) {
                if (isAscending == true) {
                    filterByRad =
                                  (from item in filterByRad
                                   where item.Value.St_Rad < max
                                   select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                                   .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByRad =
                                 (from item in filterByRad
                                  where item.Value.St_Rad < max
                                  select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                                  .ToDictionary(p => p.Key, p => p.Value);
                } 
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByRad) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Radius: {item.Value.St_Rad,-2}"));
                }
            } else if (min != null && max != null) {
                if (isAscending == true) {
                    filterByRad =
                   (from item in filterByRad
                    where item.Value.St_Rad > min && item.Value.St_Rad < max
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByRad =
                  (from item in filterByRad
                   where item.Value.St_Rad > min && item.Value.St_Rad < max
                   select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                   .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByRad) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Radius: {item.Value.St_Rad,-2}"));
                }
            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByRad) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Radius: {item.Value.St_Rad,-2}"));
                }
            }

            Console.WriteLine("Dicionário filtro: " + filterByRad.Count);
        }

        // Método de pesquisa de estrelas pela massa.
        public void SearchByMass(double? min, double? max, bool? isAscending, StarFields fields) {
            Facade.starList = filterByMass; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pela massa");

            if (min != null && max == null) {
                if (isAscending == true) {
                    filterByMass =
                  (from item in filterByMass
                   where item.Value.St_Mass > min
                   select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                   .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByMass =
               (from item in filterByMass
                where item.Value.St_Mass > min
                select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByMass) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Mass: {item.Value.St_Mass,-2}"));
                }
            } else if (min == null && max != null) {
                if (isAscending == true) {
                    filterByMass =
                  (from item in filterByMass
                   where item.Value.St_Mass < max
                   select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                   .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByMass =
                 (from item in filterByMass
                  where item.Value.St_Mass < max
                  select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                  .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByMass) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Mass: {item.Value.St_Mass,-2}"));
                }
            } else if (min != null && max != null) {
                if (isAscending == true) {
                    filterByMass =
                  (from item in filterByMass
                   where item.Value.St_Mass > min && item.Value.St_Mass < max
                   select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                   .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByMass =
                  (from item in filterByMass
                   where item.Value.St_Mass > min && item.Value.St_Mass < max
                   select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                   .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByMass) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Mass: {item.Value.St_Mass,-2}"));
                }
            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByMass) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Mass: {item.Value.St_Mass,-2}"));
                }
            }
            Console.WriteLine("Dicionário filtro: " + filterByMass.Count);
        }

        // Método de pesquisa de estrelas pela idade.
        public void SearchByAge(double? min, double? max, bool? isAscending, StarFields fields) {
            Facade.starList = filterByAge; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pela idade");

            if (min != null && max == null) {
                if (isAscending == true) {
                    filterByAge =
                   (from item in filterByAge
                    where item.Value.St_Age > min
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByAge =
                   (from item in filterByAge
                    where item.Value.St_Age > min
                    select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByAge) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Age: {item.Value.St_Age,-2}"));
                }
            } else if (min == null && max != null) {
                if (isAscending == true) {
                    filterByAge =
                   (from item in filterByAge
                    where item.Value.St_Age < max
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == true) {
                    filterByAge =
                   (from item in filterByAge
                    where item.Value.St_Age < max
                    select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByAge) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Age: {item.Value.St_Age,-2}"));
                }
            } else if (min != null && max != null) {
                if (isAscending == true) {
                    filterByAge =
                   (from item in filterByAge
                    where item.Value.St_Age > min && item.Value.St_Age < max
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == true) {
                    filterByAge =
                   (from item in filterByAge
                    where item.Value.St_Age > min && item.Value.St_Age < max
                    select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByAge) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Age: {item.Value.St_Age,-2}"));
                }
            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByAge) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Age: {item.Value.St_Age,-2}"));
                }
            }
            Console.WriteLine("Dicionário filtro: " + filterByAge.Count);
        }

        // Método de pesquisa de estrelas pela velocidade de rotação.
        public void SearchByVsin(double? min, double? max, bool? isAscending, StarFields fields) {
            Facade.starList = filterByVsin; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pela velocidade de rotação");

            if (min != null && max == null) {
                if (isAscending == true) {
                    filterByVsin =
                                    (from item in filterByVsin
                                     where item.Value.St_Vsin > min
                                     select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                                     .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == true) {
                    filterByVsin =
                                    (from item in filterByVsin
                                     where item.Value.St_Vsin > min
                                     select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                                     .ToDictionary(p => p.Key, p => p.Value);
                }

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByVsin) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Rotation velocity: {item.Value.St_Vsin,-2}"));
                }
            } else if (min == null && max != null) {
                if (isAscending == true) {
                    filterByVsin =
                    (from item in filterByVsin
                     where item.Value.St_Vsin < max
                     select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                     .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByVsin =
                    (from item in filterByVsin
                     where item.Value.St_Vsin < max
                     select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                     .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByVsin) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Rotation velocity: {item.Value.St_Vsin,-2}"));
                }
            } else if (min != null && max != null) {
                if (isAscending == true) {
                    filterByVsin =
                    (from item in filterByVsin
                     where item.Value.St_Vsin > min && item.Value.St_Vsin < max
                     select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                     .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByVsin =
                    (from item in filterByVsin
                     where item.Value.St_Vsin > min && item.Value.St_Vsin < max
                     select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                     .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByVsin) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Rotation velocity: {item.Value.St_Vsin,-2}"));
                }
            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByVsin) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Rotation velocity: {item.Value.St_Vsin,-2}"));
                }
            }
            Console.WriteLine("Dicionário filtro: " + filterByVsin.Count);
        }

        // Método de pesquisa de estrelas pelo período de rotação.
        public void SearchByRotp(double? min, double? max, bool? isAscending, StarFields fields) {
            Facade.starList = filterByRotp; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo período de rotação");

            if (min != null && max == null) {
                if (isAscending == true) {
                    filterByRotp =
                   (from item in filterByRotp
                    where item.Value.St_Rotp > min
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByRotp =
                   (from item in filterByRotp
                    where item.Value.St_Rotp > min
                    select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } 
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByRotp) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Rotation period: {item.Value.St_Rotp,-2}"));
                }
            } else if (min == null && max != null) {
                if (isAscending == true) {
                    filterByRotp =
                   (from item in filterByRotp
                    where item.Value.St_Rotp < max
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByRotp =
                   (from item in filterByRotp
                    where item.Value.St_Rotp < max
                    select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                }

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByRotp) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Rotation period: {item.Value.St_Rotp,-2}"));
                }
            } else if (min != null && max != null) {
                if (isAscending == true) {
                    filterByRotp =
                   (from item in filterByRotp
                    where item.Value.St_Rotp > min && item.Value.St_Rotp < max
                    select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByRotp =
                   (from item in filterByRotp
                    where item.Value.St_Rotp > min && item.Value.St_Rotp < max
                    select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                    .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByRotp) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Rotation period: {item.Value.St_Rotp,-2}"));
                }
            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByRotp) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Rotation period: {item.Value.St_Rotp,-2}"));
                }
            }
            Console.WriteLine("Dicionário filtro: " + filterByRotp.Count);
        }

        // Método de pesquisa de estrelas pela distância.
        public void SearchByDist(double? min, double? max, bool? isAscending, StarFields fields) {
            Facade.starList = filterByDyst; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pela distância");

            if (min != null && max == null) {
                if (isAscending == true) {
                    filterByDyst =
                    (from item in filterByDyst
                     where item.Value.Sy_Dist > min
                     select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                     .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByDyst =
                    (from item in filterByDyst
                     where item.Value.Sy_Dist > min
                     select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                     .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByDyst) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Distance: {item.Value.Sy_Dist,-2}"));
                }
            } else if (min == null && max != null) {
                if (isAscending == true) {
                    filterByDyst =
                    (from item in filterByDyst
                     where item.Value.Sy_Dist < max
                     select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                     .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByDyst =
                    (from item in filterByDyst
                     where item.Value.Sy_Dist < max
                     select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                     .ToDictionary(p => p.Key, p => p.Value);
                }

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByDyst) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Distance: {item.Value.Sy_Dist,-2}"));
                }
            } else if (min != null && max != null) {
                if (isAscending == true) {
                    filterByDyst =
                    (from item in filterByDyst
                     where item.Value.Sy_Dist > min && item.Value.Sy_Dist < max
                     select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                     .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByDyst =
                    (from item in filterByDyst
                     where item.Value.Sy_Dist > min && item.Value.Sy_Dist < max
                     select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                     .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByDyst) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Distance: {item.Value.Sy_Dist,-2}"));
                }
            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByDyst) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Distance: {item.Value.Sy_Dist,-2}"));
                }
            }
            Console.WriteLine("Dicionário filtro: " + filterByDyst.Count);
        }

        // Método de pesquisa de estrelas pela quantidade de planetas.
        public void SearchByPlCount(double? min, double? max, bool? isAscending, StarFields fields) {
            Facade.starList = filterByPlCount; // obrigatório!!!!

            CheckField(fields);

            SecondField(fields);

            Console.WriteLine("Filtrar pelo número de planetas");

            if (min != null && max == null) {
                if (isAscending == true) {
                    filterByPlCount =
                 (from item in filterByPlCount
                  where item.Value.St_PlCount > min
                  select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                  .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByPlCount =
                 (from item in filterByPlCount
                  where item.Value.St_PlCount > min
                  select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                  .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByPlCount) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Planet count: {item.Value.St_PlCount,-2}"));
                }
            } else if (min == null && max != null) {
                if (isAscending == true) {
                    filterByPlCount =
                 (from item in filterByPlCount
                  where item.Value.St_PlCount < max
                  select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                  .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByPlCount =
                 (from item in filterByPlCount
                  where item.Value.St_PlCount < max
                  select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                  .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByPlCount) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Planet count: {item.Value.St_PlCount,-2}"));
                }
            } else if (min != null && max != null) {
                if (isAscending == true) {
                    filterByPlCount =
                 (from item in filterByPlCount
                  where item.Value.St_PlCount > min && item.Value.St_PlCount < max
                  select item).OrderBy(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                  .ToDictionary(p => p.Key, p => p.Value);
                } else if (isAscending == false) {
                    filterByPlCount =
                 (from item in filterByPlCount
                  where item.Value.St_PlCount > min && item.Value.St_PlCount < max
                  select item).OrderByDescending(x => orderByFunc(x)).ThenBy(x => secondOrderByFunc(x))
                  .ToDictionary(p => p.Key, p => p.Value);
                } 

                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByPlCount) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Planet count: {item.Value.St_PlCount,-2}"));
                }
            } else {
                // Imprimir
                foreach (KeyValuePair<int, Star> item in filterByPlCount) {
                    Console.WriteLine(string.Format($"ID: " +
                        $"{item.Key,-5} | Star: {item.Value.HostName,-30}" +
                     $" | Planet count: {item.Value.St_PlCount,-2}"));
                }
            }
            Console.WriteLine("Dicionário filtro: " + filterByPlCount.Count);
        }

        // Inicializar as variáveis.
        public StarSearcher() {
            facade = new Facade();
        }
    }
}
