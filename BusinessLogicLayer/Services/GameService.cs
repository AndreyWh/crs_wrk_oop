using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using DB;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services
{
    public class GameService : IService<GameDTO>
    {
        private GameMapper _gameMapper;
        private TeamMapper _teamMapper;
        private StadiumMapper _stadiumMapper;


        private ApplicationContext _context;
        public GameService()
        {
            _stadiumMapper = new StadiumMapper();
            _gameMapper = new GameMapper();
            _teamMapper = new TeamMapper();
        }

        public void Add(GameDTO entity)
        {
            using (_context = new ApplicationContext())
            {
                Load(_context);

                var homeTeam = _context.Teams.First(t => t.Name == entity.Teams[0].Name);
                var awayTeam = _context.Teams.First(t => t.Name == entity.Teams[1].Name);
                var stadium = _context.Stadiums.First(t => t.Name == entity.Stadium.Name);
                var gameToAdd = _gameMapper.Map(entity);
                gameToAdd.HomeTeam = homeTeam;
                gameToAdd.AwayTeam = awayTeam;
                gameToAdd.Stadium = stadium;
                _context.Games.Add(gameToAdd);
                _context.SaveChanges();

                _context.Dispose();
            }
        }

        public List<GameDTO> GetAllEntities()
        {
            var result = new List<GameDTO>();
            using (_context = new ApplicationContext())
            {
                Load(_context);
                var games = _context.Games;
                foreach(var game in games) result.Add(_gameMapper.Map(game));

                _context.Dispose();
            }

            return result;
        }

        public void Remove(GameDTO entity)
        {
            var gameToDelete = FindGame(entity);
            using (_context = new ApplicationContext())
            {
                if (gameToDelete == null) throw new ArgumentNullException("Game can't be null");
                _context.Games.Remove(gameToDelete);
                _context.SaveChanges();

                _context.Dispose();
            }
        }

        public void Update(GameDTO newEntity, GameDTO oldEntity)
        {
            var changedGameId = FindGame(oldEntity).Id;
            var game = _gameMapper.Map(newEntity);
            var homeTeam = _teamMapper.Map(newEntity.Teams[0]);
            var awayTeam = _teamMapper.Map(newEntity.Teams[1]);
            var stadium = _stadiumMapper.Map(newEntity.Stadium);
            using (_context = new ApplicationContext())
            {
                Load(_context);
                var gameToChange = _context.Games.First(g => g.Id == changedGameId);
                gameToChange.Stadium = _context.Stadiums.First(s => s.Name == stadium.Name);
                gameToChange.Result = game.Result;
                gameToChange.AwayTeam = _context.Teams.First(t => t.Name == awayTeam.Name);
                gameToChange.HomeTeam = _context.Teams.First(t => t.Name == homeTeam.Name);
                gameToChange.Date = game.Date;
                _context.SaveChanges();

            }
        }

        private Game FindGame(GameDTO entity)
        {
            Game result = null;
            using (_context = new ApplicationContext())
            {
                Load(_context);
                var games = _context.Games;

                foreach (var game in games)
                {
                    var dbTeams = new List<Team>();
                    dbTeams.Add(game.HomeTeam);
                    dbTeams.Add(game.AwayTeam);
                    if(game.Date == entity.Date) result = game;
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
