using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTO
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public PlayerHealthStatus HealthStatus { get; set; }

        public PlayerStatus Status { get; set; }

        public int Salary { get; set; }

        public PlayerDTO(string name, string surname, DateTime birthday, PlayerHealthStatus healthStatus, PlayerStatus status, int salary)
        {
            Name = name;
            Surname = surname;
            BirthDay = birthday;
            HealthStatus = healthStatus;
            Status = status;
            Salary = salary;
        }

        public PlayerDTO(PlayerDTO playerDto)
        {
            Name = playerDto.Name;
            Surname = playerDto.Surname;
            BirthDay = playerDto.BirthDay;
            HealthStatus = playerDto.HealthStatus;
            Status = playerDto.Status;
            Salary = playerDto.Salary;
        }
    }
}
