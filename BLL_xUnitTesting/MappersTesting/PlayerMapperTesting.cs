using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Mappers;
using Entities;
using Entities.Enums;
using Xunit;

namespace BLL_xUnitTesting.MappersTesting
{
    public class PlayerMapperTesting
    {
        private PlayerMapper _playerMapper = new PlayerMapper();
        private DateTime date = DateTime.Today;

        [Fact]
        public void MapToDTO_Test()
        {
            var testPlayer = new Player("Andrey", "Tester", date,PlayerStatus.Benched, PlayerHealthStatus.Injured, 5000);
            var shouldBePlayer = new PlayerDTO("Andrey", "Tester", date, PlayerHealthStatus.Injured, PlayerStatus.Benched, 5000);
            var result = _playerMapper.Map(testPlayer);
            Assert.True(Equal(result, shouldBePlayer));
        }

        [Fact]
        public void MapToDl_Test()
        {
            var shouldBePlayer = new Player("Andrey", "Tester", date, PlayerStatus.Benched, PlayerHealthStatus.Injured, 5000);
            var testPlayer = new PlayerDTO("Andrey", "Tester", date, PlayerHealthStatus.Injured, PlayerStatus.Benched, 5000);
            var result = _playerMapper.Map(testPlayer);
            Assert.True(Equal(result,shouldBePlayer));
        }

        [Fact]
        public void MapAllToDTO_Test()
        {
            var testPlayer1 = new Player("Andrey1", "Tester1", date, PlayerStatus.Benched, PlayerHealthStatus.Injured, 5000);
            var testPlayer2 = new Player("Andrey2", "Tester2", date, PlayerStatus.Benched, PlayerHealthStatus.Injured, 5000);
            var testList = new List<Player>()
            {
                testPlayer1,
                testPlayer2,
            };
            var shouldBePlayer1 = new PlayerDTO("Andrey1", "Tester1", date, PlayerHealthStatus.Injured, PlayerStatus.Benched, 5000);
            var shouldBePlayer2 = new PlayerDTO("Andrey2", "Tester2", date, PlayerHealthStatus.Injured, PlayerStatus.Benched, 5000);
            var shouldBeList = new List<PlayerDTO>()
            {
                shouldBePlayer1,
                shouldBePlayer2,
            };

            var result = _playerMapper.MapAll(testList);
            Assert.True(Equal(result, shouldBeList));
        }

        [Fact]
        public void MapAllToDl_Test()
        {
            var shouldBePlayer1 = new Player("Andrey1", "Tester1", date, PlayerStatus.Benched, PlayerHealthStatus.Injured, 5000);
            var shouldBePlayer2 = new Player("Andrey2", "Tester2", date, PlayerStatus.Benched, PlayerHealthStatus.Injured, 5000);
            var shouldBeList = new List<Player>()
            {
                shouldBePlayer1,
                shouldBePlayer2,
            };
            var testPlayer1 = new PlayerDTO("Andrey1", "Tester1", date, PlayerHealthStatus.Injured, PlayerStatus.Benched, 5000);
            var testPlayer2 = new PlayerDTO("Andrey2", "Tester2", date, PlayerHealthStatus.Injured, PlayerStatus.Benched, 5000);
            var testList = new List<PlayerDTO>()
            {
                testPlayer1,
                testPlayer2,
            };

            var result = _playerMapper.MapAll(testList);
            Assert.True(Equal(result, shouldBeList));
        }

        private bool Equal(PlayerDTO player1, PlayerDTO player2)
        {
            return player1.Name == player2.Name && player2.Surname == player1.Surname &&
                   player1.BirthDay == player2.BirthDay && player1.HealthStatus == player2.HealthStatus &&
                   player1.Status == player2.Status && player1.Salary == player2.Salary;
        }
        private bool Equal(Player player1, Player player2)
        {
            return player1.Name == player2.Name && player2.Surname == player1.Surname &&
                   player1.Birthday == player2.Birthday && player1.HealthStatus == player2.HealthStatus &&
                   player1.Status == player2.Status && player1.Salary == player2.Salary;
        }

        private bool Equal(List<PlayerDTO> playerList1, List<PlayerDTO> playerList2)
        {
            var result = true;
            if (playerList1.Count != playerList2.Count) return false;
            for (var i = 0; i < playerList1.Count; i++)
            {
                if (!Equal(playerList1[i], playerList2[i])) return false;
            }

            return result;
        }

        private bool Equal(List<Player> playerList1, List<Player> playerList2)
        {
            var result = true;
            if (playerList1.Count != playerList2.Count) return false;
            for (var i = 0; i < playerList1.Count; i++)
            {
                if (!Equal(playerList1[i], playerList2[i])) return false;
            }

            return result;
        }
    }
}
