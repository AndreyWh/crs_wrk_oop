using DB;
using Entities;
using Microsoft.EntityFrameworkCore;
using PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseWork_FootballApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new ApplicationContext())
            //{
            //    Console.WriteLine("Ce pizda");
            //}
            var program = new FootballProgram();
            program.Run();
            //using (var db = new ApplicationContext())
            //{

            //    //var player1 = new Player("Akes", "Sasa", DateTime.Now, Entities.Enums.PlayerStatus.Active, Entities.Enums.PlayerHealthStatus.Healthy, 4500);
            //    //var player2 = new Player("SDSa", "sdsds", DateTime.Now, Entities.Enums.PlayerStatus.Active, Entities.Enums.PlayerHealthStatus.Healthy, 5500);
            //    //var newTeamF = new Team("Real Madrid");
            //    //var seTeamF = new Team("Dynamo");
            //    //var stadium = new Stadium("Donbass Arena", 40000, 30);
            //    //newTeamF.Players = new List<Player>();
            //    //newTeamF.Players.Add(player1);
            //    //player1.Team = newTeamF;
            //    //seTeamF.Players = new List<Player>();
            //    //seTeamF.Players.Add(player2);
            //    //player2.Team = seTeamF;
            //    //var newGame = new Game(DateTime.Today, Entities.Enums.GameStatus.NotPlayed)
            //    //{
            //    //    HomeTeam = newTeamF,
            //    //    AwayTeam = seTeamF,
            //    //    Stadium = stadium,
            //    //};
            //    //newTeamF.HomeGames = new List<Game>();
            //    //newTeamF.HomeGames.Add(newGame);
            //    //seTeamF.AwayGames = new List<Game>();
            //    //seTeamF.AwayGames.Add(newGame);
            //    //db.Players.Add(player1);
            //    //db.Players.Add(player2);
            //    //db.Stadiums.Add(stadium);
            //    //db.Games.Add(newGame);
            //    //db.Teams.Add(newTeamF);
            //    //db.Teams.Add(seTeamF);
            //    //db.SaveChanges();
            //}
        }
    }
}
