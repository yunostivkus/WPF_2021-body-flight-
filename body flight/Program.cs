using System;
using System.IO;

namespace body_flight
{
    class Flight
    {
        private double G = 9.81;
        double speed, corner, body_mass;

        public Flight(double spe, double corn, double mass)
        {
            speed = spe;
            corner = (Math.PI * corn) / 180;
            body_mass = mass;
        }

        public double y_coefficient_for_calculation(double time)
        {
            return 4 * Math.Cos(1.5 * time);
        }
        public double x_coefficient_for_calculation(double time)
        {
            return 3.4 * Math.Cos(1.9 * time);
        }

        public void Сalculation()
        {
            double speed_x = speed * Math.Cos(corner);
            double speed_y = speed * Math.Sin(corner);
            double x_coordinate = 0, y_coordinate = 0, t = 0.01;

            Console.WriteLine(x_coordinate + "  --  " + y_coordinate);

            do
            {
                x_coordinate = x_coordinate + (0.01 * speed_x);
                y_coordinate = y_coordinate + (0.01 * speed_y);

                if (y_coordinate < 0)
                    y_coordinate = 0;

                speed_x = velocity_x(t, speed_x, body_mass, 0.01);
                speed_y = velocity_y(t, speed_x, body_mass, 0.01);

                Console.WriteLine(x_coordinate + "  --  " + y_coordinate);

                t += 0.01;
            }
            while (y_coordinate > 0);
        }

        
        public double velocity_x(double time, double speed, double mass, double delta)
        {
            return speed - (delta * x_coefficient_for_calculation(time) * speed / mass);
        }
        public double velocity_y(double time, double speed, double mass, double delta)
        {
            return speed - ((G + (delta * y_coefficient_for_calculation(time) * speed)) / mass);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите скорость тела: ");
                double speed = Double.Parse(Console.ReadLine());
                Console.Write("Введите угол: ");
                double corner = Double.Parse(Console.ReadLine());
                Console.Write("Введите массу тела: ");
                double mass = Double.Parse(Console.ReadLine());


                if (speed <= 0 || corner >= 90 || mass <= 0)
                {
                    Console.WriteLine("Неверно указаны величины");
                    return;
                }

                Flight Body = new Flight(speed, corner, mass);
             
                Body.Сalculation();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Неверные данные");
            }
        }
    }
}