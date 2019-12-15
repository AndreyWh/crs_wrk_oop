using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.EnumConverter;
using Entities;
using Entities.Enums;
using Xunit;

namespace BLL_xUnitTesting.EnumConvertorTesting
{
    public class EnumConvertorTesting
    {
        [Fact]
        public void ConvertGameStatusInString_Test()
        {
            var testStatus = GameStatus.NotPlayed;
            var testStatusInString = "Not played";

            var result = EnumConverter.ConvertGameStatus(testStatus);
            
            Assert.Equal(result, testStatusInString);
        }

        [Fact]
        public void ConvertGameStatusInEnum_Test()
        {
            var testStatus = GameStatus.NotPlayed;
            var testStatusInt = 3;

            var result = EnumConverter.ConvertGameStatus(testStatusInt);

            Assert.Equal(result, testStatus);
        }

        [Fact]
        public void ConvertPlayerStatusInEnum_Test()
        {
            var testStatus = PlayerStatus.Active;
            var testStatusInString = "Active";

            var result = EnumConverter.ConvertPlayerStatus(testStatus);

            Assert.Equal(result, testStatusInString);
        }

        [Fact]
        public void ConvertPlayerStatusInt_Test()
        {
            var testStatus = PlayerStatus.Active;
            var testStatusInt = 0;

            var result = EnumConverter.ConvertPlayerStatus(testStatusInt);

            Assert.Equal(result, testStatus);
        }

        [Fact]
        public void ConvertPlayerHealthStatusInEnum_Test()
        {
            var testStatus = PlayerHealthStatus.Injured;
            var testStatusInString = "Injured";

            var result = EnumConverter.ConvertPlayerHealthStatus(testStatus);

            Assert.Equal(result, testStatusInString);
        }

        [Fact]

        public void ConvertPlayerHealthStatusInt_Test()
        {
            var testStatus = PlayerHealthStatus.Injured;
            var testStatusInt = 1;

            var result = EnumConverter.ConvertPlayerHealthStatus(testStatusInt);

            Assert.Equal(result, testStatus);
        }
    }
}
