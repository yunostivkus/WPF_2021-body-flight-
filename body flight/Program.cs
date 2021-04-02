using System;
using System.IO;
using System.Collections.Generic;

namespace HelloApp
{
    class Program
    {
        static void Main()
        {
            FlightToFile call = new FlightToFile();
        }
    }

    class FlightToFile
    {
        public FlightToFile()
        {

            const double G = 9.81;

            Console.Write("Введите скорость тела: ");
            double speed = Double.Parse(Console.ReadLine());
            Console.Write("Введите угол: ");
            double corner = Double.Parse(Console.ReadLine());

            string writePath = @"C:\Data\GitHub\1.csv";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    Dictionary<double, double> coordinates_point = new Dictionary<double, double>();

                    double time = (2 * speed * Math.Sin(corner * Math.PI / 180) / G);


                    for (double i = 0; i <= time; i += 0.1)                                                 // записываем округляя до 2 знаков послезапятой
                        coordinates_point.Add(Math.Round((speed * i * Math.Cos(corner * Math.PI / 180)), 2),
                        Math.Round((speed * i * Math.Sin(corner * Math.PI / 180) - G * i * i / 2), 2));


                    for (double dt = 0; dt < time; dt += 0.1)               // вывод времени 
                    {
                        sw.WriteLine("time: " + Math.Round(dt, 2));
                    }

                    foreach (var i in coordinates_point)                     // с помощью цикла foreach выводим координаты точки во время полета
                    {
                        sw.WriteLine("body coordinates: " + i + " ");
                    }

                    sw.WriteLine("Time in flight: " + Math.Round(time, 2));
                    sw.WriteLine("The length of the path: " + Math.Round((speed * speed *
                    Math.Sin(2 * corner * Math.PI / 180)) / G), 2);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}

