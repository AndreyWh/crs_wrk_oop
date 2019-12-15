using EasyConsole;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.EnumConverter;
using BusinessLogicLayer.Services;
using Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace PresentationLayer.Pages
{
    class PlayerPage : MenuPage
    {
        private readonly PlayerService _playerService;
        public PlayerPage(FootballProgram program) : base("Player page", program)
        {
            _playerService = new PlayerService();

            Menu.Add(new Option("Add player", AddPlayer));
            Menu.Add(new Option("Remove player", RemovePlayer));
            Menu.Add(new Option("Change player", UpdatePlayer));
            Menu.Add(new Option("Info", AboutPlayer));
        }

        private void AddPlayer()
        {
            var name = Input.ReadString("Please enter a name:");
            var surname = Input.ReadString("Please enter a surname:");
            var birthDateInString = Input.ReadString("Please enter a birthdate (05/05/2005):");
            var status = Input.ReadInt("Please enter a player status(0 - Active, 1 - Benched, 2 - Not active):", min:0 , max:2);
            var healthStatus = Input.ReadInt("Please enter a player health status(0 - Healthy, 1 - Injured):", min:0, max: 1);
            var salary = Input.ReadInt("Please enter a salary:", min: 0, max: 100000);


            var birthDate = Convert.ToDateTime(birthDateInString);


            var healthStatusInEnum = EnumConverter.ConvertPlayerHealthStatus(healthStatus);
            var playerStatusInEnum = EnumConverter.ConvertPlayerStatus(status);
;            var newPlayer = new PlayerDTO(name, surname, birthDate, healthStatusInEnum, playerStatusInEnum, salary);

            _playerService.Add(newPlayer);
            Back();
        }

        private void RemovePlayer()
        {
            var playerToDelete = PlayerSelection();

            _playerService.Remove(playerToDelete);
            
            Back();

        }

        private void AboutPlayer()
        {
            var player = PlayerSelection();
            var status = EnumConverter.ConvertPlayerStatus(player.Status);
            var healthStatus = EnumConverter.ConvertPlayerHealthStatus(player.HealthStatus);
            Output.WriteLine(ConsoleColor.Green, player.Name + " " + player.Surname + " Salary: " + player.Salary + " Status: " + status + " Health status: " + healthStatus);

            Back();
        }

        private void UpdatePlayer()
        {
            var playerToEdit = PlayerSelection();
            PlayerDTO oldPlayer = new PlayerDTO(playerToEdit);
            var changedPlayer = OptionToChange(playerToEdit);
            _playerService.Update(changedPlayer, oldPlayer);
            Back();



            PlayerDTO OptionToChange(PlayerDTO playerToChange)
            {
                Output.WriteLine("1.Name\n2.Surname\n3.Birthday\n4.Status\n5.Health status\n6.Salary");
                var optionToChange = Input.ReadInt("Choose option to change:", min: 1, max: 6);
                switch (optionToChange)
                {
                    case 1:
                        var name = Input.ReadString("Please enter a name:");
                        playerToChange.Name = name;
                        break;
                    case 2:
                        var surname = Input.ReadString("Please enter a surname:");
                        playerToChange.Surname = surname;
                        break;
                    case 3:
                        var birthDateInString = Input.ReadString("Please enter a birthdate (05/05/2005):");
                        var birthDate = Convert.ToDateTime(birthDateInString);
                        playerToChange.BirthDay = birthDate;
                        break;
                    case 4:
                        var status = Input.ReadInt("Please enter a player status(0 - Active, 1 - Benched, 2 - Not active):", min: 0, max: 2);
                        var playerStatusInEnum = EnumConverter.ConvertPlayerStatus(status);
                        playerToChange.Status = playerStatusInEnum;
                        break;
                    case 5:
                        var healthStatus = Input.ReadInt("Please enter a player health status(0 - Healthy, 1 - Injured):", min: 0, max: 1);
                        var healthStatusInEnum = EnumConverter.ConvertPlayerHealthStatus(healthStatus);
                        playerToChange.HealthStatus = healthStatusInEnum;
                        break;
                    case 6:
                        var salary = Input.ReadInt("Please enter a salary:", min: 0, max: 100000);
                        playerToChange.Salary = salary;
                        break;
                }

                return playerToChange;
            }
        }

        private void Back()
        {
            Input.ReadString("Press any key to navigate back");
            Program.NavigateTo<PlayerPage>();
        }

        private PlayerDTO PlayerSelection()
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
    }
}
