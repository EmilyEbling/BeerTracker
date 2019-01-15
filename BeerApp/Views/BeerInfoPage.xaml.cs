using System;
using System.Collections.Generic;
using System.IO;
using BeerApp.Models;
using SQLite;
using Xamarin.Forms;

namespace BeerApp.Views
{
    public partial class BeerInfoPage : ContentPage
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");

        public BeerInfoPage(int beerId)
        {
            InitializeComponent();

            var db = new SQLiteConnection(dbPath);

            //Beer beer = db.Query<Beer>("SELECT [Beer] FROM [Beer] WHERE [beerId] = [ID]");
        }


    }
}
