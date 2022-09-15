using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private int speed;
        private int horsePower;

        public Engine(int speed, int hp)
        {
            this.Speed = speed;
            this.HorsePower = hp;
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
    }
}
