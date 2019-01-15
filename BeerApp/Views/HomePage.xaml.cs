using System;
using System.Collections.Generic;
using System.IO;
using BeerApp.Models;
using SQLite;
using Xamarin.Forms;

namespace BeerApp.Views
{
    public partial class HomePage : ContentPage
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");

        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            FrameSetup();

            var db = new SQLiteConnection(dbPath);

            try
            {
                User user = db.Get<User>(1);

                welcome.Text = "Welcome " + user.Name + "!";  
            }
            catch (SQLiteException)
            {
                welcome.Text = "Welcome!";
            }
        }

        private async void View_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ViewListPage());
        }

        private async void Add_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddEntryPage());
        }

        private async void Suggest_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SuggestionPage());
        }

        private async void Profile_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private void FrameSetup()
        {
            var viewTapGestureRecognizer = new TapGestureRecognizer();
            viewTapGestureRecognizer.Tapped += View_Clicked;

            var addTapGestureRecognizer = new TapGestureRecognizer();
            addTapGestureRecognizer.Tapped += Add_Clicked;

            var suggestTapGestureRecognizer = new TapGestureRecognizer();
            suggestTapGestureRecognizer.Tapped += Suggest_Clicked;

            var profileTapGestureRecognizer = new TapGestureRecognizer();
            profileTapGestureRecognizer.Tapped += Profile_Clicked;

            viewFrame.GestureRecognizers.Add(viewTapGestureRecognizer);
            addFrame.GestureRecognizers.Add(addTapGestureRecognizer);
            suggestFrame.GestureRecognizers.Add(suggestTapGestureRecognizer);
            profileFrame.GestureRecognizers.Add(profileTapGestureRecognizer);

        }
    }
}
