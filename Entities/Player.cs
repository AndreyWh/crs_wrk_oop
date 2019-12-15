using Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public PlayerStatus Status { get; set; }
        public PlayerHealthStatus HealthStatus { get; set; }
        public int Salary { get; set; }
        [ForeignKey("TeamId")]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public Player(string name , string surname, DateTime birthday, PlayerStatus status, PlayerHealthStatus healthStatus, int salary)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Status = status;
            HealthStatus = healthStatus;
            Salary = salary;
        }

    }
}
