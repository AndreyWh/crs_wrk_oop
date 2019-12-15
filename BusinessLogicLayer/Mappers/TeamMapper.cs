using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using Entities;

namespace BusinessLogicLayer.Mappers
{
    class TeamMapper : IMapper<TeamDTO, Team>
    {
        private readonly PlayerMapper _playerMapper;
        public TeamMapper()
        {
            _playerMapper = new PlayerMapper();
        }

        public TeamMapper(PlayerMapper mapper)
        {
            _playerMapper = mapper;
        }
        public TeamDTO Map(Team dbClass)
        {
            var players = new List<PlayerDTO>(); 
            if(dbClass.Players != null) players = _playerMapper.MapAll(dbClass.Players);
            var result = new TeamDTO(dbClass.Name, players);

            return result;
        }

        public Team Map(TeamDTO dtoClass)
        {
            var players = _playerMapper.MapAll(dtoClass.Players);
            var result = new Team(dtoClass.Name, players);

            return result;
        }

        public List<TeamDTO> MapAll(List<Team> teams)
        {
            var result = new List<TeamDTO>();
            foreach(var team in teams)
            {
                result.Add(Map(team));
            }

            return result;
        }

        public List<Team> MapAll(List<TeamDTO> teams)
        {
            var result = new List<Team>();
            foreach (var team in teams)
            {
                result.Add(Map(team));
            }

            return result;
        }

    }
}
