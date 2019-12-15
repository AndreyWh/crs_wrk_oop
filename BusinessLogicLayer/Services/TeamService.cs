using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using DB;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services
{
    public class TeamService : IService<TeamDTO>
    {
        private ApplicationContext _context;
        private TeamMapper _teamMapper;
        private PlayerMapper _playerMapper;

        public TeamService()
        {
            _teamMapper = new TeamMapper();
            _playerMapper = new PlayerMapper();
        }
        public void Add(TeamDTO entity)
        {
            using(_context = new ApplicationContext())
            {
                var teamToAdd = _teamMapper.Map(entity);
                _context.Teams.Add(teamToAdd);
                _context.SaveChanges();

                _context.Dispose();
            }
        }

        public List<TeamDTO> GetAllEntities()
        {
            var result = new List<TeamDTO>();
            using(_context = new ApplicationContext())
            {
                Load(_context);
                var teams = _context.Teams;
                foreach(var team in teams)
                {
                    if (team.Name == "Not in Team") continue;
                    result.Add(_teamMapper.Map(team));
                }
            }

            return result;
        }

        public void Remove(TeamDTO entity)
        {
            var teamToDelete = FindTeam(entity);
            if (teamToDelete == null) throw new ArgumentNullException("Team can't be null!");
            using(_context = new ApplicationContext())
            {
                _context.Teams.Remove(teamToDelete);
                _context.SaveChanges();

                _context.Dispose();
            }

        }

        public void Update(TeamDTO newEntity, TeamDTO oldEntity)
        {
            var teamId = FindTeam(oldEntity).Id;
            var players = newEntity.Players;
            
            using (_context = new ApplicationContext())
            {
                var dbPlayers = new List<Player>();
                foreach (var plPlayer in players)
                {
                    var player = _context.Players.First(p => p.Name == plPlayer.Name && p.Surname == plPlayer.Surname);
                    dbPlayers.Add(player);
                }
                var team = _context.Teams.First(t => t.Id == teamId);
                team.Players = dbPlayers;
                team.Name = newEntity.Name;
                _context.SaveChanges();
            }
        }

        public Team FindTeam(TeamDTO entity)
        {
            Team result = null;
            using(_context = new ApplicationContext())
            {
                Load(_context);
                var teams = _context.Teams;
                foreach(var team in teams)
                {
                    if (team.Name == entity.Name) result = team;
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
