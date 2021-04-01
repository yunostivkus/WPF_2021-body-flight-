using System.Collections.Generic;
using System;

namespace Fly_point
{
    class Program
    {

        static void Main()
        {
            const double G = 9.81;

            Console.Write("Введите скорость тела: ");
            double speed = Double.Parse(Console.ReadLine());
            Console.Write("Введите угол: ");
            double corner = Double.Parse(Console.ReadLine());

            Dictionary<double, double> coordinates_point = new Dictionary<double, double>();

            double time = (2 * speed * Math.Sin(corner * Math.PI / 180) / G);

            for (double i = 0; i <= time; i += 0.1)                                                     // записываем округляя до 2 знаков послезапятой
                coordinates_point.Add(Math.Round((speed * i * Math.Cos(corner * Math.PI / 180)), 2),
                Math.Round((speed * i * Math.Sin(corner * Math.PI / 180) - G * i * i / 2), 2));

            foreach (var i in coordinates_point)                                        // с помощью цикла foreach выводим координаты точки во время полета
                Console.WriteLine("Координаты точки в полёте " + i);

            Console.WriteLine("Время полёта точки: " + Math.Round(time, 2));
            Console.WriteLine("Общая протяженность пути: " + Math.Round((speed * speed *
            Math.Sin(2 * corner * Math.PI / 180)) / G), 2);
        }
    }
}