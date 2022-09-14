using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int hp, int cubics)
        {
            this.horsePower = hp;
            this.CubicCapacity = cubics;
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }
    }
}
