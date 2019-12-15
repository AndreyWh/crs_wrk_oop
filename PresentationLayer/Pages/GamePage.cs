using EasyConsole;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.EnumConverter;
using BusinessLogicLayer.Services;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace PresentationLayer.Pages
{
    class GamePage : MenuPage
    {
        private readonly GameService _gameService;
        private readonly TeamService _teamService;
        private readonly StadiumService _stadiumService;
        public GamePage(FootballProgram program) : base("Game page", program)
        {
            _gameService = new GameService();
            _teamService = new TeamService();
            _stadiumService = new StadiumService();

            Menu.Add(new Option("Add game", AddGame));
            Menu.Add(new Option("Delete game", DeleteGame));
            Menu.Add(new Option("Update game", UpdateGame));
            Menu.Add(new Option("About game", AboutGame));


        }

        private void AddGame()
        {
            var teams = SelectTeam();
            var dateInString = Input.ReadString("Please enter a date (05/05/2005):");
            var date = Convert.ToDateTime(dateInString);
            var stadium = SelectStadium();
            var result = Input.ReadInt("Enter a game result: ", min: 0, max: 3);
            var resultEnum = EnumConverter.ConvertGameStatus(result);

            var newGame = new GameDTO(date,teams,resultEnum,stadium);
            _gameService.Add(newGame);
            Back();
        }

        private void DeleteGame()
        {
            var gameToDelete = SelectGame();
            _gameService.Remove(gameToDelete);
            Back();
        }

        private void UpdateGame()
        {
            var gameToUpdate = SelectGame();
            var oldGame = new GameDTO(gameToUpdate);
            var changeIndex = Input.ReadInt("Enter what you want to change?\n1.Date\n2.Teams\n3.Stadium\n4.Result", min: 1, max:4);
            switch (changeIndex)
            {
                case 1:
                    var dateInString = Input.ReadString("Please enter a date (05/05/2005):");
                    var date = Convert.ToDateTime(dateInString);
                    gameToUpdate.Date = date;
                    break;
                case 2:
                    var teams = SelectTeam();
                    gameToUpdate.Teams = teams;
                    break;
                case 3:
                    var stadium = SelectStadium();
                    gameToUpdate.Stadium = stadium;
                    break;
                case 4:
                    var result = Input.ReadInt("Enter a game result: ", min: 0, max: 3);
                    var resultEnum = EnumConverter.ConvertGameStatus(result);
                    gameToUpdate.Result = resultEnum;
                    break;
            }

            _gameService.Update(gameToUpdate,oldGame);
            Back();

        }
        private GameDTO SelectGame()
        {
            var games = _gameService.GetAllEntities();
            var index = 0;
            foreach (var game in games)
            {
                var firstTeam = game.Teams[0].Name;
                var secondTeam = game.Teams[1].Name;
                var status = EnumConverter.ConvertGameStatus(game.Result);
                Output.WriteLine(ConsoleColor.Yellow, firstTeam + " VERSUS " + secondTeam + " RESULT: " + status);
                index++;
            }

            var gameIndex = Input.ReadInt("Enter a game index:", min: 0, max: index - 1);
            return games[gameIndex];
        }
        private List<TeamDTO> SelectTeam()
        {
            var teams = _teamService.GetAllEntities();
            var result = new List<TeamDTO>();
            var index = 0;
            foreach (var team in teams)
            {
                Output.WriteLine(index+"."+ team.Name);
                index++;
            }

            if (teams.Count < 2)
            {
                Output.WriteLine(ConsoleColor.Red, "You don't have enough teams or some team don't have players");
                Back();
            }

            var homeTeam = Input.ReadInt("Enter a home team", min: 0, max: index);
            var awayTeam = Input.ReadInt("Enter a away team", min: 0, max: index);
            if (homeTeam == awayTeam)
            {
                Output.WriteLine(ConsoleColor.Red,"Wrong select!");
                SelectTeam();
            }

            result.Add(teams[homeTeam]);
            result.Add(teams[awayTeam]);

            return result;
        }

        private StadiumDTO SelectStadium()
        {
            var stadiums = _stadiumService.GetAllEntities();
            var index = 0;
            foreach (var stadium in stadiums)
            {
                Output.WriteLine(index + "." + stadium.Name);
                index++;
            }

            var stadiumIndex = Input.ReadInt("Enter a stadium index:", min: 0, max: index - 1);
            return stadiums[stadiumIndex];
        }

        private void AboutGame()
        {
            var game = SelectGame();
            var firstTeam = game.Teams[0].Name;
            var secondTeam = game.Teams[1].Name;
            var status = EnumConverter.ConvertGameStatus(game.Result);
            Output.WriteLine(ConsoleColor.Yellow, firstTeam + " VERSUS " + secondTeam + " RESULT: " + status + " STADIUM: " + game.Stadium.Name);

            Back();
        }

        private void Back()
        {
            Input.ReadString("Press [ENTER] to navigate back");
            Program.NavigateTo<GamePage>();
        }
    }
}
