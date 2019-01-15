using System;
using BeerApp.Models;

namespace BeerApp.ViewModels
{
    public class ViewListItemViewModel
    {
        public Beer Beer { get; set; }
        public Brewery Brewery { get; set; }

        public ViewListItemViewModel(Beer beer)
        {
            Beer = beer;
        }

        public ViewListItemViewModel(Brewery brewery)
        {
            Brewery = brewery;
        }

        public int GetBeerID()
        {
            return Beer.ID;
        }

        public int GetBreweryID()
        {
            return Brewery.ID;
        }

        public string GetBeerName()
        {
            return Beer.Name;
        }

        public string GetBreweryName()
        {
            return Brewery.BreweryName;
        }

    }
}
