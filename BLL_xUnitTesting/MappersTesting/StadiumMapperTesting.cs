using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Mappers;
using Entities;
using Entities.Enums;
using Xunit;

namespace BLL_xUnitTesting.MappersTesting
{
    public class StadiumMapperTesting
    {
        private StadiumMapper _stadiumMapper = new StadiumMapper();

        [Fact]
        public void MapToDto()
        {
            var testStadium = new Stadium("Test", 5000, 500);
            var shouldBe = new StadiumDTO("Test", 5000, 500);

            var result = _stadiumMapper.Map(testStadium);
            Assert.True(Equal(result, shouldBe));
        }

        [Fact]
        public void MapToDl()
        {
            var shouldBe = new Stadium("Test", 5000, 500);
            var testStadium = new StadiumDTO("Test", 5000, 500);

            var result = _stadiumMapper.Map(testStadium);
            Assert.True(Equal(result, shouldBe));
        }


        private bool Equal(StadiumDTO stadium1, StadiumDTO stadium2)
        {
            return stadium1.Name == stadium2.Name && stadium1.Capacity == stadium2.Capacity &&
                   stadium1.PriceForPlace == stadium2.PriceForPlace;
        }

        private bool Equal(Stadium stadium1, Stadium stadium2)
        {
            return stadium1.Name == stadium2.Name && stadium1.Capacity == stadium2.Capacity &&
                   stadium1.PriceForPlace == stadium2.PriceForPlace;
        }
    }
}
