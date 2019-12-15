using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using Entities;

namespace BusinessLogicLayer.Mappers
{
    public class PlayerMapper : IMapper<PlayerDTO, Player>
    {
        private TeamMapper _teamMapper;

        public PlayerMapper()
        {
            _teamMapper = new TeamMapper(this);
        }

        public PlayerDTO Map(Player dbClass)
        {
            var newClass = new PlayerDTO(dbClass.Name, dbClass.Surname, dbClass.Birthday, dbClass.HealthStatus, dbClass.Status, dbClass.Salary);
            return newClass;
        }

        public Player Map(PlayerDTO dtoClass)
        {
            var newClass = new Player(dtoClass.Name, dtoClass.Surname, dtoClass.BirthDay, dtoClass.Status,
                dtoClass.HealthStatus, dtoClass.Salary);
            return newClass;
        }

        public List<PlayerDTO> MapAll(List<Player> players)
        {
            var result = new List<PlayerDTO>();
            foreach(var player in players)
            {
                result.Add(Map(player));
            }

            return result;
        }

        public List<Player> MapAll(List<PlayerDTO> players)
        {
            List<Player> result = new List<Player>();
            foreach (var player in players)
            {
                result.Add(Map(player));
            }

            return result;
        }
    }
}
