using EasyConsole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;

namespace PresentationLayer.Pages
{
    class TeamPage : MenuPage
    {
        private readonly TeamService _teamService;
        private readonly PlayerService _playerService;
        public TeamPage(FootballProgram program) : base("Team page", program)
        {
            _playerService = new PlayerService();
            _teamService = new TeamService();

            Menu.Add(new Option("Add team", AddTeam));
            Menu.Add(new Option("Delete team", DeleteTeam));
            Menu.Add(new Option("Add player to team", AddPlayerToTeam));
        }

        private void AddTeam()
        {
            var name = Input.ReadString("Enter a team name:");
            var newTeam = new TeamDTO(name, new List<PlayerDTO>());
            _teamService.Add(newTeam);

            Back();
        }

        private void DeleteTeam()
        {
            var team = SelectTeam();
            _teamService.Remove(team);

            Back();
        }

        private void AddPlayerToTeam()
        {
            var team = SelectTeam();
            var oldTeam = new TeamDTO(team);
            var player = SelectPlayer();
            team.Players.Add(player);
            _teamService.Update(team, oldTeam);

            Back();
        }


        private TeamDTO SelectTeam()
        {
            var teams = _teamService.GetAllEntities();
            var result = new List<TeamDTO>();
            var index = 0;
            foreach (var team in teams)
            {
                Output.WriteLine(index + "." + team.Name);
                index++;
            }

            var selectedIndex = Input.ReadInt("Enter a team", min: 0, max: index - 1);
            return teams[selectedIndex];
        }

        private PlayerDTO SelectPlayer()
        {
            var players = _playerService.GetAllEntities();
            var index = 0;
            foreach (var player in players)
            {
                Output.WriteLine(ConsoleColor.DarkBlue, index + ". " + player.Name + " " + player.Surname);
                index++;
            }

            var selectedPlayerIndex = Input.ReadInt("Choose a player:", min: 0, max: index);
            var selectedPlayer = players[selectedPlayerIndex];

            return selectedPlayer;
        }

        private void Back()
        {
            Input.ReadString("Press [ENTER] to navigate back");
            Program.NavigateTo<TeamPage>();
        }
    }
}
