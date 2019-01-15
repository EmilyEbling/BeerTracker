using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BeerApp.Views;
using BeerApp.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BeerApp
{
    public partial class App : Application
    {
        public string IsFirstTime
        {
            get { return Settings.GeneralSettings; }
            set
            {
                if (Settings.GeneralSettings == value)
                    return;
                Settings.GeneralSettings = value;
                OnPropertyChanged();
            }
        }

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA5NEAzMTM2MmUzMjJlMzBRd1gwR2N5TGV6WGRaVy80QlJ0R3hlRXAvQlo0OFZLNzJYUnREbE5ESzdJPQ==");
                      
            InitializeComponent();

            if (IsFirstTime == "yes")
            {
                IsFirstTime = "no";
                MainPage = new NavigationPage(new StartupPage());
            }
            else
            {
                MainPage = new NavigationPage(new HomePage());
            }
       
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
