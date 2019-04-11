using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ETests.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentFinish : ContentPage
	{
		public PaymentFinish ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Application.Current.Properties["IsDashBoard"] = true;
            Navigation.PushModalAsync(new NavigationDrawarPage());
        }
    }
}