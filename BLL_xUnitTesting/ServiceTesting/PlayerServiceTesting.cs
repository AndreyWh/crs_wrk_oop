using System;
using System.Linq;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using Entities.Enums;
using Xunit;

namespace BLL_xUnitTesting.ServiceTesting
{
    public class PlayerServiceTesting
    {
        private PlayerService _playerService;
        private DateTime _date = DateTime.Now;

        [Fact]
        public void GetAllEntities_Test()
        {
            _playerService = new PlayerService();
            var result = _playerService.GetAllEntities();
            Assert.NotNull(result);
        }

        [Fact]
        public void Add_Test()
        {
            _playerService = new PlayerService();
            var testPlayer = new PlayerDTO("Test", "Tester", _date, PlayerHealthStatus.Injured, PlayerStatus.Benched,
                6000);

            _playerService.Add(testPlayer);
        }

        [Fact]

        public void Remove()
        {
            _playerService = new PlayerService();
            var player = _playerService.GetAllEntities().Last();

            _playerService.Remove(player);
        }
        

    }
}
