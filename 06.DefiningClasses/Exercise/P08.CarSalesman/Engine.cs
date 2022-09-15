using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private string model;
        private int horsePower;
        private int? displacement;
        private string efficiency;

        public Engine(string model, int horsePower, int? displacement, string efficiency)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }

        }
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public int? Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
    }
}
