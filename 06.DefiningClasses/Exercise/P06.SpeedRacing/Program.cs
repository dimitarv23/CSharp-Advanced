using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string carModel = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);

                cars.Add(new Car(carModel, fuelAmount, fuelConsumption));
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split();
                string carModel = cmdArgs[1];
                double amountOfKm = double.Parse(cmdArgs[2]);

                var carDriven = cars.Find(c => c.Model == carModel);
                carDriven.CoverDistance(amountOfKm);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
