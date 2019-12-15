using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Game
    {
        public int Id { get; set; }

        [ForeignKey("HomeTeamId")]
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        [ForeignKey("AwayTeamId")]
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; }
        public DateTime Date { get; set; }

        public GameStatus Result { get; set; }

        public Game(DateTime date , GameStatus result )
        {
            Date = date;
            Result = result;
        }
    }
}
