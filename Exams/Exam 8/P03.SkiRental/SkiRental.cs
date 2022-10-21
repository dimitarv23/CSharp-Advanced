using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            this.Skis = new List<Ski>();
        }

        public List<Ski> Skis { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Skis.Count;

        public void Add(Ski ski)
        {
            if (this.Capacity > this.Count)
            {
                this.Skis.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (this.Skis.Any(s => s.Manufacturer == manufacturer && s.Model == model))
            {
                var skiToRemove = this.Skis.First(s => s.Manufacturer == manufacturer && s.Model == model);
                this.Skis.Remove(skiToRemove);
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            if (this.Count == 0)
            {
                return null;
            }

            return this.Skis.OrderByDescending(s => s.Year).First();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski searchedSki = null;

            if (this.Skis.Any(s => s.Manufacturer == manufacturer && s.Model == model))
            {
                searchedSki = this.Skis.First(s => s.Manufacturer == manufacturer && s.Model == model);
            }

            return searchedSki;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (var ski in this.Skis)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
