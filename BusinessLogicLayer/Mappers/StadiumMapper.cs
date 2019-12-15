using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Mappers
{
    public class StadiumMapper : IMapper<StadiumDTO, Stadium>
    {
        public StadiumDTO Map(Stadium dbClass)
        {
            var result = new StadiumDTO(dbClass.Name, dbClass.Capacity, dbClass.PriceForPlace);
            return result;
        }

        public Stadium Map(StadiumDTO dtoClass)
        {
            var result = new Stadium(dtoClass.Name, dtoClass.Capacity, dtoClass.PriceForPlace);
            return result;
        }
    }
}
