using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;

            this.Renovators = new List<Renovator>();
        }

        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count => this.Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrWhiteSpace(renovator.Name) || string.IsNullOrWhiteSpace(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (this.Count >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (this.Renovators.Any(r => r.Name == name))
            {
                this.Renovators.Remove(this.Renovators.FirstOrDefault(r => r.Name == name));
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            if (this.Renovators.Any(r => r.Type == type))
            {
                return this.Renovators.RemoveAll(r => r.Type == type);
            }

            return 0;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = null;

            if (this.Renovators.Any(r => r.Name == name))
            {
                renovator = this.Renovators.FirstOrDefault(r => r.Name == name);
                renovator.Hired = true;
            }

            return renovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return this.Renovators.Where(r => r.Days >= days).ToList();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var renovator in this.Renovators.Where(r => !r.Hired))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
