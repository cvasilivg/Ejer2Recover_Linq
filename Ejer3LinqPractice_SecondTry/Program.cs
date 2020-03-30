using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice_SecondTry
{
    class Program
    {
        static List<Car> listaCoche = new List<Car>();

        static List<Car> Ejer1()
        {
            using (StreamReader streamReader = new StreamReader("Cars.json"))
            {
                string json = streamReader.ReadToEnd();
                listaCoche = JsonConvert.DeserializeObject<List<Car>>(json);
                return listaCoche;
            }
        }

        static void Ejer2()
        {
            var fabricante = listaCoche.GroupBy(x => x.Maker);

            foreach (var item in fabricante)
            {
                Console.WriteLine($"Fabricante: {item.Key}");
            }
        }

        static void Ejer3()
        {
            var colores = listaCoche.GroupBy(x => x.Color).Select(x => x.First());

            foreach (var item in colores)
            {
                if (!String.IsNullOrEmpty(item.Color)) // Hay varios colores que estan en null
                {
                    Console.WriteLine($"Color: {item.Color} Fabricante: {item.Maker} Modelo: {item.Model}");
                }
            }
        }

        static void Ejer4()
        {
            var colorVerde = listaCoche.Where(x => x.Color.Equals("Green"));

            foreach (var item in colorVerde)
            {
                Console.WriteLine($"Color: {item.Color} Fabricante: {item.Maker} Modelo: {item.Model}");
            }
        }

        static void Ejer5()
        {
            // Esto sirve para cambiar el formato decimal punto por coma...
            var currentCulture = System.Globalization.CultureInfo.InstalledUICulture;
            var numberFormat = (System.Globalization.NumberFormatInfo)currentCulture.NumberFormat.Clone();
            numberFormat.NumberDecimalSeparator = ".";

            double buscarLatitud;
            double buscarLongitud;

            // "Latitude":-6.7888012,"Longitude":111.466342
            Console.WriteLine($"Introduzca una latitud a buscar: ");
            buscarLatitud = Double.Parse(Console.ReadLine(), numberFormat);
            Console.WriteLine($"Introduzca una longitud a buscar: ");
            buscarLongitud = Double.Parse(Console.ReadLine(), numberFormat);

            var buscarLatitudLongitud = listaCoche.Where(x => x.Location.Latitude.Equals(buscarLatitud)  && x.Location.Longitude.Equals(buscarLongitud));

            foreach (var item in buscarLatitudLongitud)
            {
                if (item.Year.Equals(1992))
                {
                    Console.WriteLine($"Se encontró este coche, modelo {item.Model} del fabricante {item.Maker}," +
                        $" del año 1992 con esta latitud: {item.Location.Latitude} y longitud {item.Location.Longitude}");
                }
                else
                {
                    Console.WriteLine("No se encontró ningún coche en el 1992 con esa latitud y longitud.");
                }
            }

        }

        static void Ejer6()
        {
            var anioPosterior = listaCoche.Where(x => x.Year > 2001);

            foreach (var item in anioPosterior)
            {
                Console.WriteLine($"Fabricante: {item.Maker} Modelo: {item.Model}");
            }
        }

        static void Ejer7()
        {
            // Ni idea :((
        }

        static void Ejer8()
        {
            var colorAnioPosterior = listaCoche.Where(x => x.Color.Equals("Blue") && x.Year > 2000);

            foreach (var item in colorAnioPosterior)
            {
                Console.WriteLine($"Fabricante: {item.Maker} Modelo: {item.Model}");
            }
        }

        static void Ejer9()
        {
            var agruparFabricanteAnio = listaCoche.GroupBy(x => new { x.Maker, x.Year })
                .Select(x => new { Fabricante = x.Key.Maker, Anio = x.Key.Year })
                .OrderBy(x => x.Anio);

            foreach (var item in agruparFabricanteAnio)
            {
                if (!item.Anio.Equals(null))
                {
                    Console.WriteLine($"Fabricante: {item.Fabricante} Anio: {item.Anio}");
                }
            }
        }

        static void Ejer10()
        {
            var colorDisponibleSinDuplicar = listaCoche.GroupBy(x => new { x.Color }).Select(x => x.First());

            foreach (var item in colorDisponibleSinDuplicar)
            {
                if (!String.IsNullOrEmpty(item.Color))
                {
                    Console.WriteLine($"Fabricante: {item.Maker} Modelo: {item.Model} Color: {item.Color}");
                }
            }
        }

        static void Ejer11()
        {
            for (int i = 0; i < listaCoche.Count; i += 10)
            {
                var saltarDiezEnDiez = listaCoche.Skip(i).Take(10).Select(x => x.Model);

                foreach (var item in saltarDiezEnDiez)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
        }

        static void Ejer12()
        {
            var primerCocheFabricanteSuzuki = listaCoche.Where(x => x.Year > 2001 && x.Maker.Equals("Suzuki")).First();

            Console.WriteLine($"Modelo: {primerCocheFabricanteSuzuki.Model}");
        }

        static void Ejer13()
        {
            var cochesConAnio = listaCoche.Where(x => !x.Year.Equals(null));

            foreach (var item in cochesConAnio)
            {
                Console.WriteLine($"Fabricante: {item.Maker} Modelo: {item.Model} Anio: {item.Year}");
            }
        }

        static void Ejer14()
        {
            var cochesConColorRosa = listaCoche.Where(x => x.Color == "Pink").GroupBy(x => x.Year); // Equals no funciona aqui devuelve null ?¿

            foreach (var key in cochesConColorRosa)
            {
                foreach (var value in key)
                {
                    Console.WriteLine($"Fabricante: {value.Maker} Modelo: {value.Model} Anio: {value.Year} Color: {value.Color}");
                }
            }
        }

        static void Ejer15()
        {
            var cochesBMWSinAnioSinColor = listaCoche.Where(x => x.Maker.Equals("BMW") && String.IsNullOrEmpty(Convert.ToString(x.Year)) && String.IsNullOrEmpty(x.Color));

            foreach (var item in cochesBMWSinAnioSinColor)
            {
                Console.WriteLine($"Fabricante: {item.Maker} Modelo: {item.Model}");
            }
        }

        static void Ejer16()
        {
            // Abajo está
        }

        static void Main(string[] args)
        {
            Ejer1();

            // Ejer2();

            // Ejer3();

            // Ejer4();

            // Ejer5();

            // Ejer6();

            // Ejer7(); // Terminar

            // Ejer8();

            // Ejer9();

            // Ejer10();

            // Ejer11();

            // Ejer12();

            // Ejer13();

            // Ejer14();

            // Ejer15();

            // Ejer16();

            Console.ReadKey();
        }
    }
    public static class ExtensionMethods
    {
        static List<Car> Ejer16(this List<Car> cars, string color, int? year) =>
            cars.Where(x => !string.IsNullOrEmpty(x.Color) &&
                       x.Year != year)
                        .ToList();
    }
}
