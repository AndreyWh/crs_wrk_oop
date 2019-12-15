using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace BusinessLogicLayer.EnumConverter
{
    public static class EnumConverter
    {
        public static string ConvertPlayerHealthStatus(PlayerHealthStatus status)
        {
            if (status == PlayerHealthStatus.Healthy) return "Healthy";
            else return "Injured";
        }

        public static string ConvertPlayerStatus(PlayerStatus status)
        {
            if (status == PlayerStatus.Active) return "Active";
            else if (status == PlayerStatus.Benched) return "Benched";
            else return "Not active";
        }

        public static string ConvertGameStatus(GameStatus status)
        {
            if (status == GameStatus.Draw) return "Draw";
            else if (status == GameStatus.FirstTeamWon) return "First team won!";
            else if (status == GameStatus.SecondTeamWon) return "Second team won!";
            else return "Not played";
        }

        public static PlayerHealthStatus ConvertPlayerHealthStatus(int status)
        {
            return status switch
            {
                0 => PlayerHealthStatus.Healthy,
                1 => PlayerHealthStatus.Injured,
                _ => throw new ArgumentNullException("status dont correct"),
            };
        }

        public static PlayerStatus ConvertPlayerStatus(int status)
        {
            return status switch
            {
                0 => PlayerStatus.Active,
                1 => PlayerStatus.Benched,
                2 => PlayerStatus.NotActive,
                _ => throw new ArgumentNullException("status dont correct"),
            };
        }

        public static GameStatus ConvertGameStatus(int status)
        {
            return status switch
            {
                0 => GameStatus.Draw,
                1 => GameStatus.FirstTeamWon,
                2 => GameStatus.SecondTeamWon,
                3 => GameStatus.NotPlayed,
                _ => throw new ArgumentNullException("status can't be null"),
            };
        }
    }
}
