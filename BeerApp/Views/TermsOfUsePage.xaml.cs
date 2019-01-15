using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BeerApp.Views
{
    public partial class TermsOfUsePage : ContentPage
    {
        public TermsOfUsePage()
        {
            InitializeComponent();
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
