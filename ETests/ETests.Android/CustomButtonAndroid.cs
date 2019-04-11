using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ETests.CustomControls;
using ETests.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonAndroid))]

namespace ETests.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    class CustomButtonAndroid : ButtonRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            Control?.SetPadding(20, 20, 20, 20);
            if (e.OldElement != null || e.NewElement != null)
            {

                //var gradientDrawable = new GradientDrawable();
                //gradientDrawable.SetCornerRadius(5f);
                //gradientDrawable.SetStroke(1, Android.Graphics.Color.Gray);
                //gradientDrawable.SetColor(Android.Graphics.Color.White);

                //Control.SetBackground(gradientDrawable);

                Control.SetPadding(Control.PaddingLeft, Control.PaddingTop, Control.PaddingRight,
                        Control.PaddingBottom);


                this.Control.Gravity = GravityFlags.Center;

                // add click event
                //Control.Click += Control_Click;

            }
        }
    }

}