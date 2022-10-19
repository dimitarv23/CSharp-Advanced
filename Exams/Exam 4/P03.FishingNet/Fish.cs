using System;
using System.Collections.Generic;
using System.Text;

namespace FishingNet
{
    public class Fish
    {
        private string fishType;
        private double length;
        private double weight;

        public Fish(string fishType, double length, double weight)
        {
            this.FishType = fishType;
            this.Length = length;
            this.Weight = weight;
        }

        public string FishType
        {
            get { return fishType; }
            set { fishType = value; }
        }
        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public override string ToString()
        {
            return $"There is a {this.FishType}, {this.Length} cm. long, and {this.Weight} gr. in weight.";
        }
    }
}
