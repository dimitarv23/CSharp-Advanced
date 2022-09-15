using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int? weight;
        private string color;

        public Car(string model, Engine engine, int? weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public int? Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Model}:");
            result.AppendLine($"  {this.Engine.Model}:");
            result.AppendLine($"    Power: {this.Engine.HorsePower}");
            result.AppendLine($"    Displacement: {(this.Engine.Displacement == null ? "n/a" : this.Engine.Displacement.ToString())}");
            result.AppendLine($"    Efficiency: {(this.Engine.Efficiency == null ? "n/a" : this.Engine.Efficiency)}");
            result.AppendLine($"  Weight: {(this.Weight == null ? "n/a" : this.Weight.ToString())}");
            result.Append($"  Color: {(this.Color == null ? "n/a" : this.Color)}");

            return result.ToString();
        }
    }
}
