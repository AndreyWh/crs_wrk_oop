using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTO
{
    public class TeamDTO
    {
        public string Name { get; set; }
        public List<PlayerDTO> Players { get; set; }

        public TeamDTO(string name, List<PlayerDTO> players)
        {
            Name = name;
            Players = players;
        }

        public TeamDTO(TeamDTO team)
        {
            Name = team.Name;
            Players = team.Players;
        }
    }
}
