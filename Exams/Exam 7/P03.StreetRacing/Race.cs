using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;

            this.Participants = new List<Car>();
        }

        public List<Car> Participants { get; private set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (!this.Participants.Any(c => c.LicensePlate == car.LicensePlate)
                && this.Capacity > this.Count
                && this.MaxHorsePower >= car.HorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            if (this.Participants.Any(c => c.LicensePlate == licensePlate))
            {
                var carToRemove = this.Participants.Single(c => c.LicensePlate == licensePlate);
                this.Participants.Remove(carToRemove);

                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            return this.Participants.SingleOrDefault(c => c.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            if (this.Count == 0)
            {
                return null;
            }

            return this.Participants.OrderByDescending(c => c.HorsePower).First();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in this.Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
