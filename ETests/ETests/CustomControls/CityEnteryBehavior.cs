using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ETests.CustomControls
{
    class CityEnteryBehavior : Behavior<CustomEntery>
    {
        CustomEntery control;
        string _placeHolder;
        const string numberRegex = @"^[a-zA-Z]+$";
        Xamarin.Forms.Color _placeHolderColor;
        protected override void OnAttachedTo(CustomEntery bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            bool IsValid = false;
            IsValid = (Regex.IsMatch(e.NewTextValue, numberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((CustomEntery)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(CustomEntery bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }

}
