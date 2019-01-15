using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BeerApp.Models;
using SQLite;

namespace BeerApp.ViewModels
{
    public class ViewListViewModel
    {
        public int SelectedBeerId { get; set; }
        public int SelectedBreweryId { get; set; }

        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");

        public List<Beer> GetBeerByName()
        {
            var db = new SQLiteConnection(dbPath);

            List<Beer> beers = db.Query<Beer>("SELECT [Name] from [Beer] ORDER BY [Name]");

            return beers;
        }

        public List<Brewery> GetBreweryByName()
        {
            var db = new SQLiteConnection(dbPath);

            List<Brewery> breweries = db.Query<Brewery>("SELECT [BreweryName] from [Brewery] ORDER BY [BreweryName]");

            return breweries;
        }

        public List<Beer> GetBeerByBrewery()
        {
            var db = new SQLiteConnection(dbPath);

            List<Beer> breweries = db.Query<Beer>("SELECT [Name] from [Beer], [Brewery] where [BreweryID] = [BreweryID] ORDER BY [Beer]");

            return breweries;
        }
    }
}
