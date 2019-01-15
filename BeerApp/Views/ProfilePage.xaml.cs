using System;
using System.Collections.Generic;
using System.IO;
using BeerApp.Models;
using SQLite;
using Xamarin.Forms;

namespace BeerApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");

        public ProfilePage()
        {
            InitializeComponent();

            var db = new SQLiteConnection(dbPath);

            try
            {
                User user = db.Get<User>(1);

                name.Text = user.Name;
                username.Text = user.Username;
            }
            catch (SQLiteException)
            {
                name.Placeholder = "Name";
                username.Placeholder = "Username";
            }

        }
    }
}
