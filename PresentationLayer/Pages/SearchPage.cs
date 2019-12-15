using EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.EnumConverter;
using BusinessLogicLayer.Services;
using Entities;

namespace PresentationLayer.Pages
{
    class SearchPage : MenuPage
    {
        private readonly GameService _gameService;
        private readonly PlayerService _playerService;
        private readonly StadiumService _stadiumService;
        public SearchPage(FootballProgram program) : base("Search page", program)
        {
            _gameService = new GameService();
            _playerService = new PlayerService();
            _stadiumService = new StadiumService();

            Menu.Add(new Option("Search stadium by name", SearchStadiumByName));
            Menu.Add(new Option("Search player by name or surname", SearchPlayerByNameOrSurname));
            Menu.Add(new Option("Search game by date and name of away team", SearchGameByDateAndAwayTeamName));

        }

        private void SearchStadiumByName()
        {
            var name = Input.ReadString("Enter a name of stadium:");
            var stadium = _stadiumService.GetAllEntities()
                .First(s => s.Name == name);
            if(stadium == null) Output.WriteLine(ConsoleColor.Red, "Not found");
            else Output.WriteLine(ConsoleColor.DarkYellow, stadium.Name + " Capacity: " + stadium.Capacity + " Price for place: " + stadium.PriceForPlace);

            Back();
        }

        private void SearchPlayerByNameOrSurname()
        {
            var nameOrSurname = Input.ReadString("Enter a name or surname of player: ");
            var players = _playerService.GetAllEntities()
                .Where(p => p.Name == nameOrSurname || p.Surname == nameOrSurname);
            if (!players.Any()) Output.WriteLine(ConsoleColor.Red, "Not found");
            else
            {
                foreach (var player in players)
                {
                    var status = EnumConverter.ConvertPlayerStatus(player.Status);
                    var healthStatus = EnumConverter.ConvertPlayerHealthStatus(player.HealthStatus);
                    Output.WriteLine(ConsoleColor.Green, player.Name + " " + player.Surname + " Salary: " + player.Salary + " Status: " + status + " Health status: " + healthStatus);
                }
            }

            Back();
        }

        private void SearchGameByDateAndAwayTeamName()
        {
            var dateInString = Input.ReadString("Please enter a date (05/05/2005):");
            var date = Convert.ToDateTime(dateInString);
            var awayTeamName = Input.ReadString("Please enter a away team name:");
            var game = _gameService.GetAllEntities()
                .First(g => g.Date == date && g.Teams[1].Name == awayTeamName);
            if(game == null) Output.WriteLine(ConsoleColor.Red, "Not found");
            else
            {
                var firstTeam = game.Teams[0];
                var secondTeam = game.Teams[1];
                var status = EnumConverter.ConvertGameStatus(game.Result);
                Output.WriteLine(ConsoleColor.Yellow, firstTeam + " VERSUS " + secondTeam + " RESULT: " + status + " STADIUM: " + game.Stadium.Name);
            }

            Back();
        }

        private void Back()
        {
            Input.ReadString("Press any key to navigate back");
            Program.NavigateTo<SearchPage>();
        }
    }
}
