using System;
using Cirrious.FluentLayouts.Touch;
using UIKit;
using BeerApp.CustomElements;
using BeerApp.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EditorWithPlaceholder), typeof(EditorWithPlaceholderRenderer))]
namespace BeerApp.iOS
{
    public class EditorWithPlaceholderRenderer : EditorRenderer
    {
        private UILabel placeholderLabel;

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Element == null)
                return;

            CreatePlaceholderLabel((EditorWithPlaceholder)Element, Control);

            Control.Ended += OnEnded;
            Control.Changed += OnChanged;

            Control.Layer.BorderWidth = 0;
        }

        private void CreatePlaceholderLabel(EditorWithPlaceholder element, UITextView parent)
        {
            placeholderLabel = new UILabel
            {
                Text = element.Placeholder,
                TextColor = element.PlaceholderColor.ToUIColor(),
                BackgroundColor = UIColor.Clear,
                TextAlignment = UITextAlignment.Natural
            };
            placeholderLabel.SizeToFit();

            parent.AddSubview(placeholderLabel);

            parent.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            parent.AddConstraints(placeholderLabel.AtLeftOf(parent, 7), placeholderLabel.WithSameCenterY(parent));
            parent.LayoutIfNeeded();

            placeholderLabel.Hidden = parent.HasText;
        }

        private void OnEnded(object sender, EventArgs args)
        {
            if (!((UITextView)sender).HasText && placeholderLabel != null)
                placeholderLabel.Hidden = false;
        }

        private void OnChanged(object sender, EventArgs args)
        {
            if (placeholderLabel != null)
                placeholderLabel.Hidden = ((UITextView)sender).HasText;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.Ended -= OnEnded;
                Control.Changed -= OnChanged;

                placeholderLabel?.Dispose();
                placeholderLabel = null;
            }

            base.Dispose(disposing);
        }
    }
}