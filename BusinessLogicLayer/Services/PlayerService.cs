using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using DB;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services
{
    public class PlayerService : IService<PlayerDTO>
    {
        private ApplicationContext _context;
        private readonly PlayerMapper _mapper;

        public PlayerService()
        {
            _mapper = new PlayerMapper();
        }
        public void Add(PlayerDTO player)
        {
            var playerDL = _mapper.Map(player);
            using (_context = new ApplicationContext())
            {
                var team = _context.Teams.First(p => p.Name == "Not in team");
                playerDL.Team = team;
                Load(_context);
                _context.Players.Add(playerDL);
                _context.SaveChanges();

                _context.Dispose();
            }
        }

        public List<PlayerDTO> GetAllEntities()
        {
            var result = new List<PlayerDTO>();
            using (_context = new ApplicationContext())
            {
                Load(_context);
                var players = _context.Players.ToList();
                foreach(var player in players)
                {
                    var mappedPlayer = _mapper.Map(player);
                    result.Add(mappedPlayer);
                }

                _context.Dispose();
            }

            return result;
        }

        public void Remove(PlayerDTO player)
        {
            var playerToDelete = FindPlayer(player);
            using (_context = new ApplicationContext())
            {
                if (playerToDelete == null) throw new ArgumentNullException("Player can't be null!");
                Load(_context);
                var teamp = _context.Players.First(p => p.Id == playerToDelete.Id);
                _context.Players.Remove(teamp);
                _context.SaveChanges();

                _context.Dispose();
            }
        }

        public void Update(PlayerDTO newPlayer, PlayerDTO oldPlayer)
        {
            var playerToChange = FindPlayer(oldPlayer);
            using (_context = new ApplicationContext())
            {
                var temp = _context.Players.First(p => playerToChange.Id == p.Id);
                temp.Name = newPlayer.Name;
                temp.Surname = newPlayer.Surname;
                temp.Birthday = newPlayer.BirthDay;
                temp.HealthStatus = newPlayer.HealthStatus;
                temp.Status = newPlayer.Status;
                temp.Salary = newPlayer.Salary;
                _context.SaveChanges();

                _context.Dispose();
            }
        }

        private Player FindPlayer(PlayerDTO player)
        {
            Player result = null;
            using (_context = new ApplicationContext())
            {
                Load(_context);
                var players = _context.Players.ToList();
                foreach (var p in players)
                {
                    if(p.Name == player.Name 
                        &&p.Surname == player.Surname
                        &&p.Birthday == player.BirthDay)
                    {
                        result = p;
                    }
                }

                _context.Dispose();
            }

            return result;
        }

        private void Load(ApplicationContext context)
        {
            context.Games.Load();
            context.Players.Load();
            context.Stadiums.Load();
            context.Teams.Load();
        }
    }
}
