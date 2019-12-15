using BusinessLogicLayer.EnumConverter;
using BusinessLogicLayer.Services;
using EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.Pages
{
    class InformationPage : MenuPage
    {
        private GameService _gameService;
        private PlayerService _playerService;
        private TeamService _teamService;
        private StadiumService _stadiumService;
        public InformationPage(FootballProgram program) : base("Information page", program)
        {
            _gameService = new GameService();
            _playerService = new PlayerService();
            _teamService = new TeamService();
            _stadiumService = new StadiumService();

            Menu.Add(new Option("View all players", ViewPlayers));
            Menu.Add(new Option("View all games", ViewGames));
            Menu.Add(new Option("View all stadiums", ViewStadiums));
            Menu.Add(new Option("View all teams", ViewTeams));
            Menu.Add(new Option("View all games by date", ViewGamesByDate));
            Menu.Add(new Option("View all games by result", ViewGamesByResult));
        }

        private void ViewPlayers()
        {
            var players = _playerService.GetAllEntities();
            foreach(var player in players)
            {
                var status = EnumConverter.ConvertPlayerStatus(player.Status);
                var healthStatus = EnumConverter.ConvertPlayerHealthStatus(player.HealthStatus);
                Output.WriteLine(ConsoleColor.Yellow, player.Name + " " + player.Surname + " Salary: " + player.Salary + " Status: " + status + " Health status: " + healthStatus);
            }

            Back();
        }

        private void ViewGames()
        {
            var games = _gameService.GetAllEntities();
            foreach(var game in games)
            {
                var status = EnumConverter.ConvertGameStatus(game.Result);
                var firstTeam = game.Teams[0].Name;
                var secondTeam = game.Teams[1].Name;
                Output.WriteLine(ConsoleColor.Yellow, firstTeam + " VERSUS " + secondTeam + " RESULT: " + status);
            }

            Back();
        }

        private void ViewTeams()
        {
            var teams = _teamService.GetAllEntities();
            foreach(var team in teams)
            {
                Output.WriteLine(ConsoleColor.Yellow, team.Name);
            }

            Back();
        }

        private void ViewStadiums()
        {
            var stadiums = _stadiumService.GetAllEntities();
            foreach(var stadium in stadiums)
            {
                Output.WriteLine(ConsoleColor.Yellow, stadium.Name + " Capacity: " + stadium.Capacity + " Price for place: " + stadium.PriceForPlace);
            }

            Back();
        }

        private void ViewGamesByDate()
        {
            var games = _gameService.GetAllEntities();

            foreach (var game in games.OrderBy(p => p.Date))
            {
                var status = EnumConverter.ConvertGameStatus(game.Result);
                var firstTeam = game.Teams[0].Name;
                var secondTeam = game.Teams[1].Name;
                Output.WriteLine(ConsoleColor.Yellow, firstTeam + " VERSUS " + secondTeam + " RESULT: " + status);
            }

            Back();
        }

        private void ViewGamesByResult()
        {
            var games = _gameService.GetAllEntities();

            foreach (var game in games.OrderBy(p => p.Result))
            {
                var status = EnumConverter.ConvertGameStatus(game.Result);
                var firstTeam = game.Teams[0].Name;
                var secondTeam = game.Teams[1].Name;
                Output.WriteLine(ConsoleColor.Yellow, firstTeam + " VERSUS " + secondTeam + " RESULT: " + status);
            }

            Back();
        }

        private void Back()
        {
            Input.ReadString("Press [ENTER] to navigate back");
            Program.NavigateTo<InformationPage>();
        }
    }
}
