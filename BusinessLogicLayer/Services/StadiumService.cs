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
    public class StadiumService : IService<StadiumDTO>
    {
        private ApplicationContext _context;
        private StadiumMapper _stadiumMapper;
        public StadiumService()
        {
            _stadiumMapper = new StadiumMapper();
        }
        public void Add(StadiumDTO entity)
        {
            using(_context = new ApplicationContext())
            {

                var stadiumToAdd = _stadiumMapper.Map(entity);
                _context.Stadiums.Add(stadiumToAdd);
                _context.SaveChanges();

                _context.Dispose();
            }
        }

        public List<StadiumDTO> GetAllEntities()
        {
            var result = new List<StadiumDTO>();
            using(_context = new ApplicationContext())
            {
                Load(_context);
                var stadiums = _context.Stadiums;
                foreach (var stadium in stadiums) result.Add(_stadiumMapper.Map(stadium));
            }

            return result;
        }

        public void Remove(StadiumDTO entity)
        {
            var stadiumToDelete = FindStadium(entity);
            if (stadiumToDelete == null) throw new ArgumentNullException("Stadium can't be null");
            using(_context = new ApplicationContext())
            {
                _context.Stadiums.Remove(stadiumToDelete);
                _context.SaveChanges();

                _context.Dispose();
            }
        }


        public Stadium FindStadium(StadiumDTO entity)
        {
            var stadiumToFind = _stadiumMapper.Map(entity);
            Stadium result = null;
            using(_context = new ApplicationContext())
            {
                Load(_context);
                var stadiums = _context.Stadiums;
                foreach(var stadium in stadiums)
                {
                    if (stadium.Name == stadiumToFind.Name && stadium.PriceForPlace == stadiumToFind.PriceForPlace && stadium.Capacity == stadiumToFind.Capacity) result = stadium;
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

        public void Update(StadiumDTO newEntity, StadiumDTO oldEntity)
        {
            var stadiumId = FindStadium(oldEntity).Id;
            using (_context = new ApplicationContext())
            {
                Load(_context);
                var stadiumToChange = _context.Stadiums.First(s => s.Id == stadiumId);
                stadiumToChange.Name = newEntity.Name;
                stadiumToChange.Capacity = newEntity.Capacity;
                stadiumToChange.PriceForPlace = newEntity.PriceForPlace;

                _context.SaveChanges();
            }
        }
    }
}
