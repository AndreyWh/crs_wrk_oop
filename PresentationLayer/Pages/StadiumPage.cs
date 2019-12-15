using EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.EnumConverter;
using BusinessLogicLayer.Services;

namespace PresentationLayer.Pages
{
    class StadiumPage : MenuPage
    {
        private readonly StadiumService _stadiumService;
        private readonly GameService _gameService;
        public StadiumPage(FootballProgram program) : base("Stadium page", program)
        {
            _stadiumService = new StadiumService();
            _gameService = new GameService();

            Menu.Add(new Option("Add stadium", AddStadium));
            Menu.Add(new Option("Delete stadium", DeleteStadium));
            Menu.Add(new Option("Update stadium", UpdateStadium));
            Menu.Add(new Option("About stadium", AboutStadium));
        }

        private void AddStadium()
        {
            var name = Input.ReadString("Enter a stadium name");
            var capacity = Input.ReadInt("Enter a stadium capacity", min: 100, max: 10000000);
            var priceForPlace = Input.ReadInt("Enter a price for place", min: 10, max: 10000);

            _stadiumService.Add(new StadiumDTO(name, capacity, priceForPlace));
            Back();
        }

        private void DeleteStadium()
        {
            var stadium = SelectStadium();
            _stadiumService.Remove(stadium);

            Back();
        }

        private void UpdateStadium()
        {
            var stadium = SelectStadium();
            var oldStadium = new StadiumDTO(stadium);
            var changeIndex = Input.ReadInt("What you want to change?\n1.Name\n2.Capacity\n3.Price for place", min:1, max:3);
            switch (changeIndex)
            {
                case 1:
                    var name = Input.ReadString("Enter a stadium name");
                    stadium.Name = name;
                    break;
                case 2:
                    var capacity = Input.ReadInt("Enter a stadium capacity", min: 100, max: 10000000);
                    stadium.Capacity = capacity;
                    break;
                case 3:
                    var priceForPlace = Input.ReadInt("Enter a price for place", min: 10, max: 10000);
                    stadium.PriceForPlace = priceForPlace;
                    break;
            }

            _stadiumService.Update(stadium, oldStadium);
            Back();
        }

        private void AboutStadium()
        {
            var stadium = SelectStadium();
            var games = _gameService.GetAllEntities().Where(g => g.Stadium.Name == stadium.Name);
            Output.WriteLine(ConsoleColor.DarkYellow, stadium.Name + " Capacity: " + stadium.Capacity + " Price for place: " + stadium.PriceForPlace);
            foreach (var game in games)
            {
                var firstTeam = game.Teams[0].Name;
                var secondTeam = game.Teams[1].Name;
                var status = EnumConverter.ConvertGameStatus(game.Result);

                Output.WriteLine(ConsoleColor.Cyan, firstTeam + " VERSUS " + secondTeam + " RESULT: " + status + " DATE : " + game.Date.ToShortDateString());
            }

            Back();
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

        private void Back()
        {
            Input.ReadString("Press [ENTER] to navigate back");
            Program.NavigateTo<StadiumPage>();
        }
    }
}
