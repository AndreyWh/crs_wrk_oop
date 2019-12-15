using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Mappers
{
    class GameMapper : IMapper<GameDTO, Game>
    {
        private readonly TeamMapper _teamMapper;
        private readonly StadiumMapper _stadiumMapper;
        public GameMapper()
        {
            _teamMapper = new TeamMapper();
            _stadiumMapper = new StadiumMapper();
        }
        public GameDTO Map(Game dbClass)
        {
            var dbTeams = new List<Team>();
            dbTeams.Add(dbClass.HomeTeam);
            dbTeams.Add(dbClass.AwayTeam);
            var teams = _teamMapper.MapAll(dbTeams);
            var stadium = _stadiumMapper.Map(dbClass.Stadium);
            var result = new GameDTO(dbClass.Date, teams, dbClass.Result, stadium);

            return result;
        }

        public Game Map(GameDTO dtoClass)
        {
            var result = new Game(dtoClass.Date, dtoClass.Result);

            return result;
        }
    }
}
