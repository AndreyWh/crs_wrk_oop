using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using Xunit;

namespace BLL_xUnitTesting.ServiceTesting
{
    public class StadiumServiceTesting
    {
        private StadiumService _stadiumService;

        [Fact]
        public void GetAllEntities_Test()
        {
            _stadiumService = new StadiumService();
            var result = _stadiumService.GetAllEntities();

            Assert.NotNull(result);
        }

    }
}
