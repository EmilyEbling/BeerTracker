using System;
using SQLite;

namespace BeerApp.Models
{
    [Table("Beer")]
    public class Beer
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int BreweryId { get; set; }
        public string Style { get; set; }
        public double ABV { get; set; }
        public string Flavor { get; set; } 
        public string Color { get; set; }
        public double Rating { get; set; }
        public string Comments { get; set; }

    }
}
