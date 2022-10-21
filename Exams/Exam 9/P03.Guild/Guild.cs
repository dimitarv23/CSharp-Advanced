using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Roster = new List<Player>();
        }

        public List<Player> Roster
        {
            get { return roster; }
            private set { roster = value; }
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.Count < this.Capacity)
            {
                this.Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (this.Roster.Any(p => p.Name == name))
            {
                this.Roster.Remove(this.Roster.First(p => p.Name == name));
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            if (this.Roster.Any(p => p.Name == name))
            {
                var player = this.Roster.First(p => p.Name == name);
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (this.Roster.Any(p => p.Name == name))
            {
                var player = this.Roster.First(p => p.Name == name);
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var removedPlayers = this.Roster.Where(p => p.Class == @class).ToArray();
            this.Roster.RemoveAll(p => p.Class == @class);

            return removedPlayers;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.Roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
