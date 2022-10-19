using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        private string material;
        private int capacity;

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;

            this.Fish = new List<Fish>();
        }

        public List<Fish> Fish
        {
            get { return fish; }
            private set { fish = value; }
        }
        public string Material
        {
            get { return material; }
            set { material = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int Count => this.Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (this.Count == this.Capacity)
            {
                return $"Fishing net is full.";
            }

            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (this.Fish.Any(f => f.Weight == weight))
            {
                var fishToRemove = this.Fish.First(f => f.Weight == weight);
                this.Fish.Remove(fishToRemove);

                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            if (this.Fish.Any(f => f.FishType == fishType))
            {
                return this.Fish.First(f => f.FishType == fishType);
            }

            return null;
        }

        public Fish GetBiggestFish()
        {
            return this.Fish.OrderByDescending(f => f.Length).First();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}:");

            foreach (var fish in this.Fish
                .OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
