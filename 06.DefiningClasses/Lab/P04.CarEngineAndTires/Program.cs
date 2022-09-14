using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.5),
                new Tire(2, 2.8),
                new Tire(2, 2.8)
            };

            var engine = new Engine(235, 3000);

            var car = new Car("BMW", "E60 530D", 2009, 70, 8, engine, tires);
        }
    }
}
