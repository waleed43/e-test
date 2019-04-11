using System;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using ETests.CustomControls;
using ETests.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntery), typeof(CustomEnteryAndroid))]
namespace ETests.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    class CustomEnteryAndroid : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            UpdateBorders();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null) return;

            if (e.PropertyName == CustomEntery.IsBorderErrorVisibleProperty.PropertyName)
                UpdateBorders();
        }

        void UpdateBorders()
        {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(50);
            shape.SetColor(Android.Graphics.Color.White);
            //if (((CustomEntery)this.Element).IsBorderErrorVisible)
            //{
            //    shape.SetStroke(3, ((CustomEntery)this.Element).BorderErrorColor.ToAndroid());
            //}
            //else
            //{
            //    shape.SetStroke(3, Android.Graphics.Color.LightGray);
                
            //    this.Control.SetBackground(shape);
            //}

            this.Control.SetBackground(shape);
            Control.SetPadding(35, Control.PaddingTop, Control.PaddingRight,
                        10);
            this.Control.Gravity = GravityFlags.CenterVertical;
        }

    }

}