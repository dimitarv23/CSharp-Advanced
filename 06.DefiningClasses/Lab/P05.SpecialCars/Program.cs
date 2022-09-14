using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            var engines = new List<Engine>();
            var tires = new List<Tire[]>();

            string tiresCommand = Console.ReadLine();
            while (tiresCommand != "No more tires")
            {
                string[] tiresInfo = tiresCommand.Split();

                tires.Add(new Tire[]
                {
                    new Tire(int.Parse(tiresInfo[0]), double.Parse(tiresInfo[1])),
                    new Tire(int.Parse(tiresInfo[2]), double.Parse(tiresInfo[3])),
                    new Tire(int.Parse(tiresInfo[4]), double.Parse(tiresInfo[5])),
                    new Tire(int.Parse(tiresInfo[6]), double.Parse(tiresInfo[7]))
                });

                tiresCommand = Console.ReadLine();
            }

            string enginesCommand = Console.ReadLine();
            while (enginesCommand != "Engines done")
            {
                string[] engineInfo = enginesCommand.Split();
                int hp = int.Parse(engineInfo[0]);
                double cubics = double.Parse(engineInfo[1]);

                engines.Add(new Engine(hp, cubics));

                enginesCommand = Console.ReadLine();
            }

            string command = Console.ReadLine();
            while (command != "Show special")
            {
                string[] carInfo = command.Split();

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);

                var carEngine = engines[int.Parse(carInfo[5])];
                var carTires = tires[int.Parse(carInfo[6])];

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, carEngine, carTires));

                command = Console.ReadLine();
            }

            Func<Car, bool> conditions = c => c.Year >= 2017
            && c.Engine.HorsePower > 330
            && c.TotalTirePressure() >= 9
            && c.TotalTirePressure() <= 10;

            foreach (var car in cars.Where(conditions))
            {
                car.Drive(20);

                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
