using System;
using SQLite;

namespace BeerApp.Models
{
    [Table("Brewery")]
    public class Brewery
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string BreweryName { get; set; }
    }
}
