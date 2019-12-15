using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using Entities;
using Entities.Enums;
using Xunit;

namespace BLL_xUnitTesting.ServiceTesting
{
    public class GameServiceTesting
    {
        private GameService _gameService;


        [Fact]
        public void GetAllEntities_Test()
        {
            _gameService = new GameService();
            var result = _gameService.GetAllEntities();
            Assert.NotNull(result);
        }

    }
}
