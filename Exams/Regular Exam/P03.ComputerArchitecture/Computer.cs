using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;

            this.Multiprocessor = new List<CPU>();
        }

        public List<CPU> Multiprocessor { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (this.Count < this.Capacity)
            {
                this.Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            if (this.Multiprocessor.Any(x => x.Brand == brand))
            {
                var processorToRemove = this.Multiprocessor.FirstOrDefault(x => x.Brand == brand);
                this.Multiprocessor.Remove(processorToRemove);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            return this.Multiprocessor.OrderByDescending(x => x.Frequency).First();
        }

        public CPU GetCPU(string brand)
        {
            CPU searchedCPU = null;

            if (this.Multiprocessor.Any(x => x.Brand == brand))
            {
                searchedCPU = this.Multiprocessor.FirstOrDefault(x => x.Brand == brand);
            }

            return searchedCPU;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {this.Model}:");

            foreach (var cpu in this.Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
