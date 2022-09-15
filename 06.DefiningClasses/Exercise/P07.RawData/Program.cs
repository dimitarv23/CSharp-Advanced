using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int horsePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                //Info about all the tires
                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);

                Engine engine = new Engine(engineSpeed, horsePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                List<Tire> tires = new List<Tire>()
                {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure)
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string neededCargoType = Console.ReadLine();

            Func<Car, bool> condition = c => c.Cargo.Type == neededCargoType;

            if (neededCargoType == "fragile")
            {
                condition += c => c.Tires[0].Pressure < 1;
            }
            else if (neededCargoType == "flammable")
            {
                condition += c => c.Engine.HorsePower > 250;
            }

            foreach (var car in cars.Where(condition))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
