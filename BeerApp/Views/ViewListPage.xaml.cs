using System;
using BeerApp.Models;
using BeerApp.ViewModels;
using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
using Syncfusion.XForms.TabView;

namespace BeerApp.Views
{
    public partial class ViewListPage : ContentPage
    {
        public ViewListViewModel ViewModel 
        {
            get { return (ViewListViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public ViewListPage()
        {
            try 
            {
                InitializeComponent();

                ViewModel = new ViewListViewModel();

                if (ViewModel.GetBeerByName().Count > 0)
                {
                    foreach (Beer beer in ViewModel.GetBeerByName())
                    {
                        var beerItem = CreateBeer(new ViewListItemViewModel(beer));

                        nameStackLayout.Children.Add(beerItem);
                    }
                }

                if (ViewModel.GetBreweryByName().Count > 0)
                {
                    foreach (Brewery brewery in ViewModel.GetBreweryByName())
                    {
                        var breweryItem = CreateBrewery(new ViewListItemViewModel(brewery));

                        breweryStackLayout.Children.Add(breweryItem);
                    }
                }
            }
            catch(SQLite.SQLiteException)
            {
                InitializeComponent();
            }



        }

        private StackLayout CreateBeer(ViewListItemViewModel beerItemViewModel)
        {
            Color primary = (Color)Application.Current.Resources["primary"];

            var beerTapGestureRecognizer = new TapGestureRecognizer();
            beerTapGestureRecognizer.Tapped += BeerTapGestureRecognizer_Tapped;

            double medium = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

            StackLayout beerStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 60,
                Spacing = 2,
                StyleId = beerItemViewModel.GetBeerID().ToString()
            };

            Frame frame = new Frame
            {
                BorderColor = primary,
                HasShadow = false,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            StackLayout frameStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
            };

            SvgCachedImage cap = new SvgCachedImage
            {
                Source = "resource://BeerApp.Resources.bottle-cap.svg",
                HeightRequest = 40,
                WidthRequest = 40,
                HorizontalOptions = LayoutOptions.Start
            };

            Label label = new Label
            {
                Text = beerItemViewModel.GetBeerName(),
                FontSize = medium,
                TextColor = primary,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            SvgCachedImage expand = new SvgCachedImage
            {
                Source = "resource://BeerApp.Resources.expand.svg",
                HeightRequest = 10,
                WidthRequest = 10,
                HorizontalOptions = LayoutOptions.End
            };

            frameStack.Children.Add(cap);
            frameStack.Children.Add(label);
            frameStack.Children.Add(expand);

            frame.Content = frameStack;

            beerStackLayout.Children.Add(frame);

            beerStackLayout.GestureRecognizers.Add(beerTapGestureRecognizer);

            return beerStackLayout;

        }

        private StackLayout CreateBrewery(ViewListItemViewModel breweryItemViewModel)
        {
            Color primary = (Color)Application.Current.Resources["primary"];

            var breweryTapGestureRecognizer = new TapGestureRecognizer();
            breweryTapGestureRecognizer.Tapped += BreweryTapGestureRecognizer_Tapped;

            double medium = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

            StackLayout breweryStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 60,
                Spacing = 2,
                StyleId = breweryItemViewModel.GetBreweryID().ToString()
            };

            Frame frame = new Frame
            {
                BorderColor = primary,
                HasShadow = false,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            StackLayout frameStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
            };

            SvgCachedImage cap = new SvgCachedImage
            {
                Source = "resource://BeerApp.Resources.bottle-cap.svg",
                HeightRequest = 40,
                WidthRequest = 40,
                HorizontalOptions = LayoutOptions.Start
            };

            Label label = new Label
            {
                Text = breweryItemViewModel.GetBreweryName(),
                FontSize = medium,
                TextColor = primary,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            SvgCachedImage expand = new SvgCachedImage
            {
                Source = "resource://BeerApp.Resources.expand.svg",
                HeightRequest = 10,
                WidthRequest = 10,
                HorizontalOptions = LayoutOptions.End
            };

            frameStack.Children.Add(cap);
            frameStack.Children.Add(label);
            frameStack.Children.Add(expand);

            frame.Content = frameStack;

            breweryStackLayout.Children.Add(frame);

            breweryStackLayout.GestureRecognizers.Add(breweryTapGestureRecognizer);

            return breweryStackLayout;

        }

        private int GetBeerId(object sender)
        {
            if (sender is StackLayout)
            {
                StackLayout stackLayout = sender as StackLayout;
                ViewModel.SelectedBeerId = Convert.ToInt32(stackLayout.StyleId);
            }

            return ViewModel.SelectedBeerId;
        }

        private int GetBreweryId(object sender)
        {
            if (sender is StackLayout)
            {
                StackLayout stackLayout = sender as StackLayout;
                ViewModel.SelectedBreweryId = Convert.ToInt32(stackLayout.StyleId);
            }

            return ViewModel.SelectedBreweryId;
        }

        private async void BeerTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BeerInfoPage(GetBeerId(sender)));
        } 

        private async void BreweryTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BeerListPage());
        }

    }
}
