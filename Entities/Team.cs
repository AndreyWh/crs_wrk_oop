using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public List<Game> HomeGames { get; set; }
        public List<Game> AwayGames { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        public Team(string name, List<Player> players) : this(name)
        {
            Players = players;
            
        }
    }
}
