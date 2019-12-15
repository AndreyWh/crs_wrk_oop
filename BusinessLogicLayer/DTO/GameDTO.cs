using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTO
{
    public class GameDTO
    {
        public DateTime Date { get; set; }
        public List<TeamDTO> Teams { get; set; }
        public GameStatus Result { get; set; }
        public StadiumDTO Stadium { get; set; }

        public GameDTO(DateTime date, List<TeamDTO> teams, GameStatus result, StadiumDTO stadium)
        {
            Date = date;
            Teams = teams;
            Result = result;
            Stadium = stadium;
        }

        public GameDTO(GameDTO game)
        {
            Date = game.Date;
            Teams = game.Teams;
            Result = game.Result;
            Stadium = game.Stadium;
        }
    }
}
