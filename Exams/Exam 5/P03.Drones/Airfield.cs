using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        private string name;
        private int capacity;
        private double landingStrip;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;

            this.Drones = new List<Drone>();
        }

        public List<Drone> Drones
        {
            get { return drones; }
            private set { drones = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public double LandingStrip
        {
            get { return landingStrip; }
            set { landingStrip = value; }
        }
        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name)
                || string.IsNullOrEmpty(drone.Brand)
                || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (this.Count == this.Capacity)
            {
                return "Airfield is full.";
            }

            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            if (this.Drones.Any(d => d.Name == name))
            {
                var droneToRemove = drones.First(d => d.Name == name);
                drones.Remove(droneToRemove);
                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            return this.Drones.RemoveAll(d => d.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            Drone droneToFly = null;

            if (this.Drones.Any(d => d.Name == name))
            {
                droneToFly = drones.First(d => d.Name == name);
                droneToFly.Available = false;
            }

            return droneToFly;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            foreach (var drone in this.Drones.Where(d => d.Range >= range))
            {
                drone.Available = false;
            }

            return this.Drones.Where(d => d.Range >= range).ToList();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in this.Drones.Where(d => d.Available))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
