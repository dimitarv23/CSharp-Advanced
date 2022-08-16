using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace P07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmdArgs = command.Split(", ");
                string action = cmdArgs[0];
                string licensePlate = cmdArgs[1];

                if (action == "IN")
                {
                    if (!cars.Contains(licensePlate))
                    {
                        cars.Add(licensePlate);
                    }
                }
                else if (action == "OUT")
                {
                    if (cars.Contains(licensePlate))
                    {
                        cars.Remove(licensePlate);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(cars.Count > 0 ? string.Join(Environment.NewLine, cars) : "Parking Lot is Empty");
        }
    }
}
