using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTO
{
    public class StadiumDTO
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int PriceForPlace { get; set; }

        public StadiumDTO(string name, int capacity, int priceForPlace)
        {
            Name = name;
            Capacity = capacity;
            PriceForPlace = priceForPlace;
        }

        public StadiumDTO(StadiumDTO stadium)
        {
            Name = stadium.Name;
            Capacity = stadium.Capacity;
            PriceForPlace = stadium.PriceForPlace;
        }
    }
}
