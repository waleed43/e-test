using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ETests.CustomControls
{
    public class MaskedBehavior : Behavior<CustomEntery>
    {
        CustomEntery control;
        string _placeHolder;
        Xamarin.Forms.Color _placeHolderColor;
        private string _mask = "";
        public string Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                SetPositions();
            }
        }

        protected override void OnAttachedTo(CustomEntery entry)
        {
            // entry.TextChanged += HandleTextChanged;
            entry.TextChanged += OnEntryTextChanged;
            entry.PropertyChanged += OnPropertyChanged;
            
            control = entry;
            _placeHolder = entry.Placeholder;
            _placeHolderColor = entry.PlaceholderColor;
        }


        //void HandleTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(e.NewTextValue))
        //    {
        //        ((CustomEntery)sender).IsBorderErrorVisible = false;
        //    }
        //}


        protected override void OnDetachingFrom(CustomEntery entry)
        {
            //entry.TextChanged -= HandleTextChanged;
            entry.PropertyChanged -= OnPropertyChanged;
            entry.TextChanged -= OnEntryTextChanged;
            //base.OnDetachingFrom(entry);
        }

        IDictionary<int, char> _positions;

        void SetPositions()
        {
            if (string.IsNullOrEmpty(Mask))
            {
                _positions = null;
                return;
            }

            var list = new Dictionary<int, char>();
            for (var i = 0; i < Mask.Length; i++)
                if (Mask[i] != 'X')
                    list.Add(i, Mask[i]);

            _positions = list;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;

            var text = entry.Text;

            if (string.IsNullOrWhiteSpace(text) || _positions == null)
                return;

            if (text.Length > _mask.Length)
            {
                ((CustomEntery)sender).IsBorderErrorVisible = false;
                entry.Text = text.Remove(text.Length - 1);
                return;
            }

            foreach (var position in _positions)
                if (text.Length >= position.Key + 1)
                {
                    var value = position.Value.ToString();
                    if (text.Substring(position.Key, 1) != value)
                        text = text.Insert(position.Key, value);
                }

            if (entry.Text != text)
                entry.Text = text;

        }

        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CustomEntery.IsBorderErrorVisibleProperty.PropertyName && control != null)
            {
                if (control.IsBorderErrorVisible)
                {
                    control.Placeholder = control.ErrorText;
                    control.PlaceholderColor = control.BorderErrorColor;
                    control.Text = string.Empty;
                }

                else
                {
                    control.Placeholder = _placeHolder;
                    control.PlaceholderColor = _placeHolderColor;
                }

            }
        }
    }
}
