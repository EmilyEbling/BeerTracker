using System;
using Xamarin.Forms;

namespace BeerApp.CustomElements
{
    public class EditorWithPlaceholder : Editor
    {
        public static BindableProperty PlaceholderProperty 
        = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(EditorWithPlaceholder));

        public static BindableProperty PlaceholderColorProperty
        = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(EditorWithPlaceholder), Color.LightGray);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

    }
}
