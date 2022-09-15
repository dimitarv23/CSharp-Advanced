using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.Capacity = capacity;
        }

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }
        public int Count
        {
            get { return cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count >= this.Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string plate)
        {
            if (!cars.Any(c => c.RegistrationNumber == plate))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car carToRemove = cars.First(c => c.RegistrationNumber == plate);
                cars.Remove(carToRemove);
                return $"Successfully removed {plate}";
            }
        }

        public Car GetCar(string registrationPlate)
        {
            if (cars.Any(c => c.RegistrationNumber == registrationPlate))
            {
                return cars.First(c => c.RegistrationNumber == registrationPlate);
            }

            return null;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationPlates)
        {
            foreach (var plate in registrationPlates)
            {
                RemoveCar(plate);
            }
        }
    }
}
