using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using BeerApp.Models;
using SQLite;
using Syncfusion.SfRating.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeerApp.Views
{
    public partial class AddEntryPage : ContentPage
    {
        public AddEntryPage()
        {
            InitializeComponent();
        }

        private async void Add_Clicked(object sender, EventArgs args)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");

            //if (name.Text != null && brewery.Text != null && style.Text != null && abv.Text != null && flavor.Text != null && color.Text != null && )

            var db = new SQLiteConnection(dbPath);

            db.CreateTable<Beer>();
            db.CreateTable<Brewery>();

            Brewery breweryB = new Brewery()
            {
                BreweryName = brewery.Text
            };

            Beer beer = new Beer()
            {
                Name = name.Text,
                BreweryId = breweryB.ID,
                Style = style.Text,
                ABV = Convert.ToDouble(abv.Text),
                Flavor = flavor.Text,
                Color = color.Text,
                Comments = comments.Text,
                Rating = Convert.ToDouble(rating.ToString())
            };

            db.Insert(breweryB);
            db.Insert(beer);

            await DisplayAlert(null, "Beer Added", "Ok");
            await Navigation.PopAsync();

        }
    }
}
