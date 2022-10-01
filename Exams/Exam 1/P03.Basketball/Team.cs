using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        private string name;
        private int openPositions;
        private char group;

        public Team(string name, int openPos, char group)
        {
            this.Name = name;
            this.OpenPositions = openPos;
            this.Group = group;

            this.Players = new List<Player>();
        }

        public List<Player> Players
        {
            get { return players; }
            private set { players = value; }
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public int OpenPositions
        {
            get { return openPositions; }
            private set { openPositions = value; }
        }
        public char Group
        {
            get { return group; }
            set { group = value; }
        }
        public int Count
        {
            get { return players.Count; }
        }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (this.OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            this.Players.Add(player);
            this.OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }
        public bool RemovePlayer(string name)
        {
            if (this.Players.Any(p => p.Name == name))
            {
                var playerToRemove = this.Players.FirstOrDefault(p => p.Name == name);
                this.Players.Remove(playerToRemove);
                this.OpenPositions++;
                return true;
            }

            return false;
        }
        public int RemovePlayerByPosition(string position)
        {
            if (this.Players.Any(p => p.Position == position))
            {
                int countRemoved = this.Players.RemoveAll(p => p.Position == position);
                this.OpenPositions += countRemoved;
                return countRemoved;
            }

            return 0;
        }
        public Player RetirePlayer(string name)
        {
            Player retiredPlayer = null;

            if (this.Players.Any(p => p.Name == name))
            {
                retiredPlayer = this.Players.FirstOrDefault(p => p.Name == name);
                retiredPlayer.Retired = true;
                this.OpenPositions++;
            }

            return retiredPlayer;
        }
        public List<Player> AwardPlayers(int games)
        {
            return this.Players.Where(p => p.Games >= games).ToList();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (var player in this.Players.Where(p => p.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
