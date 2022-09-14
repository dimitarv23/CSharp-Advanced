using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "BMW";
            car.Model = "E60 530D";
            car.Year = 2009;
            car.FuelQuantity = 50;
            car.FuelConsumption = 8;

            car.Drive(200);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
