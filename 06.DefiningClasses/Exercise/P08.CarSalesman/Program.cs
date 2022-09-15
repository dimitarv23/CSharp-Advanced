using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int horsePower = int.Parse(engineInfo[1]);

                Engine engine;

                if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];
                    engine = new Engine(model, horsePower, displacement, efficiency);
                }
                else if (engineInfo.Length == 3)
                {
                    if (int.TryParse(engineInfo[2], out int displacement))
                    {
                        engine = new Engine(model, horsePower, displacement, null);
                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        engine = new Engine(model, horsePower, null, efficiency);
                    }
                }
                else
                {
                    engine = new Engine(model, horsePower, null, null);
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = carInfo[0];
                string engineModel = carInfo[1];

                Car car;
                Engine engine = engines.Single(e => e.Model == engineModel);

                if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];
                    car = new Car(carModel, engine, weight, color);
                }
                else if (carInfo.Length == 3)
                {
                    if (int.TryParse(carInfo[2], out int weight))
                    {
                        car = new Car(carModel, engine, weight, null);
                    }
                    else
                    {
                        string color = carInfo[2];
                        car = new Car(carModel, engine, null, color);
                    }
                }
                else
                {
                    car = new Car(carModel, engine, null, null);
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
