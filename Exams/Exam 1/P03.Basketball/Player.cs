using System;
using System.Collections.Generic;
using System.Text;

namespace Basketball
{
    public class Player
    {
        private string name;
        private string position;
        private double rating;
        private int games;
        private bool retired = false;

        public Player(string name, string position, double rating, int games)
        {
            this.Name = name;
            this.Position = position;
            this.Rating = rating;
            this.Games = games;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        public int Games
        {
            get { return games; }
            set { games = value; }
        }
        public bool Retired
        {
            get { return retired; }
            set { retired = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"-Player: {this.Name}");
            sb.AppendLine($"--Position: {this.Position}");
            sb.AppendLine($"--Rating: {this.Rating}");
            sb.Append($"--Games played: {this.Games}");

            return sb.ToString();
        }
    }
}
