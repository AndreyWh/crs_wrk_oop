using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Services;
using Xunit;

namespace BLL_xUnitTesting.ServiceTesting
{
    public class TeamServiceTesting
    {
        private TeamService _teamService;

        [Fact]
        public void GetAllEntities_Test()
        {
            _teamService = new TeamService();

            var result = _teamService.GetAllEntities();

            Assert.NotNull(result);
        }
    }
}
