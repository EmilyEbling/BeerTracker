using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.IO;
using System.Collections;
using BeerApp.Models;

namespace BeerApp.Views
{
    public partial class StartupPage : ContentPage
    {
        public StartupPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }

        private async void Continue_Clicked(object sender, EventArgs e)
        {
            if(name.Text != null && username.Text != null)
            {
                var answer = await DisplayAlert(null, "By selecting \"yes\" below, you confirm that you are at least 21 years of age and agree to the terms of use for this app.", "Yes", "No");

                if (answer)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");

                    var db = new SQLiteConnection(dbPath);

                    db.CreateTable<User>();

                    User user = new User()
                    {
                        Name = name.Text,
                        Username = username.Text
                    };

                    db.Insert(user);

                    await Navigation.PushAsync(new HomePage());
                }
                else
                    return;
            }
            else
                await DisplayAlert(null, "Incomplete Information", "Ok");
        }

        private async void Terms_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TermsOfUsePage());
        }
    }
}
