using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int PriceForPlace { get; set; }
        
        public List<Game> Games { get; set; }

        public Stadium(string name, int capacity, int priceForPlace)
        {
            Name = name;
            Capacity = capacity;
            PriceForPlace = priceForPlace;
        }
    }
}
